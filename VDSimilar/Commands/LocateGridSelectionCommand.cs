using System.Linq;
using VectorDraw.Professional.vdPrimaries;

namespace VDSimilar.SimilarityLib
{
    public class LocateGridSelectionCommand : VectorDrawCommand
    {
        public override string CommandName => nameof(LocateGridSelectionCommand);
        public override object Execute(vdControls.vdFramedControl vdFramedControl)
        {
            var document = vdFramedControl.BaseControl.ActiveDocument;
            var vdGrid = vdFramedControl.vdGrid;
            var selectedObjArr = vdGrid.SelectedObject as object[];
            if (selectedObjArr == null)
                return null;
            VdUtil.LocateFigures(document, selectedObjArr.OfType<vdFigure>().ToList());
            VdUtil.RefreshVectorDraw(document);
            return null;
        }
    }
}