using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multichat_Server.API
{
    public class ConnectionManager
    {
        private List<TcpClient> clientList;
        private List<string> broadcastMessages;

        private Thread threadListen;

        public ConnectionManager()
        {
            clientList = new List<TcpClient>();
            broadcastMessages = new List<string>();
            threadListen = new Thread(new ThreadStart(Sniffer));
            threadListen.Start();
        }

        public void AddClient(TcpClient client)
        {
            clientList.Add(client);
            broadcastMessages.Add(String.Empty);
        }

        public void Sniffer()
        {
            while (true)
            {
                if (clientList.Count > 0)
                {
                    Read();
                    Write();
                }
            }
        }

        private void Read()
        {
            for (int i = 0; i < clientList.Count; i++)
            {
                NetworkStream networkStream = clientList[i].GetStream();

                if (networkStream.DataAvailable)
                {
                    StreamReader streamReader = new StreamReader(networkStream);
                    broadcastMessages[i] = streamReader.ReadLine();
                }
            }
        }

        private void Write()
        {
            for (int i = 0; i < clientList.Count; i++)
            {
                NetworkStream networkStream = clientList[i].GetStream();

                for (int j = 0; j < broadcastMessages.Count; j++)
                {
                    if (broadcastMessages[j] != String.Empty)
                    {
                        StreamWriter streamWriter = new StreamWriter(networkStream);
                        streamWriter.WriteLine(broadcastMessages[j]);
                        streamWriter.Flush();
                    }
                }
            }
            ClearBroadcast();
        }

        private void ClearBroadcast()
        {
            for (int i = 0; i < broadcastMessages.Count; i++)
            {
                broadcastMessages[i] = String.Empty;
            }
        }
    }
}
