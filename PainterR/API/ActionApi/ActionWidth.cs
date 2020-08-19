using Paint.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public class ActionWidth : IAction
    {
        public void Action(object sender, EventArgs e)
        {
            WidthDialog dlg = new WidthDialog();
            try
            {
                dlg.ShowDialog();
                DrawingApi.xData.LineWidth = Convert.ToSingle(dlg.GetWidth());
            }
            finally
            {
                dlg.Dispose();
            }
        }
    }
}
