using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint.UserControls;
using Paint.Dialogs;

namespace Paint.UserControls
{
    public partial class ContextControl : UserControl
    {
        public ContextControl()
        {
            InitializeComponent();
        }

        public void SetXCommand(XCommand com)
        {
            this.widthToolStripMenuItem.Click += com.ActWidth.Action;
            this.colorToolStripMenuItem.Click += com.ActColor.Action;
            this.typeToolStripMenuItem.Click += com.ActType.Action;
            this.saveLoadToolStripMenuItem.Click += com.ActIO.Action;
        }

        public void ShowContextMenu()
        {
            this.contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
        }
    }
}
