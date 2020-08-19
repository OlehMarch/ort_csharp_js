using Painter.UserControls.VectorElements;
using PainterV;
using PainterV.UserControls.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public partial class MiniPaintV : Form
    {
        public MiniPaintV()
        {
            InitializeComponent();

            cmd.canvas = canvasVector;
            canvasVector.cmd = cmd;
            canvasVector.SetCanvasMouseMoveEventHandler(statusBar);

            toolBox.statusBar = statusBar;
            toolBar.statusBar = statusBar;
            mainMenu.statusBar = statusBar;
            propertyPanel.Cmd = cmd;
            propertyPanel.AttachEventHandlers();

            mainMenu.MainMenu_Window.MouseEnter += MainMenu_Window_MouseEnter; ;
            mainMenu.MainMenu_Window.DropDownItemClicked += MainMenu_Window_DropDownItemClicked;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CanvasVector canvas;
            if (tabControl.SelectedTab == null)
            {
                canvas = tabControl.TabPages["NewPage"].Controls["canvasVector"] as CanvasVector;
            }
            else
            {
                canvas = tabControl.SelectedTab.Controls["canvasVector"] as CanvasVector;
            }
            cmd.canvas = canvas;
            canvas.cmd = cmd;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Text != "NewPage")
            {
                tabControl.TabPages.Remove(tabControl.SelectedTab);
            }
        }

        #region Main Menu Window Tab
        private void MainMenu_Window_MouseEnter(object sender, EventArgs e)
        {
            int count = mainMenu.MainMenu_Window.DropDownItems.Count;
            for (int i = 0; i < count; ++i)
            {
                mainMenu.MainMenu_Window.DropDownItems.RemoveAt(0);
            }
            foreach (TabPage item in tabControl.TabPages)
            {
                mainMenu.MainMenu_Window.DropDownItems.Add(item.Name);
            }
        }

        private void MainMenu_Window_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[e.ClickedItem.Text];
        }
        #endregion

    }
}
