using System;
using System.Collections.Generic;
using System.Linq;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Render;

namespace VDSimilar.SimilarityLib
{
    public class SimilarProcessor
    {
        private readonly vdDocument _document;

        public SimilarProcessor(vdDocument document)
        {
            _document = document;
        }

        /// <summary>
        /// 考虑旋转，默认为不考虑
        /// </summary>
        public bool ConsiderRotate { get; set; } = false;
        /// <summary>
        /// 考虑镜像，默认为不考虑
        /// </summary>
        public bool ConsiderMirror { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcFigures"></param>
        /// <param name="itemsOfSample">样本组，里面包含多个图元</param>
        /// <returns></returns>
        public List<SampleItem> GetSimilars(List<vdFigure> srcFigures, List<vdFigure> itemsOfSample)
        {
            if (itemsOfSample == null || itemsOfSample.Count < 2)
                throw new ArgumentException(nameof(itemsOfSample));

            //选中的样品，后续就是找跟这个相似的
            var sample = new SampleItem(itemsOfSample);

            var majorFilter = FilterFactory.Get(sample.Major.GetType());
            if (majorFilter == null)
                return new List<SampleItem>(0);
            //从源图元集合中找出符合样本特征图元的元素
            var majorList = majorFilter.Filter(srcFigures, sample.Major);

            //样本组外包矩形
            var sampleBoundingBox = sample.GetBoundingBox();
            //样本组特征图元到中心点的位移
            var sampleOffsetOfMajor2Center = new gPoint(
                sampleBoundingBox.MidPoint.x - sample.Major.BoundingBox.MidPoint.x,
                sampleBoundingBox.MidPoint.y - sample.Major.BoundingBox.MidPoint.y);
            //样本组特征图元到中心点的位移长度
            var sampleOffsetLenOfMajor2Center = gPoint.Distance2D(sampleBoundingBox.MidPoint,
                sample.Major.BoundingBox.MidPoint);
            //sampleBoundingBox.MidPoint - sample.Major.BoundingBox.MidPoint;
            //样本外包矩形的对角线长度
            var sampleDiagonalLen = Math.Pow(Math.Pow(sampleBoundingBox.Width, 2.0) + Math.Pow(sampleBoundingBox.Height, 2.0), 0.5);
            //找到的和样本组类似的图元组集合
            var result = new List<SampleItem> { sample };

            //var sampleMajorLenOfBox = new List<double>();
            //foreach (gPoint togPoint in sampleBoundingBox.TogPoints())
            //{
            //    sampleMajorLenOfBox.Add(gPoint.Distance2D(togPoint,sample.Major.BoundingBox.MidPoint));
            //}
            //var sampleMajorMaxLenOfBox = sampleMajorLenOfBox.Max();

            //选择集合
            var selectingList = new List<vdFigure>();
            var debugLayer = AppendLayer(_document, "DebugLayer");
            DeleteByLayer(_document.ActionLayout, debugLayer);

            foreach (var major in majorList)
            {
                //根据特征图元的中心点、样本组外包矩形的对角线长度，样本组特征图元到中心点的位移
                //计算该次框选的范围
                var boundingBox = new Box();
                boundingBox.AddPoint(major.BoundingBox.MidPoint);
                boundingBox.AddWidth((sampleDiagonalLen + sampleOffsetLenOfMajor2Center) / 2d + 1);
                //boundingBox.AddWidth(sampleMajorMaxLenOfBox);
                //boundingBox.AddWidth(1);
                //boundingBox.Offset(sampleOffsetOfMajor2Center.x, sampleOffsetOfMajor2Center.y, 0);

                //框选
                var selection = _document.Selections.Add("BoundingByMajor");
                selection.RemoveAll();
                selection.Select(RenderSelect.SelectingMode.WindowRectangle, new gPoints(new[] { boundingBox.UpperLeft, boundingBox.LowerRight }));

                //selectingList.Add(major);
                //selectingList.Add(AppendRect(_document, boundingBox, debugLayer));
                //continue;


                var matcher = new SampleMatcher();
                var fromFigures = selection.OfType<vdFigure>().ToList();
                fromFigures.Sort(new MidPointComparer());
                //从框选结果中筛选图元
                var item = matcher.Match(fromFigures, major, sample);
                if (item != null && GetXorItem(result, item) == null)
                {
                    result.Add(item);
                    selectingList.AddRange(item.Entities);
                }
                else
                {
                    //VdUtil.SelectFigures(_document, fromFigures);
                    //VdUtil.RefreshVectorDraw(_document);
                    //break;
                }
            }
            if (selectingList.Count > 0)
            {
                VdUtil.SelectFigures(_document, selectingList);
                VdUtil.RefreshVectorDraw(_document);
            }
            return result;
        }

        private SampleItem GetXorItem(List<SampleItem> list, SampleItem test)
        {
            var testBox = test.GetBoundingBox();
            var testDiagonalLen2 = Math.Pow(Math.Pow(testBox.Width, 2.0) + Math.Pow(testBox.Height, 2.0), 0.5) * 2;
            foreach (var item in list)
            {
                var itemBox = item.GetBoundingBox();
                var distance = itemBox.MidPoint.Distance2D(testBox.MidPoint);
                if (distance < testDiagonalLen2)
                {
                    if (item.Entities.Any(cond => test.Entities.Contains(cond)))
                        return item;
                }
            }
            return null;
        }

        private vdLayer AppendLayer(vdDocument document, string layerName)
        {
            vdLayer layer;
            if ((layer = document.Layers.FindName(layerName)) == null)
            {
                layer = document.Layers.Add(layerName);
            }
            return layer;
        }

        private int DeleteByLayer(vdLayout layout, vdLayer layer)
        {
            var result = 0;
            for (var i = layout.Entities.Count - 1; i >= 0; i--)
            {
                if (layout.Entities[i].Layer == layer)
                {
                    layout.Entities.RemoveAt(i);
                    ++result;
                }
            }
            return result;
        }

        private vdRect AppendRect(vdDocument document, Box boundingBox, vdLayer layer = null)
        {
            var rect = new vdRect
            {
                InsertionPoint = new gPoint(boundingBox.Left, boundingBox.Bottom),
                Width = boundingBox.Width,
                Height = boundingBox.Height,
                Layer = layer ?? document.ActiveLayer,
                LineType = document.LineTypes.DPIDash,
                PenColor = new vdColor(System.Drawing.Color.Green)
            };
            document.ActiveLayOut.Entities.AddItem(rect);
            return rect;
        }
    }
}