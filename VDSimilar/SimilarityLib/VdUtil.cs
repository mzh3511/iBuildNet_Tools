using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;

namespace VDSimilar.SimilarityLib
{
    public class VdUtil
    {
        public static vdFigure GetFigureByHandle(vdLayout layout, ulong handleId)
        {
            return layout.Entities.Cast<vdFigure>().FirstOrDefault(entity => entity.HandleId == handleId);
        }

        public static vdSelection GetGripSelection(vdLayout layout)
        {
            var gripsetname = "VDGRIPSET_" + layout.Handle.ToStringValue();
            if (layout.ActiveViewPort != null)
                gripsetname = gripsetname + layout.ActiveViewPort.Handle.ToStringValue();
            var gripset = layout.Document.Selections.FindName(gripsetname);
            return gripset;
        }

        public static void SelectFigures(vdDocument document, IList<vdFigure> entities)
        {
            var gripSelectioin = GetGripSelection(document.ActionLayout);
            gripSelectioin.RemoveAll();
            if (entities.Count >= 10)
            {
                //前面图元列表不触发事件，只在添加最后一个图元时触发事件
                var freezeEvents = gripSelectioin.FreezeEvents;
                gripSelectioin.FreezeEvents = true;

                var list1 = new List<vdFigure>(entities);
                list1.RemoveAt(list1.Count - 1);
                gripSelectioin.AddRange(new vdEntities(list1.ToArray()), vdSelection.AddItemCheck.Nochecking);
                gripSelectioin.FreezeEvents = freezeEvents;

                var list2 = new List<vdFigure>(entities);
                list2.RemoveRange(0, list2.Count - 1);
                gripSelectioin.AddRange(new vdEntities(list2.ToArray()), vdSelection.AddItemCheck.Nochecking);
            }
            else
            {
                gripSelectioin.AddRange(new vdEntities(entities.ToArray()), vdSelection.AddItemCheck.Nochecking);
            }

            gripSelectioin.ShowGrips(true);
        }

        public static void LocateFigures(vdDocument document, IList<vdFigure> entities)
        {
            var boundingBox = GetBoundingBox(entities);
            document.ZoomWindow(boundingBox.UpperLeft, boundingBox.LowerRight);
            document.ZoomScale(60);
        }

        public static Box GetBoundingBox(IList<vdFigure> entities)
        {
            var vdEntities = new vdEntities(entities.ToArray());
            return vdEntities.GetBoundingBox(true, true);
        }

        public static void RefreshVectorDraw(vdDocument document)
        {
            document.Update();
            document.Redraw(true);
        }
    }
}