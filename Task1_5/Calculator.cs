using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1_5
{
    // need to test program behavior (list of gui test progs)

    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void B_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                TB_Result.Text = Calculation.Calculate(TB_FirstOperand.Text, TB_SecondOperand.Text, TB_Operation.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
