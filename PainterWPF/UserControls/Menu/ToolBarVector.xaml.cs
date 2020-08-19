using PainterWPF.API;
using PainterWPF.Dialogs;
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
    /// Логика взаимодействия для ToolBarVector.xaml
    /// </summary>
    public partial class ToolBarVector : UserControl
    {
        public ToolBarVector()
        {
            InitializeComponent();
        }

        public void ToolBarItemSetUp()
        {
            this.ToolBarItem_Color.Click += new RoutedEventHandler(cmd.aColor.Action);
            this.ToolBarItem_PenWidth.Click += new RoutedEventHandler(cmd.aWidth.Action);
            this.ToolBarItem_ShapeType.Click += new RoutedEventHandler(cmd.aType.Action);
        }

        public XCommand cmd;
        public StatusBarVector statusBar;
        public TabControlVector tabControlVector;

        private void ToolBarItem_SaveLoad_Click(object sender, RoutedEventArgs e)
        {
            IODialog dlg = new IODialog(cmd, tabControlVector);
            dlg.ShowDialog();
            if (dlg.DialogResult == true)
            {
                dlg.CreateTabPage(statusBar);
                ActionLoad.Draw(ActionLoad.elems, cmd);
            }
        }
    }
}
