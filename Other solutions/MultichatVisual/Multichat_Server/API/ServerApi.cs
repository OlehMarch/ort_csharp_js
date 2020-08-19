using Multichat_Server.Auth;
using Multichat_Server.Lobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multichat_Server.API
{
    public class ServerApi
    {
        public ServerApi()
        {
            Initialize();
        }


        private int Port = 8888;
        private TcpListener listener;
        private Thread threadListener;
        private Connections connections;
        private ChatRoomManager manager;


        private void ListenLoop()
        {
            listener.Start();

            while (true)
            {
                connections.AddConnection(listener.AcceptTcpClient());
                manager.SendBroadCast();
            }
        }
        
        private void Initialize()
        {
            connections = new Connections();
            manager = new ChatRoomManager(connections);
            connections.AdminConnectRoomHandler = manager.AdminRoomConnection;
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), Port);
            threadListener = new Thread(new ThreadStart(ListenLoop));
            threadListener.Name = "Connection Thread";
            threadListener.Start();
        }

    }
}
