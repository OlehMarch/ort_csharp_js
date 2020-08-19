using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public class ActionColor : IAction
    {
        public void Action(object sender, EventArgs e)
        {
            MyColorDialog dlg = new MyColorDialog();
            dlg.SetColor();
        }
    }
}
