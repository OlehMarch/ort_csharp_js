using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Painter.UserControls.VectorElements.Figures;
using CsvHelper;

namespace Painter.Vector
{
    public class FigureIO_CSV : FigureIO
    {
        public FigureIO_CSV()
        {
            PathToFile = "";
        }
        public FigureIO_CSV(string path)
        {
            PathToFile = path;
        }

        public override List<Control> Read()
        {
            StreamReader fs = new StreamReader(PathToFile);

            var reader = new CsvReader(fs);
            List<FigureEx> figures = reader.GetRecords<FigureEx>().ToList();
            
            fs.Dispose();
            return CreateControlList(FigureExToFigure(figures));
        }

        public override void Write(List<Control> controls)
        {
            StreamWriter fs = new StreamWriter(PathToFile);
            var writer = new CsvWriter(fs);
            writer.WriteHeader<FigureEx>();
            writer.WriteRecords(FigureToFigureEx(GetListOfFigures(controls)));
            fs.Dispose();
        }

        private List<FigureEx> FigureToFigureEx(List<Figure> figures)
        {
            List<FigureEx> fEx = new List<FigureEx>();

            foreach (var item in figures)
            {
                fEx.Add(
                    new FigureEx()
                    {
                        X = item.Bounds.X,
                        Y = item.Bounds.Y,
                        Width = item.Bounds.Width,
                        Height = item.Bounds.Height,
                        Color = item.Color,
                        PenWidth = item.PenWidth,
                        ShapeType = item.ShapeType,
                        Path = item.Path
                    }
                );
            }

            return fEx;
        }

        private List<Figure> FigureExToFigure(List<FigureEx> figures)
        {
            List<Figure> f = new List<Figure>();

            foreach (var item in figures)
            {
                f.Add(
                    new Figure()
                    {
                        Bounds = new System.Drawing.Rectangle(item.X, item.Y, item.Width, item.Height),
                        Color = item.Color,
                        PenWidth = item.PenWidth,
                        ShapeType = item.ShapeType,
                        Path = item.Path
                    }
                );
            }

            return f;
        }

    }
}
