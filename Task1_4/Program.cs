using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_4
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static string Task1(int dayNumber)
        {
            if ((dayNumber > 7) || (dayNumber <= 0))
            {
                throw new ArgumentException();
            }

            string dayName = "";

            switch (dayNumber)
            {
                case 1:
                    dayName = "понедельник";
                    break;
                case 2:
                    dayName = "вторник";
                    break;
                case 3:
                    dayName = "среда";
                    break;
                case 4:
                    dayName = "четверг";
                    break;
                case 5:
                    dayName = "пятница";
                    break;
                case 6:
                    dayName = "суббота";
                    break;
                case 7:
                    dayName = "воскресенье";
                    break;
            }

            return dayName;
        }

        public static string Task2(int number)
        {
            if ((number < 0) || (number > 999))
            {
                throw new ArgumentException();
            }

            string res = "";
            string num = number.ToString();
            
            if (number > 0)
            {
                for (int i = num.Length - 1, j = 0; i >= 0; --i, ++j)
                {
                    if (num[i] != '0')
                    {
                        if (j == 2)
                        {
                            res = NumToString(num[i], 0) + " hundred " + res;
                        }
                        else
                        {
                            res = NumToString(num[i], j) + " " + res;
                        }
                    }
                }
            }
            else if (number == 0)
            {
                res = "zero";
            }

            res = StringFormatCorrect(res).TrimEnd();

            return res;
        }

        public static int Task3(string number)
        {
            number = number.ToLower();

            if (number.Contains("thousand") || number.Contains("million") || number.Contains("billion") || number.Contains("minus"))
            {
                throw new ArgumentException();
            }

            int res = 0;
            string temp = "";
            number = StringFormatCorrect(number, true);
            string[] num = number.Split(' ');

            if (num.Length == 1)
            {
                if (num[0].EndsWith("ty") || num[0].EndsWith("ten"))
                {
                    temp += StringToNum(num[0], 1) + "0";
                }
                else
                {
                    temp += StringToNum(num[0], 0);
                }
            }
            else if (num.Length == 2)
            {
                if (num[1].EndsWith("hundred"))
                {
                    temp += StringToNum(num[0], 0) + "00";
                }
                else
                {
                    temp += StringToNum(num[0], 1) + StringToNum(num[1], 0);
                }
            }
            else if (num.Length == 3)
            {
                temp += StringToNum(num[0], 0);

                if (num[2].EndsWith("ty") || num[2].EndsWith("ten"))
                {
                    temp += StringToNum(num[2], 1) + "0";
                }
                else
                {
                    temp += "0" + StringToNum(num[2], 0);
                }
            }
            else if (num.Length == 4)
            {
                temp += StringToNum(num[0], 0);
                temp += StringToNum(num[2], 1);
                temp += StringToNum(num[3], 0);
            }

            res = Convert.ToInt32(temp);

            return res;
        }

        public static double Task4(int x1, int y1, int x2, int y2)
        {
            double x = x2 - x1;
            double y = y2 - y1;
            double res = 0;

            res = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            return res;
        }

        public static string Task5(long number)
        {
            if ((number < 0) || (number > 999999999999))
            {
                throw new ArgumentException();
            }

            string res = "";
            string temp = "";
            string num = number.ToString();

            if ((num.Length > 0) && (num.Length < 4))
            {
                res = Task2(Convert.ToInt32(number));
            }
            else if ((num.Length > 3) && (num.Length < 7))
            {
                temp = num[num.Length - 3].ToString() + num[num.Length - 2].ToString() + num[num.Length - 1].ToString();
                res = Task2(Convert.ToInt32(temp));
                res = Task2(Convert.ToInt32(TopElementsProcessing(num, num.Length, 4))) 
                    + " thousand " + res;
            }
            else if ((num.Length > 6) && (num.Length < 10))
            {
                temp = num[num.Length - 3].ToString() + num[num.Length - 2].ToString() + num[num.Length - 1].ToString();
                res = Task2(Convert.ToInt32(temp));
                temp = num[num.Length - 6].ToString() + num[num.Length - 5].ToString() + num[num.Length - 4].ToString();
                res = Task2(Convert.ToInt32(temp)) + " thousand " + res;
                res = Task2(Convert.ToInt32(TopElementsProcessing(num, num.Length, 7)))
                    + " million " + res;
            }
            else if ((num.Length > 9) && (num.Length < 13))
            {
                temp = num[num.Length - 3].ToString() + num[num.Length - 2].ToString() + num[num.Length - 1].ToString();
                res = Task2(Convert.ToInt32(temp));
                temp = num[num.Length - 6].ToString() + num[num.Length - 5].ToString() + num[num.Length - 4].ToString();
                res = Task2(Convert.ToInt32(temp)) + " thousand " + res;
                temp = num[num.Length - 9].ToString() + num[num.Length - 8].ToString() + num[num.Length - 7].ToString();
                res = Task2(Convert.ToInt32(temp)) + " million " + res;
                res = Task2(Convert.ToInt32(TopElementsProcessing(num, num.Length, 10)))
                    + " billion " + res;
            }

            if (res.Contains(" zero million"))
            {
                res = res.Replace(" zero million", "");
            }
            if (res.Contains(" zero thousand"))
            {
                res = res.Replace(" zero thousand", "");
            }
            if (res.EndsWith(" zero"))
            {
                res = res.Replace(" zero", "");
            }

            return res;
        }

        public static long Task6(string number)
        {
            number = StringFormatCorrect(number.ToLower(), true);

            if (number.Contains("trillion") || number.Contains("minus"))
            {
                throw new ArgumentException();
            }

            long res = 0;
            string temp = "";

            if (number.Contains("billion"))
            {
                temp = number.Substring(0, number.IndexOf("billion") - 1);
                number = number.Replace(temp + " billion", "").TrimStart();
                res += Convert.ToInt64(Task3(temp)) * 1000000000;
            }
            if (number.Contains("million"))
            {
                temp = number.Substring(0, number.IndexOf("million") - 1);
                number = number.Replace(temp + " million", "").TrimStart();
                res += Convert.ToInt64(Task3(temp)) * 1000000;
            }
            if (number.Contains("thousand"))
            {
                temp = number.Substring(0, number.IndexOf("thousand") - 1);
                number = number.Replace(temp + " thousand", "").TrimStart();
                res += Convert.ToInt64(Task3(temp)) * 1000;
            }
            if (number.Length > 0)
            {
                res += Convert.ToInt64(Task3(number));
            }

            return res;
        }

        private static string NumToString(char number, int offset)
        {
            string res = "";

            if (offset == 1)
            {
                switch (number)
                {
                    case '0':
                        res = "";
                        break;
                    case '1':
                        res = "ten";
                        break;
                    case '2':
                        res = "twenty";
                        break;
                    case '3':
                        res = "thirty";
                        break;
                    case '4':
                        res = "forty";
                        break;
                    case '5':
                        res = "fifty";
                        break;
                    case '6':
                        res = "sixty";
                        break;
                    case '7':
                        res = "seventy";
                        break;
                    case '8':
                        res = "eighty";
                        break;
                    case '9':
                        res = "ninety";
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            else if (offset == 0)
            {
                switch (number)
                {
                    case '0':
                        res = "";
                        break;
                    case '1':
                        res = "one";
                        break;
                    case '2':
                        res = "two";
                        break;
                    case '3':
                        res = "three";
                        break;
                    case '4':
                        res = "four";
                        break;
                    case '5':
                        res = "five";
                        break;
                    case '6':
                        res = "six";
                        break;
                    case '7':
                        res = "seven";
                        break;
                    case '8':
                        res = "eight";
                        break;
                    case '9':
                        res = "nine";
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }

            return res;
        }

        private static string StringToNum(string number, int offset)
        {
            string res = "";

            if (offset == 1)
            {
                switch (number)
                {
                    case "ten":
                        res = "1";
                        break;
                    case "twenty":
                        res = "2";
                        break;
                    case "thirty":
                        res = "3";
                        break;
                    case "forty":
                        res = "4";
                        break;
                    case "fifty":
                        res = "5";
                        break;
                    case "sixty":
                        res = "6";
                        break;
                    case "seventy":
                        res = "7";
                        break;
                    case "eighty":
                        res = "8";
                        break;
                    case "ninety":
                        res = "9";
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            else if (offset == 0)
            {
                switch (number)
                {
                    case "zero":
                        res = "0";
                        break;
                    case "one":
                        res = "1";
                        break;
                    case "two":
                        res = "2";
                        break;
                    case "three":
                        res = "3";
                        break;
                    case "four":
                        res = "4";
                        break;
                    case "five":
                        res = "5";
                        break;
                    case "six":
                        res = "6";
                        break;
                    case "seven":
                        res = "7";
                        break;
                    case "eight":
                        res = "8";
                        break;
                    case "nine":
                        res = "9";
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }

            return res;
        }

        private static string TopElementsProcessing(string num, int length, int offset)
        {
            string res = "";

            if (length == offset)
            {
                res = num[length - offset].ToString();
            }
            else if (length == offset + 1)
            {
                res = num[length - (offset + 1)].ToString() + num[length - offset].ToString();
            }
            else
            {
                res = num[length - (offset + 2)].ToString() + num[length - (offset + 1)].ToString() + num[length - offset].ToString();
            }

            return res;
        }

        private static string StringFormatCorrect(string number, bool reverse = false)
        {
            if (!reverse)
            {
                number = number.Replace("ten one", "eleven");
                number = number.Replace("ten two", "twelve");
                number = number.Replace("ten three", "thirteen");
                number = number.Replace("ten four", "fourteen");
                number = number.Replace("ten five", "fifteen");
                number = number.Replace("ten six", "sixteen");
                number = number.Replace("ten seven", "seventeen");
                number = number.Replace("ten eight", "eighteen");
                number = number.Replace("ten nine", "nineteen");
            }
            else
            {
                number = number.Replace("eleven", "ten one");
                number = number.Replace("twelve", "ten two");
                number = number.Replace("thirteen", "ten three");
                number = number.Replace("fourteen", "ten four");
                number = number.Replace("fifteen", "ten five");
                number = number.Replace("sixteen", "ten six");
                number = number.Replace("seventeen", "ten seven");
                number = number.Replace("eighteen", "ten eight");
                number = number.Replace("nineteen", "ten nine");
            }

            return number;
        }

    }
}
