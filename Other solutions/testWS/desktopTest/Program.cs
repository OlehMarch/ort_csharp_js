using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace desktopTest
{
    class Program
    {
        static TcpClient client = new TcpClient("127.0.0.1", 8080);

        static void Main(string[] args)
        {
            Thread listenerThread = new Thread(new ThreadStart(ListenLoop));
            listenerThread.Start();

            StreamWriter sw = new StreamWriter(client.GetStream());

            while (true)
            {
                string msg = Console.ReadLine();

                sw.WriteLine("desktop:" + msg);
                sw.Flush();
            }
        }

        private static void ListenLoop()
        {
            StreamReader sr = new StreamReader(client.GetStream());

            while (true)
            {
                if (client.GetStream().DataAvailable)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
        }
    }
}
