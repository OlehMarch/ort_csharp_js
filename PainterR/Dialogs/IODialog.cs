using Paint.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.Dialogs
{
    public partial class IODialog : Form
    {
        public IODialog()
        {
            InitializeComponent();
        }

        public IODialog(Canvas canvas) : this()
        {
            this.canvas = canvas;
        }

        private Canvas canvas;

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sFile = new SaveFileDialog();
            try
            {
                sFile.ShowDialog();
                this.canvas.SaveToFile(sFile.FileName);
            }
            finally
            {
                sFile.Dispose();
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            try
            {
                oFile.ShowDialog();
                this.canvas.LoadFromFile(oFile.FileName);
            }
            finally
            {
                oFile.Dispose();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox obj = sender as ComboBox;
            this.canvas.SelectIOFormat(obj.SelectedIndex);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
