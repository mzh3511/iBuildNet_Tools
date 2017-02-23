using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VDSimilar.SimilarityLib;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Render;
namespace VDSimilar
{
    public partial class frmVD : Form
    {
        private readonly SelectNextCommand _selectObjCommand = new SelectNextCommand();
        public frmVD()
        {
            InitializeComponent();
        }

        #region 窗口事件

        // 窗体载入
        private void frmVD_Load(object sender, EventArgs e)
        {
            VD.BaseControl.ActiveDocument.UCS("VIEW");
            VD.CommandLine.CommandExecute -= CommandLine_CommandExecute;
            VD.CommandLine.CommandExecute += CommandLine_CommandExecute;

            VD.BaseControl.vdKeyUp -= BaseControl_vdKeyUp;
            VD.BaseControl.vdKeyUp += BaseControl_vdKeyUp;
        }
        #endregion

        #region "VD控件的事件"
        /// <summary>
        /// execute system command
        /// </summary>
        /// <param name="commandname"></param>
        /// <param name="isDefaultImplemented"></param>
        /// <param name="success"></param>
        private void CommandLine_CommandExecute(string commandname, bool isDefaultImplemented, ref bool success)
        {
            if (isDefaultImplemented)
                return;
            VectorDrawCommand command = null;
            switch (commandname)
            {
                case "cls":
                    VD.CommandLine.History.Clear();
                    break;
                case "11":
                    command = new LocateGridSelectionCommand();
                    command.Execute(VD);
                    success = true;
                    break;
                case "22":
                    command = new FindSimilarsCommand();
                    var sampleItems = command.Execute(VD) as List<SampleItem>;
                    if (sampleItems != null)
                    {
                        var setList = sampleItems.Select(sampleItem => sampleItem.Entities.ToList()).ToList();
                        _selectObjCommand.SetList = setList;
                        VD.CommandLine.History.AppendText("\r\n");
                        VD.CommandLine.History.AppendText($"Execute {command.CommandName}, result count={sampleItems.Count}");
                        VD.CommandLine.History.AppendText("\r\n");
                    }
                    else
                    {
                        _selectObjCommand.SetList = null;
                    }
                    success = true;
                    break;
                case "33":
                    command = new DetailSelectionCommand();
                    var sbDetail = command.Execute(VD) as StringBuilder;
                    if (sbDetail != null)
                    {
                        VD.CommandLine.History.AppendText("\r\n");
                        VD.CommandLine.History.AppendText($"Execute {command.CommandName}, result =\r\n{sbDetail}");
                        VD.CommandLine.History.AppendText("\r\n");
                    }
                    break;
            }
        }

        private void BaseControl_vdKeyUp(KeyEventArgs e, ref bool cancel)
        {
            if (e.KeyCode == Keys.F2)
            {
                _selectObjCommand.Execute(VD);
            }
        }
        #endregion
    }
}
