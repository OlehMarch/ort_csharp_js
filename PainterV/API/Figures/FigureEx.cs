using Newtonsoft.Json;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Painter.Vector
{
    public class FigureEx
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float PenWidth { get; set; }
        public int Color { get; set; }
        public PointF[] Path { get; set; }
        public ShapeType ShapeType { get; set; }
    }
}
