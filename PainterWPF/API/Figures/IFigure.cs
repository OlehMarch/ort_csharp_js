using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PainterWPF.API.Figures
{
    public interface IFigure
    {
        Thickness Bounds { get; set; }
        float PenWidth { get; set; }
        byte[] Color { get; set; }
        ShapeType ShapeType { get; set; }
    }
}
