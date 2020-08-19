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
using Paint;

namespace Paint.UserControls
{
    public partial class PenWidthSelector : UserControl
    {
        public PenWidthSelector()
        {
            InitializeComponent();
        }

        public void SetXCommand(XCommand com)
        {
            this.buttonSetWidth.Click += com.ActWidth.Action;
        }
    }
}
