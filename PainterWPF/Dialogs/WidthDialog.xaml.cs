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
using System.Windows.Shapes;

namespace PainterWPF.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для WidthDialog.xaml
    /// </summary>
    public partial class WidthDialog : Window
    {
        public WidthDialog()
        {
            InitializeComponent();
        }

        private void sliderWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            L_Header.Content = "Pen Width: " + (int)e.NewValue;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public float GetWidth()
        {
            return (float)this.sliderWidth.Value;
        }

    }
}
