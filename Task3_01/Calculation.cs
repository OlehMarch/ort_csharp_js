using System;


namespace Task3_01
{
    public class Calculation
    {
        public static double Calculate(int fstOperand, int secOperand, string operation)
        {
            int firstOperand = 0;
            int secondOperand = 0;
            double result = 0;

            firstOperand = fstOperand;
            secondOperand = secOperand;

            switch (operation)
            {
                case "+":
                    result = firstOperand + secondOperand;
                    break;
                case "-":
                    result = firstOperand - secondOperand;
                    break;
                case "*":
                    result = firstOperand * secondOperand;
                    break;
                case "/":
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

            return result;
        }
    }
}