using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PainterWPF.API
{
    public sealed class XData : ICloneable
    {
        public XData()
        {
            LineColor = Colors.Black;
            LineWidth = 1;
            PrevPoint = new Point();
            Type = ShapeType.MULTILINE;
            Path = new List<Point>();
        }

        public XData(ShapeType type) : base()
        {
            Type = type;
        }

        public Color LineColor { set; get; }
        public float LineWidth { set; get; }
        public Point PrevPoint { set; get; }
        public ShapeType Type { set; get; }
        public List<Point> Path { set; get; }

        public void AddPosition(Point position)
        {
            if (Type == ShapeType.MULTILINE)
            {
                Path.Add(position);
            }
            PrevPoint = position;
        }

        public object Clone()
        {
            XData data = new XData();
            data.LineColor = this.LineColor;
            data.LineWidth = this.LineWidth;
            data.Type = this.Type;
            data.Path = this.Path;
            return data;
        }
    }
}
