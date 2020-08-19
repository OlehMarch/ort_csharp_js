using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multichat_Server_ClientThread.API
{
    public class ServerAPI
    {
        private const int Port = 5555;
        private TcpListener listener;

        private Thread threadListen;
        private ConnectionManager manager;

        public ServerAPI()
        {
            try
            {
                Init();
                ThreadInit();
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        private void Init()
        {
            manager = new ConnectionManager();
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), Port);
        }

        private void ThreadInit()
        {
            threadListen = new Thread(new ThreadStart(Listen));
            threadListen.Start();
        }

        public void Listen()
        {
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                manager.AddClient(client);
            }
        }

    }
}
