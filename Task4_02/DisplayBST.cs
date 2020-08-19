using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4_02
{
    public partial class DisplayBST : Form
    {
        public DisplayBST()
        {
            InitializeComponent();

            BSTree tree = new BSTree();
            TreeInitialization(tree);
            tree.Display(PB_Graph);
        }

        private void TreeInitialization(BSTree tree)
        {
            tree.Add(50);
            tree.Add(25);
            tree.Add(11);
            tree.Add(7);
            tree.Add(30);
            tree.Add(27);
            tree.Add(40);
            tree.Add(90);
            tree.Add(80);
            tree.Add(110);
            tree.Add(1);
            tree.Add(15);
            tree.Add(85);
            tree.Add(79);
            tree.Add(88);
            tree.Add(89);
            tree.Add(82);
        }
    }
}
