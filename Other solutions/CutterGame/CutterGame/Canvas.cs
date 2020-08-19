using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutterGame
{
    public class Canvas
    {
        public Point Location;
        public Size Size;
        public List<Rectangle> Rects;

        public Canvas()
        {
            Size = new Size(200, 400);
            Rects = new List<Rectangle>();
        }

        public Canvas(Size Size)
        {
            this.Size = Size;
            Rects = new List<Rectangle>();
        }

        public void Add(Rectangle rect)
        {
            Rects.Add(rect);
        }

        public void AddRange(IEnumerable<Rectangle> rects)
        {
            this.Rects.AddRange(rects);
        }

        public float GetPackingCoefficient()
        {
            float result = 0;
            int maxHeight = RectangleMaster.maxHeight;

            result = (float)(this.Size.Height - maxHeight) / (float)this.Size.Height;

            return result;
        }

    }
}
