using System.IO;
using System.Windows;

namespace XMLInterpreter.WPF
{
    public static class GUIGenarator
    {
        public static string PathToLayout { get; set; }

        private static void GenerateLayout()
        {
            StreamReader fs = new StreamReader(PathToLayout);

            while (!fs.EndOfStream)
            {
                string currLine = fs.ReadLine().TrimStart();

                if (currLine == "")
                {
                    continue;
                }

                if (currLine[currLine.IndexOf("<") + 1] != '/' && currLine.IndexOf("<") == currLine.LastIndexOf("<") )
                {
                    SAX_Parser.SAX_Parser_ElementStart(fs, currLine);
                }
                else if (currLine.StartsWith("</") && currLine.IndexOf("</") == currLine.LastIndexOf("</"))
                {
                    SAX_Parser.SAX_Parser_ElementEnd(fs, currLine);
                }
                else
                {
                    SAX_Parser.SAX_Parser_ElementContext(fs, currLine);
                }
            }

            fs.Dispose();
        }

        public static UIElement GetMemento()
        {
            GenerateLayout();
            return ControlHolder.Container;
        }

    }
}
