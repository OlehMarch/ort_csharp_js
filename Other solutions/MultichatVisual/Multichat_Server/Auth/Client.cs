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
    public class Client
    {
        public string Name { get; set; }
        public TcpClient ClientSocket { get; set; }
        public bool IsInRoom { get; set; }
        public bool IsBanned { get; private set; }
        private Timer UnbanTimer { get; set; }

        public Client(string name, TcpClient client)
        {
            ClientSocket = client;
            Name = name;
            IsInRoom = false;
            UnbanTimer = new Timer(new TimerCallback((o) => { Unban(); }));
        }

        public Client() { }

        public void SetBan(int banTime)
        {
            if (banTime != 0)
            {
                banTime *= 1000;
                UnbanTimer.Change(banTime, Timeout.Infinite);
            }
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
            UnbanTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

    }
}
