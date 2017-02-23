using System;
using System.Collections.Generic;
using VectorDraw.Professional.vdPrimaries;

namespace VDSimilar.SimilarityLib
{
    public abstract class BaseFigureFilter
    {
        public Func<vdFigure, vdFigure, bool> PreFilterFunc { get; set; }
        public List<vdFigure> Filter(List<vdFigure> srcFigures, vdFigure sampleMajor)
        {
            if (srcFigures == null || srcFigures.Count == 0)
                throw new ArgumentNullException(nameof(srcFigures));
            if (sampleMajor == null)
                throw new ArgumentNullException(nameof(sampleMajor));

            var passedSet = new List<vdFigure>();
            var sampleType = sampleMajor.GetType();
            foreach (vdFigure srcFigure in srcFigures)
            {
                if (srcFigure.GetType() != sampleType)
                    continue;
                if (srcFigure == sampleMajor)
                    continue;
                if (PreFilterFunc != null && !PreFilterFunc.Invoke(srcFigure, sampleMajor))
                    continue;
                if (FilterItem(srcFigure, sampleMajor))
                    passedSet.Add(srcFigure);
            }
            return passedSet;
        }

        public bool IsLike(vdFigure figure1, vdFigure figure2)
        {
            if (figure1.GetType() != figure2.GetType())
                return false;
            if (PreFilterFunc != null && !PreFilterFunc.Invoke(figure1, figure2))
                return false;
            return FilterItem(figure1, figure2);
        }

        protected abstract bool FilterItem(vdFigure item, vdFigure sampleMajor);
    }
}