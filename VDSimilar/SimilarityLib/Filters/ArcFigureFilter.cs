using System;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdPrimaries;

namespace VDSimilar.SimilarityLib
{
    public class ArcFigureFilter : BaseFigureFilter
    {
        protected override bool FilterItem(vdFigure item, vdFigure sampleMajor)
        {
            var itemFigure = item as vdArc;
            var sampleFigure = sampleMajor as vdArc;
            if (itemFigure == null || sampleFigure == null)
                return false;

            var radiusRange = sampleFigure.Radius * 0.1;
            if (radiusRange > 0.001)
                radiusRange = 0.001;
            if (Math.Abs(itemFigure.Radius - sampleFigure.Radius) > radiusRange)
                return false;
            ////夹角误差小于2度，Math.PI/180=0.017453292519943295
            //var itemAngle = Math.Abs(itemFigure.EndAngle - itemFigure.StartAngle) % Math.PI;
            //var sampleAngle = Math.Abs(sampleFigure.EndAngle - sampleFigure.StartAngle) % Math.PI;
            //if (Math.Abs(itemAngle - sampleAngle) > 0.03d)
            //    return false;
            //使用圆弧面积进行比较
            if (Math.Abs(Math.Abs(itemFigure.Area()) - Math.Abs(sampleFigure.Area())) > 0.001)
                return false;
            return true;
        }
    }
}