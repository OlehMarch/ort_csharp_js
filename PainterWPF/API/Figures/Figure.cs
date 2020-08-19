using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace PainterWPF.API.Figures
{
    [JsonObject("Figure")]
    [Serializable]
    public class Figure : IFigure
    {
        [JsonProperty("ClientRect")]
        [XmlElement("ClientRect")]
        public Thickness Bounds { get; set; }
        [JsonProperty("PenWidth")]
        [XmlElement("PenWidth")]
        public float PenWidth { get; set; }
        [JsonProperty("Color")]
        [XmlElement("Color")]
        public byte[] Color { get; set; }
        [JsonProperty("Path")]
        [XmlElement("Path")]
        public Point[] Path { get; set; }
        [JsonProperty("ShapeType")]
        [XmlElement("ShapeType")]
        public ShapeType ShapeType { get; set; }
    }
}
