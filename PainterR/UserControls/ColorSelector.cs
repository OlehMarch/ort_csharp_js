using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint;

namespace Paint.UserControls
{
    public partial class ColorSelector : UserControl
    {
        public ColorSelector()
        {
            InitializeComponent();
        }

        public void SetXCommand(XCommand com)
        {
            this.B_ColorSelector.Click += com.ActColor.Action;
        }

        public override string Text
        {
            get
            {
                return B_ColorSelector.Text;
            }
            set
            {
                B_ColorSelector.Text = value;
            }
        }
    }
}
