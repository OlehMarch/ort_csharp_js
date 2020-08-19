using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace XMLInterpreter.WPF
{
    internal static class ControlHierarchyHandler
    {
        public static void AddControlToHierarchy()
        {
            if (SAX_Parser.CurrentControl[SAX_Parser.depthLevel].GetType() == typeof(TabItem))
            {
                (SAX_Parser.CurrentControl[SAX_Parser.depthLevel - 1] as TabControl).Items.Add(SAX_Parser.CurrentControl[SAX_Parser.depthLevel] as TabItem);
            }
            else
            {
                Type type = SAX_Parser.CurrentControl[SAX_Parser.depthLevel - 1].GetType();
                System.Windows.Thickness margin = new System.Windows.Thickness()
                {
                    Left = 0,
                    Top = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Top,
                    Right = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Right,
                    Bottom = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Bottom
                };

                if (type == typeof(Grid))
                {
                    (SAX_Parser.CurrentControl[SAX_Parser.depthLevel - 1] as Grid).Children.Add(SAX_Parser.CurrentControl[SAX_Parser.depthLevel]);
                }
                else if (type == typeof(StackPanel))
                {
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin = new System.Windows.Thickness()
                    {
                        Left = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Left,
                        Top = 0,
                        Right = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Right,
                        Bottom = SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin.Bottom
                    };
                    (SAX_Parser.CurrentControl[SAX_Parser.depthLevel - 1] as StackPanel).Children.Add(SAX_Parser.CurrentControl[SAX_Parser.depthLevel]);
                }
                else if (type == typeof(Menu))
                {
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin = margin;
                    (SAX_Parser.CurrentControl[SAX_Parser.depthLevel - 1] as Menu).Items.Add(SAX_Parser.CurrentControl[SAX_Parser.depthLevel]);
                }
                else if (type == typeof(ToolBar))
                {
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin = margin;
                    (SAX_Parser.CurrentControl[SAX_Parser.depthLevel - 1] as ToolBar).Items.Add(SAX_Parser.CurrentControl[SAX_Parser.depthLevel]);
                }
                else if (type == typeof(StatusBar))
                {
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Margin = margin;
                    (SAX_Parser.CurrentControl[SAX_Parser.depthLevel - 1] as StatusBar).Items.Add(SAX_Parser.CurrentControl[SAX_Parser.depthLevel]);
                }
                else if (type == typeof(TabItem))
                {
                    (SAX_Parser.CurrentControl[SAX_Parser.depthLevel - 1] as TabItem).Content = SAX_Parser.CurrentControl[SAX_Parser.depthLevel];
                }
                else
                {
                    throw new ArgumentException();
                }
            } 
        }

    }
}
