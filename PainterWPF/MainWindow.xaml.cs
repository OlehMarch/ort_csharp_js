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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PainterWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            cmd = new XCommand();
            InitializeComponent();

            cmd.canvasVector = tabControlVector.canvasVector;
            tabControlVector.canvasVector.cmd = cmd;
            tabControlVector.canvasVector.SetCanvasMouseMoveEventHandler(statusBarVector);

            tabControlVector.cmd = cmd;
            toolBoxVector.cmd = cmd;
            toolBarVector.cmd = cmd;
            mainMenuVector.cmd = cmd;
            toolBoxVector.statusBar = statusBarVector;
            toolBarVector.statusBar = statusBarVector;
            mainMenuVector.statusBar = statusBarVector;
            toolBoxVector.tabControlVector = tabControlVector;
            toolBarVector.tabControlVector = tabControlVector;
            mainMenuVector.tabControlVector = tabControlVector;

            toolBoxVector.ToolBoxSetUp();
            toolBarVector.ToolBarItemSetUp();
            mainMenuVector.MenuItemSetUp();

            tabControlVector.mainMenu = mainMenuVector;
            tabControlVector.MenuItemWindowSetUp();
        }

        private XCommand cmd;
    }
}
