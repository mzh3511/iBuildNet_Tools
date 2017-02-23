using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdPrimaries;

namespace VDSimilar.SimilarityLib
{
    [DebuggerDisplay("Count={_entities.Count}")]
    public class SampleItem
    {
        private Box _boundingBox = new Box();
        private readonly List<vdFigure> _entities = new List<vdFigure>();

        public IList<vdFigure> Entities { get; }
        public vdFigure Major { get; private set; }

        public SampleItem(List<vdFigure> items)
        {
            _entities.AddRange(items);
            _entities.Sort(new MidPointComparer());
            Entities = new ReadOnlyCollection<vdFigure>(_entities);

            var list4Major = new List<vdFigure>(_entities);
            list4Major.Sort(new MajorItemComparer());
            Major = list4Major[0];
        }

        public SampleItem(List<vdFigure> items, vdFigure major)
        {
            _entities.AddRange(items);
            _entities.Sort(new MidPointComparer());
            Entities = new ReadOnlyCollection<vdFigure>(_entities);

            Major = major;
        }

        public Box GetBoundingBox()
        {
            if (_boundingBox.IsEmpty && _entities.Count != 0)
                _boundingBox = VdUtil.GetBoundingBox(_entities);
            return _boundingBox;
        }
    }
}