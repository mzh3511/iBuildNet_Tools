using System.Linq;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Professional.vdPrimaries;

namespace VDSimilar.SimilarityLib
{
    public class FindSimilarsCommand : VectorDrawCommand
    {
        public override string CommandName => nameof(FindSimilarsCommand);
        public override object Execute(vdControls.vdFramedControl vdFramedControl)
        {
            var document = vdFramedControl.BaseControl.ActiveDocument;
            var layout = vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut;

            var gripSelection = VdUtil.GetGripSelection(layout);
            var srcList = layout.Entities.Cast<vdFigure>().ToList();
            var entitiesOfSample = gripSelection.Cast<vdFigure>().ToList();

            var processor = new SimilarProcessor(document);
            return processor.GetSimilars(srcList, entitiesOfSample);
        }
    }
}