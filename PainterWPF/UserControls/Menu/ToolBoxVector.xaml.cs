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
    /// Логика взаимодействия для ToolBoxVector.xaml
    /// </summary>
    public partial class ToolBoxVector : UserControl
    {
        public ToolBoxVector()
        {
            InitializeComponent();
        }

        public void ToolBoxSetUp()
        {
            this.ToolBar_Color.Click += new RoutedEventHandler(cmd.aColor.Action);
            this.ToolBar_PenWidth.Click += new RoutedEventHandler(cmd.aWidth.Action);
            this.ToolBar_ShapeType.Click += new RoutedEventHandler(cmd.aType.Action);
        }

        public XCommand cmd;
        public StatusBarVector statusBar;
        public TabControlVector tabControlVector;

        private void ToolBar_SaveLoad_Click(object sender, RoutedEventArgs e)
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
