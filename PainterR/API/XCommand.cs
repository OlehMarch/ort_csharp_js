using Paint.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public class XCommand
    {
        public ActionColor ActColor { set; get; }
        public ActionWidth ActWidth { set; get; }
        public ActionType ActType { set; get; }
        public ActionIO ActIO { set; get; }

        public XCommand(Canvas canvas)
        {
            ActColor = new ActionColor();
            ActWidth = new ActionWidth();
            ActType = new ActionType();
            ActIO = new ActionIO(canvas);
        }
    }
}
