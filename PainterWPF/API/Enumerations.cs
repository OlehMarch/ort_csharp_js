using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainterWPF.API
{
    public enum ResizeLocation : int
    {
        LeftTop = 1,
        MiddleTop = 2,
        RightTop = 3,
        LeftMiddle = 4,
        RightMiddle = 5,
        LeftBottom = 6,
        MiddleBottom = 7,
        RightBottom = 8
    }

    public enum ShapeType : int
    {
        LINE = 0,
        MULTILINE = 1,
        ELLIPSE = 2,
        RECTANGLE = 3,
        CRECTANGLE = 4
    }
}
