using PainterWPF.UserControls.VectorElements;
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

namespace PainterWPF.UserControls.Menu
{
    /// <summary>
    /// Логика взаимодействия для StatusBarVector.xaml
    /// </summary>
    public partial class StatusBarVector : UserControl
    {
        public StatusBarVector()
        {
            InitializeComponent();
        }

        public void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            CanvasVector Canvas = sender as CanvasVector;
            StatusBarItem_X.Content = "X:" + e.GetPosition((IInputElement)e.Source).X.ToString();
            StatusBarItem_Y.Content = "Y:" + e.GetPosition((IInputElement)e.Source).Y.ToString();
            if (Canvas.StackControl != null)
            {
                StatusBarItem_Color.Content = Canvas.StackControl.data.LineColor.ToString();
                StatusBarItem_PenWidth.Content = Canvas.StackControl.data.LineWidth.ToString();
                StatusBarItem_ShapeType.Content = Canvas.StackControl.data.Type.ToString();
            }
        }
    }
}
