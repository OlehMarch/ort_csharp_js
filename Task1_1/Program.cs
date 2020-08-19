using System;


namespace Task1_1
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int Task1(int a, int b)
        {
            int res = 0;

            if (a % 2 == 0)
            {
                res = a * b;
            }
            else
            {
                res = a + b;
            }

            return res;
        }

        public static int Task2(int x, int y)
        {
            if ((x == 0) || (y == 0))
            {
                throw new ArgumentException();
            }

            int res = 0;

            if ((x > 0) && (y > 0))
            {
                res = 1;
            }
            else if ((x < 0) && (y > 0))
            {
                res = 2;
            }
            else if ((x < 0) && (y < 0))
            {
                res = 3;
            }
            else if ((x > 0) && (y < 0))
            {
                res = 4;
            }

            return res;
        }

        public static int Task3(int a, int b, int c)
        {
            int res = 0;

            if (a > 0)
            {
                res += a;
            }
            if (b > 0)
            {
                res += b;
            }
            if (c > 0)
            {
                res += c;
            }

            return res;
        }

        public static int Task4(int a, int b, int c)
        {
            int left = a * b * c;
            int right = a + b + c;
            int res = 0;

            if (left > right)
            {
                res = left + 3;
            }
            else
            {
                res = right + 3;
            }

            return res;
        }

        public static string Task5(int points)
        {
            if ((points < 0) || (points > 100))
            {
                throw new ArgumentException();
            }

            string mark = "";

            if ((points >= 0) && (points <= 19))
            {
                mark = "F";
            }
            else if ((points >= 20) && (points <= 39))
            {
                mark = "E";
            }
            else if ((points >= 40) && (points <= 59))
            {
                mark = "D";
            }
            else if ((points >= 60) && (points <= 74))
            {
                mark = "C";
            }
            else if ((points >= 75) && (points <= 89))
            {
                mark = "B";
            }
            else if ((points >= 90) && (points <= 100))
            {
                mark = "A";
            }

            return mark;
        }
    }
}
