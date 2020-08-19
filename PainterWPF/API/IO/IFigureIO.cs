using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PainterWPF.API.IO
{
    public interface IFigureIO
    {
        string PathToFile { get; set; }

        List<UIElement> Read();
        void Write(List<UIElement> controls);
    }
}
