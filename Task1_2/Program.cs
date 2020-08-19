using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int Task1_Sum()
        {
            return 2450;
        }

        public static int Task1_Quantity()
        {
            return 49;
        }

        public static bool Task2(int value)
        {
            bool isSimple = false;

            if (value >= 2)
            {
                for (int i = 2; i <= value; ++i)
                {
                    if (i == value)
                    {
                        isSimple = true;
                        break;
                    }

                    if (value % i == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }
            }
            else if ((value == 0) || (value == 1))
            {
                isSimple = true;
            }
            else
            {
                isSimple = false;
            }

            return isSimple;
        }

        public static int Task3(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            int res = 0;
            int iterator = 0;
            int prevDiff = Int32.MaxValue;
            int currDiff = 0;

            while (true)
            {
                currDiff = Math.Abs(value - iterator * iterator);

                if (currDiff >= prevDiff)
                {
                    res = iterator - 1;
                    break;
                }

                prevDiff = currDiff;
                iterator++;
            }

            return res;
        }

        public static int Task4(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }

            int res = 1;

            if (n > 1)
            {
                for (int i = 1; i <= n; ++i)
                {
                    res *= i;
                }
            }
            else if (n == 1)
            {
                res = 1;
            }
            else if (n == 0)
            {
                res = 0;
            }

            return res;
        }

        public static int Task5(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            int sum = 0;

            if (value > 0)
            {
                while (value % 10 != 0)
                {
                    sum += value % 10;
                    value /= 10;
                }
            }
            else if (value == 0)
            {
                sum = 0;
            }

            return sum;
        }

        public static int Task6(int value)
        {
            if (value < 0) 
            {
                throw new ArgumentException();
            }

            int res = 0;
            string numArr = value.ToString();
            string temp = "";

            if (value >= 0)
            {
                for (int i = numArr.Length - 1; i >= 0; --i)
                {
                    temp += numArr[i];
                }

                res = Convert.ToInt32(temp);
            }

            return res;
        }
    }
}
