using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multichat_Server.API;

namespace Multichat_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerAPI server = new ServerAPI();
            Console.ReadKey();
        }
    }
}
