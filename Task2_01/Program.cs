using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_01
{
    class Program
    {
        static void Main(string[] args)
        {
            AListR lst = new AListR();
            //lst.PrintMethodNames();

            try
            {
                //lst.Init(new int[40]);

                lst.AddEnd(30);
                lst.AddEnd(31);
                lst.AddEnd(32);
                lst.AddEnd(33);
                lst.AddEnd(34);
                lst.AddEnd(35);
                lst.AddEnd(36);
                lst.AddEnd(37);
                lst.AddEnd(38);
                //lst.AddStart(39);
                lst.DelEnd();
                lst.DelEnd();
                lst.DelEnd();
                lst.DelEnd();
                lst.DelEnd();
                lst.DelEnd();
                lst.DelEnd();
                lst.DelEnd();
                lst.DelEnd();
                //lst.AddPos(3, 1);
                //lst.AddPos(3, 2);
                //lst.AddPos(3, 3);
                //lst.AddPos(3, 4);
                //lst.AddPos(3, 5);
                //lst.AddPos(3, 6);
                //lst.AddPos(3, 7);
                //lst.AddPos(3, 8);
                //lst.AddPos(3, 9);
                //lst.AddPos(3, 10);

                //Console.WriteLine(lst.DelPos(1));

                //lst.Print();
                //lst.Reverse();
                //lst.Print();

                Console.ReadKey();
            }
            catch (ArgumentException)
            {

            }
        }
    }
}
