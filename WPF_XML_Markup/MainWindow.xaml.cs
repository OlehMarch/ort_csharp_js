using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_XML_Markup
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Generate GUI
            XMLInterpreter.WPF.GUIGenarator.PathToLayout = R.Layout.painter;
            this.grid.Children.Add(XMLInterpreter.WPF.GUIGenarator.GetMemento());

            foreach (FrameworkElement item in this.grid.Children)
            {
                if (item.Name == "main_panel")
                {
                    this.Width = (item as Grid).Width + 16;
                    this.Height = (item as Grid).Height + 23 + 16;
                }
            }

            button.Visibility = Visibility.Collapsed;
        }
    }

    internal static class R
    {
        public static class Layout
        {
            public const string calculator = @"D:\Projects\CSharpPrograms\ORT\Resources\calculator.xml";
            public const string painter = @"D:\Projects\CSharpPrograms\ORT\Resources\painter.xml";
        }
    }
}
