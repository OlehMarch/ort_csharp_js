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
    public partial class ToolboxControl : UserControl
    {
      
        public ToolboxControl()
        {
            InitializeComponent();
        }

        public void SetXCommand(XCommand com)
        {
            this.buttonIO.Click += com.ActIO.Action;
            this.B_ColorSelector.Click += com.ActColor.Action;
            this.buttonWidth.Click += com.ActWidth.Action;
            this.buttonShape.Click += com.ActType.Action;
        }

    }
}
