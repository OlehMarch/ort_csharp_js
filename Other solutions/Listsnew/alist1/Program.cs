using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            AList2O list = new AList2O();

            int[] z = { 5, 254, 1, 6, 4 };
            list.Init(z);

            list.ToArray();
            Console.ReadKey();

        }
    }
}
