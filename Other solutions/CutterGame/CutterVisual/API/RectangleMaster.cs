using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CutterVisual.API
{
    public class RectangleMaster
    {
        public RectangleMaster(List<Control> Rects)
        {
            addedElems = new List<Control>();
            elements = Rects;

            elements.Sort(new CompareControl<Control>());
        }


        private List<Control> elements;
        private List<Control> addedElems;
        public static int maxHeight;


        public List<Control> PackRectangles(Size canvasSize)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                int offsetWidth = 0;

                if (!CheckExistance(elements[i]))
                {
                    elements[i].Location = new Point(x, y);
                    addedElems.Add(elements[i]);

                    x = elements[i].Size.Width;
                    offsetWidth = canvasSize.Width - x;
                }
                else
                {
                    continue;
                }

                for (int j = i + 1; j < elements.Count; j++)
                {
                    if (offsetWidth >= elements[j].Size.Width)
                    {
                        if (!CheckExistance(elements[j]))
                        {
                            elements[j].Location = new Point(x, y);
                            addedElems.Add(elements[j]);

                            x += elements[j].Size.Width;
                            offsetWidth = canvasSize.Width - x;
                        }
                    }
                }

                y += elements[i].Size.Height;
                if (y > canvasSize.Height)
                {
                    throw new ArgumentOutOfRangeException();
                }
                x = 0;
            }

            maxHeight = y;
            addedElems.Clear();

            return elements;
        }

        private bool CheckExistance(Control rect)
        {
            return addedElems.Contains(rect);
        }

    }
}
