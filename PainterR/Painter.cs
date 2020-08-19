using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Painter : Form
    {
        private XCommand command;

        public Painter()
        {
            InitializeComponent();
            command = new XCommand(this.canvas1);
            canvas1.SetXCommand(command);
            colorSelector1.SetXCommand(command);
            penWidthSelector1.SetXCommand(command);
            shapeTypeSelector1.SetXCommand(command);
            menuControl1.SetXCommand(command);
            io1.SetXCommand(command);
            toolboxControl1.SetXCommand(command);
        }
    }
}
