using PainterWPF.API;
using PainterWPF.UserControls.Menu;
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
using System.Windows.Shapes;

namespace PainterWPF.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для IODialog.xaml
    /// </summary>
    public partial class IODialog : Window
    {
        public IODialog(XCommand Cmd, TabControlVector tabControl = null)
        {
            InitializeComponent();

            this.cmd = Cmd;
            this.tabControlVector = tabControl;

            this.buttonSave.Click += new RoutedEventHandler(cmd.aSave.Action);
            this.buttonLoad.Click += new RoutedEventHandler(cmd.aLoad.Action);
        }

        public  XCommand cmd;
        public  TabControlVector tabControlVector;

        public void CreateTabPage(StatusBarVector statusBar)
        {
            if (tabControlVector != null && cmd.aLoad.fileName != null)
            {
                tabControlVector.tabControl.SelectedItem = tabControlVector.GetTabItem("NewPage");

                string tabName = cmd.aLoad.fileName.Remove(0, cmd.aLoad.fileName.LastIndexOf('\\') + 1);
                tabName = tabName.Remove(tabName.LastIndexOf('.'));
               
                TabItem newItem = new TabItem()
                {
                    Name = tabName,
                    Header = cmd.aLoad.fileName,
                    ContextMenu = tabControlVector.GetTabItem("NewPage").ContextMenu,
                };
                CanvasVector canvasVector = new CanvasVector()
                {
                    Name = newItem.Name + "_Canvas",
                    Focusable = true,
                    Margin = new Thickness(3),
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.DarkGray
                };
                canvasVector.SetCanvasMouseMoveEventHandler(statusBar);
                newItem.Content = canvasVector.canvas;

                tabControlVector.tabControl.Items.Add(newItem);
                TabControlVector.tabCanvases.Add(newItem.Header.ToString(), canvasVector);
                TabControlVector.index++;
                TabControlVector.nameLast = newItem.Header.ToString();
            }
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
