using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_07
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleAsteriskDrawingTool.DrawFilledRect();
            ConsoleAsteriskDrawingTool.DrawRect();
            ConsoleAsteriskDrawingTool.DrawTriangleTopLeft();
            ConsoleAsteriskDrawingTool.DrawTriangleTopRight();
            ConsoleAsteriskDrawingTool.DrawTriangleBottomLeft();
            ConsoleAsteriskDrawingTool.DrawTriangleBottomRight();
            ConsoleAsteriskDrawingTool.DrawIsoscelesTriangleTop();
            ConsoleAsteriskDrawingTool.DrawIsoscelesTriangleBottom();
            ConsoleAsteriskDrawingTool.DrawIsoscelesTriangleLeft();
            ConsoleAsteriskDrawingTool.DrawIsoscelesTriangleRight();
            ConsoleAsteriskDrawingTool.DrawCross();

            ConsoleNumericDrawingTool.DrawNumrericRectTopAscending();
            ConsoleNumericDrawingTool.DrawNumrericRectTopDescending();
            ConsoleNumericDrawingTool.DrawNumrericRectLeftAscending();
            ConsoleNumericDrawingTool.DrawNumrericRectLeftDescending();

            Console.ReadKey();
        }
    }
}
