using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultichatVisual.API
{
    public class RequestCommand
    {
        public RequestCommand(EventHandler handler)
        {
            send = handler;
        }


        private EventHandler send;


        public void Message(string roomName, string message)
        {
            send("message:" + roomName + "," + message, null);
        }

        public void Exit(string roomName)
        {
            send("exit:" + roomName, null);
        }

        public void Logout(string chatRoomName)
        {
            send("logout:" + chatRoomName, null);
        }

        public void Create(string chatRoomName)
        {
            send("create:" + chatRoomName, null);
        }

        public void Connect(string chatRoomName)
        {
            send("connect:" + chatRoomName, null);
        }

        public void LoginAdmin()
        {
            send("login:admin", null);
        }

        public void LoginClient(string userName)
        {
            send("login:user," + userName, null);
        }

        public void AdminRefresh()
        {
            send("admin:refresh", null);
        }

        public void AdminBan(string name, int banTime)
        {
            send("admin:ban," + name + "," + banTime, null);
        }

        public void AdminUnban(string name)
        {
            send("admin:unban," + name, null);
        }

        public void PrivateRefresh()
        {
            send("private:refresh", null);
        }

        public void PrivateMessage(string nameTo, string message)
        {
            send("private:message," + nameTo + "," + message, null);
        }

    }
}
