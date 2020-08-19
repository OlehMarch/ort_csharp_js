using PainterWPF.API.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using YamlDotNet.Serialization;
using System.Windows;

namespace PainterWPF.API.IO
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


        public override List<UIElement> Read()
        {
            Deserializer serializer = new Deserializer();
            StreamReader fs = new StreamReader(PathToFile);
            string ymlString = fs.ReadToEnd();
            fs.Dispose();

            List<Figure> figures = serializer.Deserialize<List<Figure>>(ymlString);

            return CreateControlList(figures);
        }

        public override void Write(List<UIElement> controls)
        {
            Serializer serializer = new Serializer();
            StreamWriter fs = new StreamWriter(PathToFile);
            fs.Write(serializer.Serialize(GetListOfFigures(controls)));
            fs.Dispose();
        }

    }
}
