using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multichat_Server.Lobby
{
    public static class LobbyFactory
    {
        public static LobbyRequest GetRequest(string cmd)
        {
            cmd = cmd.Remove(cmd.IndexOf(":"));
            LobbyRequest req = LobbyRequest.Create;
            switch (cmd)
            {
                case "create":
                    req = LobbyRequest.Create;
                    break;
                case "connect":
                    req = LobbyRequest.Connect;
                    break;
                case "exit":
                    req = LobbyRequest.Exit;
                    break;
                case "message":
                    req = LobbyRequest.Message;
                    break;
                case "refresh":
                    req = LobbyRequest.Refresh;
                    break;
                case "admin":
                    req = LobbyRequest.Admin;
                    break;
                case "logout":
                    req = LobbyRequest.Logout;
                    break;
                case "private":
                    req = LobbyRequest.Private;
                    break;

                default:
                    break;
            }

            return req;
        }
    }
}
