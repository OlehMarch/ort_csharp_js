using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using Painter.UserControls.VectorElements.Figures;
using YamlDotNet.Serialization;

namespace Painter.Vector
{
    public class FigureIO_YML : FigureIO
    {
        public FigureIO_YML()
        {
            PathToFile = "";
        }
        public FigureIO_YML(string path)
        {
            PathToFile = path;
        }


        public override List<Control> Read()
        {
            StreamReader fs = new StreamReader(PathToFile);
            Deserializer serializer = new Deserializer();

            List<FigureEx> figures = serializer.Deserialize<List<FigureEx>>(fs);

            fs.Close();
            fs.Dispose();
            return CreateControlList(FigureExToFigure(figures));
        }

        public override void Write(List<Control> controls)
        {
            Serializer serializer = new Serializer();
            StreamWriter fs = new StreamWriter(PathToFile);
            serializer.Serialize(fs, FigureToFigureEx(GetListOfFigures(controls)));
            fs.Close();
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
