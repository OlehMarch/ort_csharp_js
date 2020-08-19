using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutterVisual.API
{
    public class Canvas
    {
        public Size Size;
        public List<Control> Rects;

        public Canvas()
        {
            Size = new Size();
            Rects = new List<Control>();
        }

        public Canvas(Size Size)
        {
            this.Size = Size;
            Rects = new List<Control>();
        }

        public void Add(Control rect)
        {
            Rects.Add(rect);
        }

        public void AddRange(IEnumerable<Control> rects)
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
