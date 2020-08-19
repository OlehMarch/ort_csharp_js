using PainterWPF.API;
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
    /// Логика взаимодействия для ShapeTypeDialog.xaml
    /// </summary>
    public partial class ShapeTypeDialog : Window
    {
        public ShapeTypeDialog()
        {
            InitializeComponent();
        }

        private ShapeType type;

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void CB_ShapeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CB_ShapeType.SelectedIndex)
            {
                case 0:
                    type = ShapeType.LINE;
                    break;

                case 1:
                    type = ShapeType.MULTILINE;
                    break;

                case 2:
                    type = ShapeType.ELLIPSE;
                    break;

                case 3:
                    type = ShapeType.RECTANGLE;
                    break;

                case 4:
                    type = ShapeType.CRECTANGLE;
                    break;
            }
        }

        public ShapeType GetShapeType()
        {
            return type;
        }

    }
}
