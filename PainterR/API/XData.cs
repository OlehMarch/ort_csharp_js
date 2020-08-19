using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public enum ShapeType : int
    {
        LINE = 0,
        MULTILINE = 1,
        ELLIPSE = 2,
        RECTANGLE = 3,
        CRECTANGLE = 4
    } 

    public sealed class XData
    {
        public XData()
        {
            LineColor = Color.Black;
            LineWidth = 1;
            PrevPoint = new Point();
            Type = ShapeType.MULTILINE;
        }

        public XData(ShapeType type) : base()
        {
            Type = type;
        }

        public Color LineColor { set; get; }
        public float LineWidth { set; get; }
        public Point PrevPoint { set; get; }
        public ShapeType Type { set; get; }
 
        public void addPosition(Point position)
        {
            PrevPoint = position;
        }
    }
}
