using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutterVisual.API
{
    public class FlowLayoutPackage
    {
        private int maxHeight = 0;

        public IEnumerable<Control> Pack(Canvas canvas)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Size = canvas.Size;
            panel.Controls.AddRange(canvas.Rects.ToArray());

            List<Control> controls = new List<Control>();
            int y = -1;
            int height = 0;
            foreach (Control item in panel.Controls)
            {
                controls.Add(
                    new Control()
                    {
                        BackColor = item.BackColor,
                        Location = item.Location,
                        Size = item.Size,
                        Margin = new Padding(0),
                        Padding = new Padding(0)
                    }
                );
                if (item.Location.Y > y)
                {
                    y = item.Location.Y;
                    height = 0;
                }
                if (item.Size.Height > height)
                {
                    height = item.Size.Height;
                }
            }

            maxHeight = y + height;

            return controls;
        }

        public float GetPackingCoefficient(float canvasSizeHeight)
        {
            return (canvasSizeHeight - maxHeight) / canvasSizeHeight;
        }

    }
}
