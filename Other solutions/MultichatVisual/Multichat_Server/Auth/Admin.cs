using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Multichat_Server.Auth
{
    public class Admin : Client
    {
        public Admin(TcpClient socket)
        {
            this.Name = "Admin";
            this.ClientSocket = socket;
        }
    }
}
