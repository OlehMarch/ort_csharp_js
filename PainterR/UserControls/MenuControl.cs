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
using Paint.UserControls;

namespace Paint.UserControls
{
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
        }

        public void SetXCommand(XCommand com)
        {
            this.saveToolStripMenuItem.Click += com.ActIO.Action;
            this.colorToolStripMenuItem.Click += com.ActColor.Action;
            this.widthToolStripMenuItem.Click += com.ActWidth.Action;
            this.typeToolStripMenuItem.Click += com.ActType.Action;
        }

    }
}
