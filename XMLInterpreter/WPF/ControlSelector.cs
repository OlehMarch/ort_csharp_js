using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace XMLInterpreter.WPF
{
    internal static class ControlSelector
    {
        public static FrameworkElement ControlCreation(string type)
        {
            FrameworkElement control = null;

            switch (type)
            {
                case "Panel":
                    control = new Grid();
                    break;
                case "Menu":
                    control = new Menu();
                    break;
                case "ToolBar":
                    control = new ToolBar();
                    break;
                case "ToolBox":
                    control = new StackPanel();
                    break;
                case "StatusBar":
                    control = new StatusBar();
                    break;
                case "TabControl":
                    control = new TabControl();
                    break;
                case "TabPage":
                    control = new TabItem();
                    break;
                case "TextBox":
                    control = new TextBox();
                    break;
                case "Button":
                    control = new Button();
                    break;
                case "Label":
                    control = new Label();
                    break;
                default:
                    throw new ArgumentException();
            }

            return control;
        }

    }
}
