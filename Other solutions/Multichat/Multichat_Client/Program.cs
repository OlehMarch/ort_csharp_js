using Multichat_Client.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multichat_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientAPI client = new ClientAPI();
            client.Say();
            Console.ReadKey();
        }
    }
}
