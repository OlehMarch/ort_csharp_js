using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public static class DrawingApi
    {
        public static XData xData;

        public static void SetUp(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        public static void Render(Graphics g, Point p1, Point p2)
        {
            switch (xData.Type)
            {
                case ShapeType.ELLIPSE:
                    g.DrawEllipse(new Pen(xData.LineColor, xData.LineWidth), new RectangleF(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y));
                    break;

                case ShapeType.RECTANGLE:
                    g.DrawRectangle(new Pen(xData.LineColor, xData.LineWidth), new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y));
                    break;

                case ShapeType.CRECTANGLE:
                    DrawCurvedRect(g, p1, p2);
                    break;

                default:
                    g.DrawLine(new Pen(xData.LineColor, xData.LineWidth), p1, p2);
                    break;
            }
        }
        
        private static void DrawCurvedRect(Graphics g, Point p1, Point p2)
        {
            Point pStart = Point.Empty;
            Point pEnd = Point.Empty;
            if (p1.X < p2.X || p1.Y < p2.Y)
            {
                pStart = p1;
            }
            else
            {
                pStart = p2;
            }
            if (pStart == p1)
            {
                pEnd = p2;
            }
            else
            {
                pEnd = p1;
            }
            g.DrawPath(new Pen(xData.LineColor, xData.LineWidth),
                CurvedRect(new Rectangle(pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y), 10));
        }

        private static GraphicsPath CurvedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

    }
}
