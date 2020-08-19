using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CutterGame
{
    public class Rectangle : IComparable
    {
        public Point Location;
        public Size Size;

        public Rectangle()
        {
            Location = new Point(0, 0);
            Size = new Size(0, 0);
        }

        public Rectangle(Point Location, Size Size)
        {
            this.Location = Location;
            this.Size = Size;
        }

        public int CompareTo(object obj)
        {
            int res = 0;
            Rectangle rect = obj as Rectangle;

            if (this.Size.Height > rect.Size.Height)
            {
                res = -1;
            }
            else if (this.Size.Height < rect.Size.Height)
            {
                res = 1;
            }
            else
            {
                res = 0;
            }

            return res;
        }

        public void SetLocation(int x, int y)
        {
            Location = new Point(x, y);
        }

    }
}
