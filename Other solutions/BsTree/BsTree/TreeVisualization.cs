using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BsTree
{
    public partial class TreeVisualization : Form
    {
        public BsTreeGUI x;
        public TreeVisualization()
        {
            InitializeComponent();
          
        }
       

        private void TreeVisualization_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = new BsTreeGUI();
            x.Show(panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
                return;
            x = new BsTreeGUI();

      //      x.Show2(panel1, int.Parse(textBox1.Text));
        }
    }
}
