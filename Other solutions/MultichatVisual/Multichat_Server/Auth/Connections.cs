using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multichat_Server.Auth
{
    public class Connections
    {
        public Connections()
        {
            ConnectionList = new List<Client>();
        }


        public List<Client> ConnectionList { get; set; }
        public Admin ChatAdmin { set; get; }
        public EventHandler AdminConnectRoomHandler { set; get; }


        public Client GetByName(string name)
        {
            var client = from cl in ConnectionList
                         where cl.Name.Equals(name)
                         select cl;

            return client.First();
        }

        public void AddConnection(TcpClient socket)
        {
            ListenForName(socket);
        }

        #region Listening
        private void ListenForName(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);

            while (true)
            {
                if (ns.DataAvailable)
                {
                    string message = sr.ReadLine();
                    LoginType(message, socket);
                    break;
                }

                Thread.Sleep(100);
            }
        }

        private void LoginType(string message, TcpClient socket)
        {
            message = message.Remove(0, message.IndexOf(":") + 1);
            var cmd = message.Split(',');

            switch (cmd[0])
            {
                case "admin":
                    ChatAdmin = new Admin(socket);
                    AdminConnectRoomHandler(ChatAdmin, null);
                    break;
                case "user":
                    ConnectionList.Add(new Client(cmd[1], socket));
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Broadcasting
        public void BroadCastSend(object sender, EventArgs e)
        {
            var broadcastMessage = sender as string;
            SendToClients(broadcastMessage);
            SendToAdmin(broadcastMessage);
        }

        private void SendToClients(string message)
        {
            StreamWriter sw = null;
            for (int i = 0; i < ConnectionList.Count; i++)
            {
                sw = new StreamWriter(ConnectionList[i].ClientSocket.GetStream());
                sw.WriteLine(message);
                sw.Flush();
            }
        }

        private void SendToAdmin(string message)
        {
            if (!Object.Equals(ChatAdmin, null))
            {
                StreamWriter sw = null;
                sw = new StreamWriter(ChatAdmin.ClientSocket.GetStream());
                sw.WriteLine(message);
                sw.Flush();
            }
        }
        #endregion

    }
}
