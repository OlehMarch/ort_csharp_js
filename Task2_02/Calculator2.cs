using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Calc = Task1_5.Calculation;


namespace Task2_02
{
    public partial class Calculator2 : Form
    {
        public Calculator2()
        {
            InitializeComponent();

            firstOperand = "";
            secondOperand = "";
            operation = "";
    }


        private string firstOperand;
        private string secondOperand;
        private string operation;
        private bool operationPressed = false;
        private bool isCalculated = false;


        private void ClearTB()
        {
            if (operationPressed)
            {
                TB_Result.Text = "";
                operationPressed = false;
            }
            if (isCalculated)
            {
                TB_Result.Text = "";
                isCalculated = false;
            }
            if (TB_Result.Text == "0")
            {
                TB_Result.Text = "";
            }
        }

        #region Numbers
        private void button0_Click(object sender, EventArgs e)
        {
            ClearTB();

            if (TB_Result.Text != "0")
            {
                TB_Result.Text += "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearTB();

            TB_Result.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTB();

            TB_Result.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearTB();

            TB_Result.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearTB();

            TB_Result.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearTB();

            TB_Result.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearTB();

            TB_Result.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClearTB();

            TB_Result.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClearTB();

            TB_Result.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ClearTB();

            TB_Result.Text += "9";
        }
        #endregion

        #region Operations
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            operationPressed = true;
            operation = "+";
            firstOperand = TB_Result.Text;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            operationPressed = true;
            operation = "-";
            firstOperand = TB_Result.Text;
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            operationPressed = true;
            operation = "*";
            firstOperand = TB_Result.Text;
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            operationPressed = true;
            operation = "/";
            firstOperand = TB_Result.Text;
        }

        private void buttonEquation_Click(object sender, EventArgs e)
        {
            operationPressed = false;
            isCalculated = true;
            secondOperand = TB_Result.Text;
            TB_Result.Text = Calc.Calculate(firstOperand, secondOperand, operation);
        }
        #endregion

        //Button btn = sender as Button;
        //operator = btn.Text;

    }
}
