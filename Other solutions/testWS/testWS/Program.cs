
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace testWS
{
    class Program
    {
        public static void Main()
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);

            server.Start();
            Console.WriteLine("Server has started on 127.0.0.1:8080.{0}Waiting for a connection...", Environment.NewLine);

            TcpClient client = server.AcceptTcpClient();

            Console.WriteLine("A client connected.");

            NetworkStream stream = client.GetStream();
            UniversalStream ws = new UniversalStream(client);

            while (true)
            {
                if (!stream.DataAvailable)
                {
                    continue;
                }

                string data = ws.Read();

                if (new Regex("^GET").IsMatch(data))
                {
                    ws.WriteHandshake(data);
                }
                else
                {
                    if (!data.StartsWith("desktop:"))
                    {
                        data = ws.Decode();
                        Console.WriteLine(data);
                        ws.Write(data);
                    }
                    else
                    {
                        data = data.Replace("desktop:", "");
                        LogManager.AddToLog("Vasya", data);
                        Console.WriteLine(data);
                        ws.Write(data, false);
                    }
                }
            }
        }
    }
}