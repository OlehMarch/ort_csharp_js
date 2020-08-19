using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubblePainter
{
    public partial class BubbleFormUCThread : Form
    {
        public BubbleFormUCThread()
        {
            InitializeComponent();
        }

        private void BubbleFormUCThread_FormClosing(object sender, FormClosingEventArgs e)
        {
            bubblePainterThreadUC1.Dispose();
            bubblePainterThreadUC2.Dispose();
        }
    }
}
