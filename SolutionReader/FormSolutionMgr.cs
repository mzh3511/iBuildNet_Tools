using System;
using System.IO;
using System.Windows.Forms;

namespace SolutionReader
{
    public partial class FormSolutionMgr : Form
    {
        public FormSolutionMgr()
        {
            InitializeComponent();
        }

        private void btnUpdateDotfuscator_Click(object sender, EventArgs e)
        {
            var updater = new DotfuscatorUpdater();
            if (!updater.Initialize(txtSlnPath.Text.Trim()))
                return;
            MessageBox.Show($"共需加密{updater.Update()}个文件");
        }
        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            var productPath = txtProductPath.Text.Trim();
            if (!Directory.Exists(productPath))
                return;
            var cleaner = new ProductCleaner();
            if (!cleaner.Initialize(productPath))
                return;
            var count = cleaner.Clean();
            MessageBox.Show($"共拷贝{count}个文件");
        }

        private void txtSlnPath_DragEnter(object sender, DragEventArgs e)
        {
            var fileArr = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fileArr == null || fileArr.Length != 1)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            var slnPath = fileArr[0];
            var slnExt = Path.GetExtension(slnPath);
            if (!File.Exists(slnPath) || string.IsNullOrWhiteSpace(slnExt) || slnExt.Equals(".sln", StringComparison.InvariantCultureIgnoreCase))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            txtSlnPath.Text = slnPath;
            e.Effect = DragDropEffects.Link;
        }

        private void txtProductPath_DragEnter(object sender, DragEventArgs e)
        {
            var fileArr = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fileArr == null || fileArr.Length != 1)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            var productPath = fileArr[0];
            if (!Directory.Exists(productPath))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            txtProductPath.Text = productPath;
            e.Effect = DragDropEffects.Link;
        }
    }
}
