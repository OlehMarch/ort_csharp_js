using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;

namespace BubblePaint
{
    public sealed class RectangleBorder
    {
        public Vector2 LeftStart {set;get;}
        public Vector2 LeftEnd {set;get;}
        public Vector2 RightStart {set;get;}
        public Vector2 RightEnd {set;get;}
        public Vector2 TopStart {set;get;}
        public Vector2 TopEnd {set;get;}
        public Vector2 BottomStart {set;get;}
        public Vector2 BottomEnd { set; get; }

        private static int offset = 15;

        public RectangleBorder(Control pb)
        {
            LeftStart = new Vector2(0 - offset, 0 - offset);
            LeftEnd = new Vector2(0 - offset, pb.Height - offset);
            RightStart = new Vector2(pb.Width - offset, 0 - offset);
            RightEnd = new Vector2(pb.Width - offset, pb.Height - offset);
            TopStart = new Vector2(0 - offset, 0 - offset);
            TopEnd = new Vector2(pb.Width - offset, 0 - offset);
            BottomStart = new Vector2(0 - offset, pb.Height - offset);
            BottomEnd = new Vector2(pb.Width - offset, pb.Height - offset);
        }
    }
}
