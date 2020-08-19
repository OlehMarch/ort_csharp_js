using PainterWPF.API;
using PainterWPF.UserControls.Menu;
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

namespace PainterWPF.UserControls.VectorElements
{
    /// <summary>
    /// Логика взаимодействия для TabControlVector.xaml
    /// </summary>
    public partial class TabControlVector : UserControl
    {
        bool delete = false;
        public TabControlVector()
        {
            InitializeComponent();
            tabCanvases = new Dictionary<string, CanvasVector>();
            tabCanvases.Add("NewPage", canvasVector);

            ContextMenu_Close.Click += ContextMenu_Close_Click;
        }


        public XCommand cmd;
        public MainMenuVector mainMenu;
        public static Dictionary<string, CanvasVector> tabCanvases;
        public static int index = 0;
        public static string nameLast;

        public void MenuItemWindowSetUp()
        {
            mainMenu.MenuItem_Window.MouseEnter += MainMenu_Window_MouseEnter;
        }

        private void ContextMenu_Close_Click(object sender, RoutedEventArgs e)
        {
            if ((tabControl.SelectedItem as TabItem).Name != "NewPage")
            {
                delete = true;

                string name  = (tabControl.SelectedItem as TabItem).Header.ToString();
                tabCanvases.Remove(name);
                tabControl.Items.Remove(tabControl.SelectedItem);
                tabControl.SelectedItem = tabControl.Items[0];
            }
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (delete == false)
            {
                CanvasVector canvas = tabCanvases[(tabControl.SelectedItem as TabItem).Header.ToString()];
                cmd.canvasVector = canvas;
                canvas.cmd = cmd;
            }
            if (delete == true)
            {
                //cmd.canvasVector = cmd.canvasVector;
                //canvasVector.cmd = canvasVector.cmd;
                delete = false;
            }
        }

        #region Main Menu Window Tab
        private void MainMenu_Window_MouseEnter(object sender, EventArgs e)
        {
            int count = mainMenu.MenuItem_Window.Items.Count;
            for (int i = 0; i < count; ++i)
            {
                mainMenu.MenuItem_Window.Items.RemoveAt(0);
            }
            foreach (TabItem item in tabControl.Items)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Name = item.Name;
                menuItem.Header = item.Header;

                mainMenu.MenuItem_Window.Items.Add(menuItem);
            }

            count = mainMenu.MenuItem_Window.Items.Count;
            for (int i = 0; i < count; ++i)
            {
                (mainMenu.MenuItem_Window.Items[i] as MenuItem).Click += MainMenu_Window_Item_Clicked;
            }
        }

        private void MainMenu_Window_Item_Clicked(object sender, EventArgs e)
        {
            MenuItem obj = sender as MenuItem;
            tabControl.SelectedItem = GetTabItem(obj.Header.ToString());
        }

        public TabItem GetTabItem(string tabName)
        {
            TabItem res = null;
            foreach (TabItem item in tabControl.Items)
            {
                if (item.Header.ToString() == tabName)
                {
                    res = item;
                }
            }
            return res;
        }
        #endregion

    }
}
