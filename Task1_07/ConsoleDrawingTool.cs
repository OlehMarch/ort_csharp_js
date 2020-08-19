using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_07
{
    // all loops must start from 1 in this cases
    //i + j == 8 2d diagonal / all conditions in one if statement
    public static class ConsoleAsteriskDrawingTool
    {

        public static void DrawFilledRect()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    res += "*";
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawRect()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    if (j == 1 || j == 7 || i == 1 || i == 7)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawTriangleTopLeft()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    if (j == 1 || i == 1 || j + i == 8)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawTriangleTopRight()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    if (j == 7 || i == 1 || j == i)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawTriangleBottomLeft()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    if (j == 1 || i == 7 || j == i)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawTriangleBottomRight()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    if (j == 7 || i == 7 || j + i == 8)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawIsoscelesTriangleTop()
        {
            string res = "";

            for (int i = 1; i <= 4; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    if (i == 1 || j == i || j + i == 8)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawIsoscelesTriangleBottom()
        {
            string res = "";

            for (int i = 4; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    if (i == 7 || j == i || j + i == 8)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawIsoscelesTriangleLeft()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 4; ++j)
                {
                    if (j == 1 || j == i || j + i == 8)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawIsoscelesTriangleRight()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 4; j <= 7; ++j)
                {
                    if (j == 7 || j == i || j + i == 8)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawCross()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    if (j == i || j + i == 8)
                    {
                        res += "*";
                    }
                    else
                    {
                        res += " ";
                    }
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

    }

    public static class ConsoleNumericDrawingTool
    {
        public static void DrawNumrericRectTopAscending()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    res += i;
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawNumrericRectTopDescending()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    res += 8 - i;
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawNumrericRectLeftAscending()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    res += j;
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }

        public static void DrawNumrericRectLeftDescending()
        {
            string res = "";

            for (int i = 1; i <= 7; ++i)
            {
                for (int j = 1; j <= 7; ++j)
                {
                    res += 8 - j;
                }
                res += "\n";
            }

            Console.WriteLine(res);
        }
    }

}
