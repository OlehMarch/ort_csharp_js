using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringArrayCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] res = StringCombination("мама мыла раму");

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }

        private static string[] StringCombination(string ini)
        {
            string[] words = ini.Split(' ');
            string[] results = new string[Factorial(words.Length)];
            results[0] = ini;

            for (int j = 1; ; )
            {
                for (int k = 0; k < words.Length - 1; k++)
                {
                    if (j == results.Length)
                    {
                        return results;
                    }

                    string tmp = words[k];
                    words[k] = words[k + 1];
                    words[k + 1] = tmp;
                    tmp = "";

                    for (int i = 0; i < words.Length; i++)
                    {
                        tmp += words[i] + " ";
                    }

                    results[j++] = tmp;
                }
            }
        }

        private static int Factorial(int value)
        {
            int res = 1;

            for (int i = 1; i <= value; i++)
            {
                res *= i;
            }

            return res;
        }

    }
}
