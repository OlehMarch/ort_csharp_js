using System;
using System.Windows.Forms;
using System.IO;
using Paint.Dialogs;
using Paint;

namespace Paint.UserControls
{
    public partial class IO : UserControl
    {
        public Canvas canvas { set; get; }

        public IO()
        {
            InitializeComponent();
        }
     
        public void SetXCommand(XCommand com)
        {
            this.buttonIO.Click += com.ActIO.Action;
        }
    }
}
