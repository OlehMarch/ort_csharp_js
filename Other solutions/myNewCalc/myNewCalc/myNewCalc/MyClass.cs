using System;

namespace myNewCalc
{
    public class MyClass
    {
        public MyClass()
        {         
        }
        public static string Calc(int num1, int num2, string op)
        {
            switch (op)
            {
                case "+": return (num1 + num2).ToString();
                case "-": return (num1 - num2).ToString();
                case "*": return (num1 * num2).ToString();
                case "/": return (num1 / num2).ToString();
                default: return "Invalid operation";
            }
        }
    }
}

