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
    /// Логика взаимодействия для MainMenuVector.xaml
    /// </summary>
    public partial class MainMenuVector : UserControl
    {
        public MainMenuVector()
        {
            InitializeComponent();
        }

        public void MenuItemSetUp()
        {
            this.MenuItem_Color.Click += new RoutedEventHandler(cmd.aColor.Action);
            this.MenuItem_PenWidth.Click += new RoutedEventHandler(cmd.aWidth.Action);
            this.MenuItem_ShapeType.Click += new RoutedEventHandler(cmd.aType.Action);
        }

        public XCommand cmd;
        public StatusBarVector statusBar;
        public TabControlVector tabControlVector;

        private void MenuItem_File_Click(object sender, RoutedEventArgs e)
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
