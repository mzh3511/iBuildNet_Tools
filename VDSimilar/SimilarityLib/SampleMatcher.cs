using System;
using System.Collections.Generic;
using System.Linq;
using VectorDraw.Professional.vdPrimaries;

namespace VDSimilar.SimilarityLib
{
    public class SampleMatcher
    {
        public SampleItem Match(List<vdFigure> srcFigures, vdFigure srcMajor, SampleItem sample)
        {
            if (srcFigures.Count < sample.Entities.Count)
                return null;
            //后面对该集合进行改动
            srcFigures = new List<vdFigure>(srcFigures);

            var resultItemList = new List<vdFigure>();
            foreach (var sampleItem in sample.Entities)
            {
                if (sampleItem == sample.Major)
                {
                    resultItemList.Add(srcMajor);
                    continue;
                }
                var srcFigure = FilterFigure(srcFigures, srcMajor, sampleItem, sample.Major);
                if (srcFigure != null)
                {
                    resultItemList.Add(srcFigure);
                    srcFigures.Remove(srcFigure);

                }
                else
                {
                    return null;
                }
            }

            if (resultItemList.Count == sample.Entities.Count)
                return new SampleItem(resultItemList, srcMajor);
            return null;
        }

        private vdFigure FilterFigure(List<vdFigure> srcFigures, vdFigure srcMajor, vdFigure sampleFigure, vdFigure sampleMajor)
        {
            var sampleFigureType = sampleFigure.GetType();
            var sampleFigureOffsetLenSquared = sampleFigure.BoundingBox.MidPoint.DistanceSquared(sampleMajor.BoundingBox.MidPoint);
            for (var i = 0; i < srcFigures.Count; i++)
            {
                var srcfigure = srcFigures[i];
                if (srcfigure == srcMajor)
                    continue;
                if (srcfigure.GetType() != sampleFigureType)
                    continue;

                var offset = srcfigure.BoundingBox.MidPoint - srcMajor.BoundingBox.MidPoint;
                if (Math.Abs(offset.x * offset.x + offset.y * offset.y - sampleFigureOffsetLenSquared) >= 2)
                    continue;

                var filter = FilterFactory.Get(sampleFigureType);
                if (filter != null)
                {
                    if (filter.IsLike(srcfigure, sampleFigure))
                        return srcfigure;
                }
            }
            return null;
        }
    }
}