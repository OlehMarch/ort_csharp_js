using PainterWPF.API.Figures;
using PainterWPF.UserControls.VectorElements.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PainterWPF.API.IO
{
    public abstract class FigureIO : IFigureIO
    {
        public string PathToFile { get; set; }

        public abstract List<UIElement> Read();
        public abstract void Write(List<UIElement> controls);

        #region Get list of figures
        protected List<Figure> GetListOfFigures(List<UIElement> controls)
        {
            List<Figure> figures = new List<Figure>();

            foreach (var item in controls)
            {
                SimpleFigures sf = (SimpleFigures)item;
                Figure f = new Figure();
                f.Bounds = sf.Margin;
                f.PenWidth = sf.data.LineWidth;
                f.Color = new byte[4] { sf.data.LineColor.A, sf.data.LineColor.R, sf.data.LineColor.G, sf.data.LineColor.B };
                f.Path = sf.data.Path.ToArray();
                f.ShapeType = sf.data.Type;
                figures.Add(f);
            }

            return figures;
        }
        #endregion

        #region Set list of controls
        protected List<UIElement> CreateControlList(List<Figure> figure)
        {
            List<UIElement> controls = new List<UIElement>();
            if (figure != null)
            {
                foreach (var item in figure)
                {
                    XData data = new XData();
                    data.LineColor = Color.FromArgb(item.Color[0], item.Color[1], item.Color[2], item.Color[3]);
                    data.LineWidth = item.PenWidth;
                    data.Type = item.ShapeType;
                    if (item.Path != null)
                    {
                        data.Path = item.Path.ToList();
                    }
                    controls.Add(new SimpleFigures(item.Bounds, data));
                }
            }
            return controls;
        }
        #endregion

    }
}
