using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CutterGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Canvas canvas = new Canvas();
            canvas.Add(new Rectangle(new Point(0, 0), new Size(100, 50)));
            canvas.Add(new Rectangle(new Point(0, 0), new Size(140, 10)));
            canvas.Add(new Rectangle(new Point(0, 0), new Size(40, 80)));
            canvas.Add(new Rectangle(new Point(0, 0), new Size(70, 40)));
            canvas.Add(new Rectangle(new Point(0, 0), new Size(10, 70)));
            canvas.Add(new Rectangle(new Point(0, 0), new Size(200, 70)));
            canvas.Add(new Rectangle(new Point(0, 0), new Size(200, 70)));
            canvas.Add(new Rectangle(new Point(0, 0), new Size(200, 70)));

            RectangleMaster master = new RectangleMaster(canvas.Rects);
            master.PackRectangles(canvas.Size);
            Console.WriteLine(canvas.GetPackingCoefficient());
            Console.ReadKey();
        }

    }
}
