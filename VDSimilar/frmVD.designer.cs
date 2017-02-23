namespace VDSimilar
{
    partial class frmVD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVD));
            this.VD = new vdControls.vdFramedControl();
            this.SuspendLayout();
            // 
            // VD
            // 
            this.VD.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.VD.DisplayPolarCoord = false;
            resources.ApplyResources(this.VD, "VD");
            this.VD.HistoryLines = ((uint)(3u));
            this.VD.Name = "VD";
            this.VD.PropertyGridWidth = ((uint)(300u));
            // 
            // frmVD
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.VD);
            this.Name = "frmVD";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmVD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public vdControls.vdFramedControl VD;

    }
}