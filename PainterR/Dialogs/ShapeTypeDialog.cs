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
    public partial class ShapeTypeDialog : Form
    {
        public ShapeTypeDialog()
        {
            InitializeComponent();
        }

        private void CB_ShapeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CB_ShapeType.SelectedIndex)
            {
                case 0:
                    DrawingApi.xData.Type = ShapeType.LINE;
                    break;

                case 1:
                    DrawingApi.xData.Type = ShapeType.MULTILINE;
                    break;

                case 2:
                    DrawingApi.xData.Type = ShapeType.ELLIPSE;
                    break;

                case 3:
                    DrawingApi.xData.Type = ShapeType.RECTANGLE;
                    break;

                case 4:
                    DrawingApi.xData.Type = ShapeType.CRECTANGLE;
                    break;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
