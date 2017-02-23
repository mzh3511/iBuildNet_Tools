namespace SolutionReader
{
    partial class FormSolutionMgr
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpxDotfuscatorUpdater = new System.Windows.Forms.GroupBox();
            this.btnUpdateDotfuscator = new System.Windows.Forms.Button();
            this.txtSlnPath = new System.Windows.Forms.TextBox();
            this.lblSlnPath = new System.Windows.Forms.Label();
            this.grpxClearProduct = new System.Windows.Forms.GroupBox();
            this.btnClearProduct = new System.Windows.Forms.Button();
            this.txtProductPath = new System.Windows.Forms.TextBox();
            this.lblProductPath = new System.Windows.Forms.Label();
            this.grpxDotfuscatorUpdater.SuspendLayout();
            this.grpxClearProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpxDotfuscatorUpdater
            // 
            this.grpxDotfuscatorUpdater.BackColor = System.Drawing.SystemColors.Control;
            this.grpxDotfuscatorUpdater.Controls.Add(this.btnUpdateDotfuscator);
            this.grpxDotfuscatorUpdater.Controls.Add(this.txtSlnPath);
            this.grpxDotfuscatorUpdater.Controls.Add(this.lblSlnPath);
            this.grpxDotfuscatorUpdater.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpxDotfuscatorUpdater.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpxDotfuscatorUpdater.Location = new System.Drawing.Point(1, 2);
            this.grpxDotfuscatorUpdater.Name = "grpxDotfuscatorUpdater";
            this.grpxDotfuscatorUpdater.Size = new System.Drawing.Size(527, 101);
            this.grpxDotfuscatorUpdater.TabIndex = 1;
            this.grpxDotfuscatorUpdater.TabStop = false;
            this.grpxDotfuscatorUpdater.Text = "根据当前解决方案.sln文件更新Dotfuscator.xml";
            // 
            // btnUpdateDotfuscator
            // 
            this.btnUpdateDotfuscator.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdateDotfuscator.Location = new System.Drawing.Point(438, 37);
            this.btnUpdateDotfuscator.Name = "btnUpdateDotfuscator";
            this.btnUpdateDotfuscator.Size = new System.Drawing.Size(87, 23);
            this.btnUpdateDotfuscator.TabIndex = 5;
            this.btnUpdateDotfuscator.Text = "开始更新";
            this.btnUpdateDotfuscator.UseVisualStyleBackColor = true;
            this.btnUpdateDotfuscator.Click += new System.EventHandler(this.btnUpdateDotfuscator_Click);
            // 
            // txtSlnPath
            // 
            this.txtSlnPath.AllowDrop = true;
            this.txtSlnPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSlnPath.Location = new System.Drawing.Point(12, 37);
            this.txtSlnPath.Multiline = true;
            this.txtSlnPath.Name = "txtSlnPath";
            this.txtSlnPath.Size = new System.Drawing.Size(421, 52);
            this.txtSlnPath.TabIndex = 1;
            this.txtSlnPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtSlnPath_DragEnter);
            // 
            // lblSlnPath
            // 
            this.lblSlnPath.AutoSize = true;
            this.lblSlnPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSlnPath.Location = new System.Drawing.Point(12, 21);
            this.lblSlnPath.Name = "lblSlnPath";
            this.lblSlnPath.Size = new System.Drawing.Size(77, 12);
            this.lblSlnPath.TabIndex = 0;
            this.lblSlnPath.Text = ".sln文件路径";
            // 
            // grpxClearProduct
            // 
            this.grpxClearProduct.Controls.Add(this.btnClearProduct);
            this.grpxClearProduct.Controls.Add(this.txtProductPath);
            this.grpxClearProduct.Controls.Add(this.lblProductPath);
            this.grpxClearProduct.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpxClearProduct.Location = new System.Drawing.Point(2, 113);
            this.grpxClearProduct.Name = "grpxClearProduct";
            this.grpxClearProduct.Size = new System.Drawing.Size(527, 97);
            this.grpxClearProduct.TabIndex = 2;
            this.grpxClearProduct.TabStop = false;
            this.grpxClearProduct.Text = "根据FileList从Product中获取干净的文件夹";
            // 
            // btnClearProduct
            // 
            this.btnClearProduct.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearProduct.Location = new System.Drawing.Point(439, 37);
            this.btnClearProduct.Name = "btnClearProduct";
            this.btnClearProduct.Size = new System.Drawing.Size(87, 23);
            this.btnClearProduct.TabIndex = 5;
            this.btnClearProduct.Text = "开始清理";
            this.btnClearProduct.UseVisualStyleBackColor = true;
            this.btnClearProduct.Click += new System.EventHandler(this.btnClearProduct_Click);
            // 
            // txtProductPath
            // 
            this.txtProductPath.AllowDrop = true;
            this.txtProductPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProductPath.Location = new System.Drawing.Point(12, 37);
            this.txtProductPath.Multiline = true;
            this.txtProductPath.Name = "txtProductPath";
            this.txtProductPath.Size = new System.Drawing.Size(421, 44);
            this.txtProductPath.TabIndex = 1;
            this.txtProductPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtProductPath_DragEnter);
            // 
            // lblProductPath
            // 
            this.lblProductPath.AutoSize = true;
            this.lblProductPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProductPath.Location = new System.Drawing.Point(12, 21);
            this.lblProductPath.Name = "lblProductPath";
            this.lblProductPath.Size = new System.Drawing.Size(71, 12);
            this.lblProductPath.TabIndex = 0;
            this.lblProductPath.Text = "Product路径";
            // 
            // FormSolutionMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 387);
            this.Controls.Add(this.grpxClearProduct);
            this.Controls.Add(this.grpxDotfuscatorUpdater);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSolutionMgr";
            this.Text = "解决方案工具";
            this.grpxDotfuscatorUpdater.ResumeLayout(false);
            this.grpxDotfuscatorUpdater.PerformLayout();
            this.grpxClearProduct.ResumeLayout(false);
            this.grpxClearProduct.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpxDotfuscatorUpdater;
        private System.Windows.Forms.TextBox txtSlnPath;
        private System.Windows.Forms.Label lblSlnPath;
        private System.Windows.Forms.Button btnUpdateDotfuscator;
        private System.Windows.Forms.GroupBox grpxClearProduct;
        private System.Windows.Forms.Button btnClearProduct;
        private System.Windows.Forms.TextBox txtProductPath;
        private System.Windows.Forms.Label lblProductPath;
    }
}

