using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFDialogs
{
    public partial class DialogsForm : Form
    {
        public DialogsForm()
        {
            InitializeComponent();
        }

        private void B_ColorDialog_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
        }

        private void B_FileBrowserDialog_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
        }

        private void B_FontDialog_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
        }

        private void B_OpenFileDialog_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void B_SaveFileDialog_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void B_PageSetupDialog_Click(object sender, EventArgs e)
        {
            PageSetupDialog dlg = new PageSetupDialog();
            dlg.Document = new PrintDocument();
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void B_PrintDialog_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void B_PrintPreviewDialog_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void B_ThreadExceptionDialog_Click(object sender, EventArgs e)
        {
            ThreadExceptionDialog dlg = new ThreadExceptionDialog(new ArgumentException());
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void B_MessageBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is message box!", "Message Box", MessageBoxButtons.OK);
        }

        private void B_CustomDialog_Click(object sender, EventArgs e)
        {
            Dialog dlg = new Dialog();
            dlg.ShowDialog();
            dlg.Dispose();
        }
    }
}
