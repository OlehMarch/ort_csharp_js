using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter.UserControls.VectorElements;
using Painter;
using PainterV;
using PainterV.UserControls.Menu;

namespace Paint.Dialogs
{
    public partial class IODialog : Form
    {
        public IODialog(XCommand cmd, TabControl tabControl = null)
        {
            InitializeComponent();

            this.cmd = cmd;
            this.tabControl = tabControl;

            this.buttonSave.Click += new EventHandler(cmd.aSave.Action);
            this.buttonLoad.Click += new EventHandler(cmd.aLoad.Action);
        }

        private XCommand cmd;
        private TabControl tabControl;

        public void CreateTabPage(StatusBarVector statusBar)
        {
            if (tabControl != null && cmd.aLoad.fileName != null)
            {
                tabControl.SelectedTab = tabControl.TabPages["NewPage"];
                tabControl.TabPages.Add(cmd.aLoad.fileName, cmd.aLoad.fileName);
                tabControl.TabPages[cmd.aLoad.fileName].Padding = new Padding(3, 3, 3, 3);
                tabControl.TabPages[cmd.aLoad.fileName].Margin = new Padding(3, 3, 3, 3);

                CanvasVector canvasVector = new CanvasVector();
                canvasVector.Name = "canvasVector";
                canvasVector.Dock = DockStyle.Fill;
                canvasVector.BorderStyle = BorderStyle.FixedSingle;
                canvasVector.BackColor = Color.White;
                cmd.canvas = canvasVector;
                canvasVector.cmd = cmd;
                canvasVector.SetCanvasMouseMoveEventHandler(statusBar);

                CanvasVector control = tabControl.SelectedTab.Controls["canvasVector"] as CanvasVector;
                tabControl.TabPages[cmd.aLoad.fileName].Controls.Remove(tabControl.TabPages[cmd.aLoad.fileName].Controls["canvasVector"]);
                tabControl.TabPages[cmd.aLoad.fileName].Controls.Add(control);
                tabControl.SelectedTab.Controls.Add(canvasVector);

                tabControl.SelectedTab = tabControl.TabPages["NewPage"];
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
