using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class MyColorDialog
    {
        public void SetColor()
        {
            ColorDialog dlg = new ColorDialog();
            try
            {
                dlg.ShowDialog();
                DrawingApi.xData.LineColor = dlg.Color;
            }
            finally
            {
                dlg.Dispose();
            }
        }
    }
}
