using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using PersonDAO_Server.Api;

namespace PersonDAO_Server
{
    public class Server
    {
        private Socket listenSocket;
        private const int PORT = 11000;
        private Socket clientSocket;
        private bool isConnection;
        private IoFabrica fabrica;

        public Server()
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

        private void Init()
        {
            fabrica = new IoFabrica(new EventHandler(this.ServerReply));
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress address = host.AddressList[0];
            IPEndPoint ip = new IPEndPoint(address, PORT);
            listenSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(ip);
        }

        public void Listen()
        {
            Debug.Say("Waiting for connections...");
            listenSocket.Listen(1);
            clientSocket = listenSocket.Accept();
            Debug.Say("Connection acquired.");
            isConnection = true;
            string result = String.Empty;

            while (isConnection)
            {
                byte[] incomeMessage = new byte[1024];
                while (clientSocket.Available > 1)
                {
                    int count = clientSocket.Receive(incomeMessage);
                    result += Encoding.UTF8.GetString(incomeMessage, 0, count);
                }

                if (result != String.Empty)
                {
                    Debug.Say(String.Format("I have got an income message at {0}.", DateTime.Now));
                    fabrica.CrudListen(result);
                    result = String.Empty;
                }             
            }
            CleanUp();
        }

        private void ServerReply(object sender, EventArgs e)
        {
            clientSocket.Send(sender as byte[]);
        }

        public void CleanUp()
        {
            isConnection = false;
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

    }
}
