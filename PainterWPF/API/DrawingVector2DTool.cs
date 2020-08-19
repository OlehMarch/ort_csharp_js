using PainterWPF.UserControls.VectorElements;
using PainterWPF.UserControls.VectorElements.Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PainterWPF.API
{
    public static class DrawingVector2DTool
    {
        public static List<UIElement> figures;

        static DrawingVector2DTool()
        {
            figures = new List<UIElement>();
        }

        public static UIElement Render(CanvasVector ownerControl, Thickness rect, XData data, XCommand cmd)
        {
            SimpleFigures result = new SimpleFigures(rect, data);
            result.ContextMenuSetUp(cmd);
            ownerControl.canvas.Children.Add(result);
            figures.Add(result);
            
            return result;
        }

    }
}
