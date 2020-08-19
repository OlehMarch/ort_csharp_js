using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint.Dialogs;

namespace PainterV.UserControls.Menu
{
    public partial class MainMenuVector : UserControl
    {
        public MainMenuVector()
        {
            InitializeComponent();
        }

        public MainMenuVector(XCommand cmd) : this()
        {
            this.cmd = cmd;
            this.MainMenu_Color.Click += new EventHandler(cmd.aColor.Action);
            this.MainMenu_PenWidth.Click += new EventHandler(cmd.aWidth.Action);
            this.MainMenu_ShapeType.Click += new EventHandler(cmd.aType.Action);
        }

        private XCommand cmd;
        public StatusBarVector statusBar;

        private void MainMenu_FIle_Click(object sender, EventArgs e)
        {
            IODialog dlg = new IODialog(cmd, (TabControl)this.Parent.Controls["tabControl"]);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dlg.CreateTabPage(statusBar);
            }
            dlg.Dispose();
        }
    }
}
