using Paint.Dialogs;
using Paint.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public class ActionIO : IAction
    {
        public Canvas canvas { set; get; }

        public ActionIO(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void Action(object sender, EventArgs e)
        {
            IODialog dlg = new IODialog(canvas);
            try
            {
                dlg.ShowDialog();
            }
            finally
            {
                dlg.Dispose();
            }
        }
    }
}
