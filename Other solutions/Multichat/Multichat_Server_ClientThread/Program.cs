using Multichat_Server_ClientThread.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multichat_Server_ClientThread
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
