using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multichat_Server.Lobby
{
    public enum LobbyRequest
    {
        Create,
        Connect,
        Exit,
        Message,
        Refresh,
        Admin,
        Logout,
        Private
    }
}
