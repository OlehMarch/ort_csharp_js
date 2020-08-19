using Paint.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public class ActionType : IAction
    {
        public void Action(object sender, EventArgs e)
        {
            ShapeTypeDialog dlg = new ShapeTypeDialog();
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
