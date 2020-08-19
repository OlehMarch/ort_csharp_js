using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_5
{
    public static class Calculation
    {

        public static string Calculate(string fstOperand, string secOperand, string operation)
        {
            double firstOperand = 0;
            double secondOperand = 0;
            double result = 0;

            firstOperand = Convert.ToDouble(fstOperand);
            secondOperand = Convert.ToDouble(secOperand);

            switch (operation[0])
            {
                case '+':
                    result = firstOperand + secondOperand;
                    break;
                case '-':
                    result = firstOperand - secondOperand;
                    break;
                case '*':
                    result = firstOperand * secondOperand;
                    break;
                case '/':
                    if (secondOperand == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    else
                    {
                        result = firstOperand / secondOperand;
                    }
                    break;
                default:
                    throw new ArgumentException();
            }

            return result.ToString();
        }

    }
}
