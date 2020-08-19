using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonDAO_Client
{
    public class Client
    {
        private Socket sendSocket;
        private const int PORT = 11000;
        private bool isConnection;

        public Client()
        {
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public string ListenReply()
        {
            byte[] incomeMessage = new byte[1024];
            string result = String.Empty;
            while (result == "")
            {
                while (sendSocket.Available > 1)
                {
                    int count = sendSocket.Receive(incomeMessage);
                    result += Encoding.UTF8.GetString(incomeMessage, 0, count);
                }
            }
            return result;
        }

        private void Init()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress address = host.AddressList[0];
            IPEndPoint ip = new IPEndPoint(address, PORT);
            sendSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sendSocket.Connect(ip);
            isConnection = true;
        }

        public void Send(string message)
        {
            if (isConnection)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                sendSocket.Send(bytes);
            }
        }

        public void CleanUp()
        {
            sendSocket.Shutdown(SocketShutdown.Both);
            sendSocket.Close();
        }
    }
}
