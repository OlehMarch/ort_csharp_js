using System;
using System.Windows;
using System.Windows.Controls;

namespace XMLInterpreter.WPF
{
    public static class ControlDataHandler
    {
        public static void InsertData(string tag, string innerText)
        {
            if (innerText == "")
            {
                return;
            }

            switch (tag)
            {
                case "id":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Name = innerText;
                    break;

                case "value":
                    if (SAX_Parser.CurrentControl[SAX_Parser.depthLevel].GetType() == typeof(Button))
                    {
                        (SAX_Parser.CurrentControl[SAX_Parser.depthLevel] as Button).Content = innerText;
                    }
                    else if (SAX_Parser.CurrentControl[SAX_Parser.depthLevel].GetType() == typeof(Label))
                    {
                        (SAX_Parser.CurrentControl[SAX_Parser.depthLevel] as Label).Content = innerText;
                    }
                    else if (SAX_Parser.CurrentControl[SAX_Parser.depthLevel].GetType() == typeof(TabItem))
                    {
                        (SAX_Parser.CurrentControl[SAX_Parser.depthLevel] as TabItem).Header = innerText;
                    }
                    break;

                case "x":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin = new Thickness()
                    {
                        Left = int.Parse(innerText),
                        Top = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Top,
                        Right = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Right,
                        Bottom = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Bottom
                    };
                    break;

                case "y":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin = new Thickness()
                    {
                        Left = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Left,
                        Top = int.Parse(innerText),
                        Right = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Right,
                        Bottom = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Bottom
                    };
                    break;

                case "width":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Width = int.Parse(innerText);
                    break;

                case "height":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Height = int.Parse(innerText);
                    break;

                default:
                    throw new ArgumentException();
            }
        }

    }
}
