using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multichat_Server_ClientThread.API
{
    public class ConnectionManager
    {
        private List<TcpClient> clientList;
        private List<string> broadcastMessages;

        private Thread threadSay;
        private object lockSay = new object();

        public ConnectionManager()
        {
            clientList = new List<TcpClient>();
            broadcastMessages = new List<string>();
            threadSay = new Thread(new ThreadStart(Write));
            threadSay.Start();
        }

        public void AddClient(TcpClient client)
        {
            clientList.Add(client);
            new Thread(new ParameterizedThreadStart(Sniffer)).Start(client);
        }

        public void Sniffer(object client)
        {
            while (true)
            {
                if (clientList.Count > 0)
                {
                    Read(client as TcpClient);
                }
            }
        }

        private void Read(TcpClient client)
        {
            lock (lockSay)
            {
                NetworkStream networkStream = client.GetStream();

                if (networkStream.DataAvailable)
                {
                    StreamReader streamReader = new StreamReader(networkStream);
                    broadcastMessages.Add(streamReader.ReadLine());
                }
            }
        }

        private void Write()
        {
            while (true)
            {
                lock (lockSay)
                {
                    for (int j = 0; j < broadcastMessages.Count; j++)
                    {
                        for (int i = 0; i < clientList.Count; i++)
                        {
                            NetworkStream networkStream = clientList[i].GetStream();
                            StreamWriter streamWriter = new StreamWriter(networkStream);
                            streamWriter.WriteLine(broadcastMessages[j]);
                            streamWriter.Flush();
                        }
                    }
                    ClearBroadcast();
                }
            }
        }

        private void ClearBroadcast()
        {
            broadcastMessages.Clear();
        }
    }
}
