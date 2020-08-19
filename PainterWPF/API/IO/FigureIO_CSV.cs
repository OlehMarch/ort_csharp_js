using PainterWPF.API.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
using System.IO;
using System.Windows;

namespace PainterWPF.API.IO
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

        public override List<UIElement> Read()
        {
            StreamReader fs = new StreamReader(PathToFile);
            string csvString = fs.ReadToEnd();
            fs.Dispose();

            List<Figure> figures = CsvSerializer.DeserializeFromString<List<Figure>>(csvString);

            return CreateControlList(figures);
        }

        public override void Write(List<UIElement> controls)
        {
            StreamWriter fs = new StreamWriter(PathToFile);
            fs.Write(CsvSerializer.SerializeToCsv(GetListOfFigures(controls)));
            fs.Dispose();
        }

    }
}
