using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CutterGame
{
    public class RectangleMaster
    {
        public RectangleMaster(List<Rectangle> Rects)
        {
            addedElems = new List<Rectangle>();
            elements = Rects;

            elements.Sort();
        }


        private List<Rectangle> elements;
        private List<Rectangle> addedElems;
        public static int maxHeight;


        public List<Rectangle> PackRectangles(Size canvasSize)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                int offsetWidth = 0;

                if (!CheckExistance(elements[i]))
                {
                    elements[i].SetLocation(x, y);
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
                            elements[j].SetLocation(x, y);
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

        private bool CheckExistance(Rectangle rect)
        {
            return addedElems.Contains(rect);
        }

    }
}
