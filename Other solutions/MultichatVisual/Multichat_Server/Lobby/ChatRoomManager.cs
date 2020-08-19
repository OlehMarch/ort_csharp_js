using Multichat_Server.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace Multichat_Server.Lobby
{
    public class ChatRoomManager
    {
        public ChatRoomManager(Connections conn)
        {
            chatRooms = new List<ChatRoom>();
            this.conn = conn;
            ChatRoomListChanged += conn.BroadCastSend;
            chatRoomListener = new Thread(new ThreadStart(ChatRoomListenLoop));
            chatRoomListener.Name = "ChatRoomListen Thread";
            chatRoomListener.Start();
        }


        private List<ChatRoom> chatRooms;
        private event EventHandler ChatRoomListChanged;
        private Connections conn;
        private Thread chatRoomListener;


        private void ChatRoomListenLoop()
        {
            while (true)
            {
                for (int i = 0; i < conn.ConnectionList.Count; i++)
                {
                    NetworkStream ns = conn.ConnectionList[i].ClientSocket.GetStream();
                    if (ns.DataAvailable)
                    {
                        StreamReader sr = new StreamReader(ns);
                        string message = sr.ReadLine();
                        DoRequest(LobbyFactory.GetRequest(message), message, conn.ConnectionList[i]);
                    }
                }
                ChatRoomsAdminListen();
            }
        }

        private void ChatRoomsAdminListen()
        {
            if (!Object.Equals(conn.ChatAdmin, null))
            {
                NetworkStream adminNs = conn.ChatAdmin.ClientSocket.GetStream();
                if (adminNs.DataAvailable)
                {
                    StreamReader sr = new StreamReader(adminNs);
                    string message = sr.ReadLine();
                    DoAdminRequest(LobbyFactory.GetRequest(message), message, conn.ChatAdmin);
                }
            }
        }


        #region Request handler
        private void DoAdminRequest(LobbyRequest request, string message, Admin chatAdmin)
        {
            message = message.Remove(0, message.IndexOf(":") + 1);
            StreamWriter sw = new StreamWriter(chatAdmin.ClientSocket.GetStream());

            switch (request)
            {
                case LobbyRequest.Connect:
                    {
                        DoRequestConnect(sw, message, chatAdmin);
                        chatAdmin.IsInRoom = true;
                        break;
                    }
                case LobbyRequest.Exit:
                    {
                        var roomExit = GetByName(message);
                        int ind = roomExit.GetAdminIndex();
                        roomExit.messageCounter[ind] = roomExit.messages;
                        chatAdmin.IsInRoom = false;
                        break;
                    }
                case LobbyRequest.Message:
                    {
                        DoRequestMessage(sw, message, chatAdmin);
                        break;
                    }
                case LobbyRequest.Refresh:
                    {
                        sw.WriteLine(GetMissedMessageCount(chatAdmin));
                        sw.Flush();
                        Thread.Sleep(100);
                        break;
                    }
                case LobbyRequest.Admin:
                    {
                        DoRequestAdmin(sw, message, chatAdmin);
                        break;
                    }

                default:
                    break;
            }
        }

        private void DoRequest(LobbyRequest request, string message, Client client)
        {
            message = message.Remove(0, message.IndexOf(":") + 1);
            StreamWriter sw = new StreamWriter(client.ClientSocket.GetStream());

            switch (request)
            {
                case LobbyRequest.Create:
                    {
                        if (!client.IsBanned)
                        {
                            DoRequestCreate(message, client);
                            sw.WriteLine("create:yes");
                            sw.Flush();
                            Thread.Sleep(100);
                        }
                        break;
                    }
                case LobbyRequest.Connect:
                    {
                        DoRequestConnect(sw, message, client);
                        client.IsInRoom = true;
                        break;
                    }
                case LobbyRequest.Exit:
                    {
                        var roomExit = GetByName(message);
                        int ind = roomExit.GetClientIndex(client);
                        roomExit.messageCounter[ind] = roomExit.messages;
                        client.IsInRoom = false;
                        break;
                    }
                case LobbyRequest.Message:
                    {
                        if (!client.IsBanned)
                        {
                            DoRequestMessage(sw, message, client);
                        }
                        break;
                    }
                case LobbyRequest.Refresh:
                    {
                        sw.WriteLine(GetMissedMessageCount(client));
                        sw.Flush();
                        Thread.Sleep(100);
                        break;
                    }
                case LobbyRequest.Logout:
                    {
                        var room = GetByName(message);
                        room.RemoveClient(client);
                        break;
                    }
                case LobbyRequest.Private:
                    {
                        DoRequestPrivate(sw, message, client.Name);
                        break;
                    }

                default:
                    break;
            }
        }

        private void DoRequestPrivate(StreamWriter sw, string message, string nameFrom)
        {
            var cmd = message.Split(',');

            switch (cmd[0])
            {
                case "refresh":
                    {
                        string names = String.Empty;
                        conn.ConnectionList.ForEach(cl =>
                        {
                            names += String.Format("{0},", cl.Name);
                        });
                        if (!names.Equals(String.Empty))
                        {
                            names = names.Remove(names.Length - 1);
                        }
                        sw.WriteLine("private:refresh," + names);
                        sw.Flush();
                        break;
                    }
                case "message":
                    {
                        var name = cmd[1];
                        var msg = cmd[2];

                        string key = MessageLogger.CheckExistanse(name, nameFrom);
                        if (key == null)
                        {
                            key = name + nameFrom;
                        }
                        MessageLogger.LogToFile(key, nameFrom + ": " + msg);

                        msg = MessageLogger.ReadFromFile(key);

                        var client = conn.GetByName(name);
                        var writer = new StreamWriter(client.ClientSocket.GetStream());
                        writer.WriteLine("private:message," + nameFrom + "," + msg);
                        writer.Flush();
                        break;
                    }

                default:
                    break;
            }
        }

        private void DoRequestAdmin(StreamWriter sw, string message, Client client)
        {
            var messages = message.Split(',');
            switch (messages[0])
            {
                case "ban":
                    {
                        Client banned = conn.GetByName(messages[1]);
                        int banTime = Convert.ToInt32(messages[2]);
                        banned.SetBan(banTime);
                        Thread.Sleep(50);
                        break;
                    }
                case "unban":
                    {
                        Client unbanned = conn.GetByName(messages[1]);
                        unbanned.Unban();
                        Thread.Sleep(50);
                        break;
                    }
                case "refresh":
                    {
                        string names = String.Empty;
                        conn.ConnectionList.ForEach(cl => {
                            names += String.Format("{0}{1},", cl.Name, (cl.IsBanned) ? " (Banned)" : "");
                        });
                        if (!names.Equals(String.Empty))
                        {
                            names = names.Remove(names.Length - 1);
                        }
                        sw.WriteLine("admin:refresh," + names);
                        sw.Flush();
                        break;
                    }
            }
        }

        private void DoRequestConnect(StreamWriter sw, string message, Client client)
        {
            var room = GetByName(message);
            if (!room.ClientExists(client))
            {
                GetByName(message).AddClient(client);
            }
            sw.WriteLine("connect:yes," + MessageLogger.ReadFromFile(message));
            sw.Flush();
        }

        private void DoRequestMessage(StreamWriter sw, string message, Client client)
        {
            var args = message.Split(',');
            var chatRoom = GetByName(args[0]);

            sw.Flush();
            args[1] = client.Name + ": " + args[1];

            MessageLogger.LogToFile(args[0], args[1]);
            chatRoom.Say(args[1]);
            chatRoom.messages++;

            Thread.Sleep(100);
        }

        public void DoRequestCreate(string name, Client iniClient)
        {
            var room = new ChatRoom(name, iniClient);
            chatRooms.Add(room);
            iniClient.IsInRoom = true;
            if (!Object.Equals(conn.ChatAdmin, null))
            {
                // room enter
                room.AddClient(conn.ChatAdmin);
                // room exit
                int ind = room.GetAdminIndex();
                room.messageCounter[ind] = room.messages;
            }
            SendBroadCast();
        }
        #endregion

        #region Broadcasting methods
        public void SendBroadCast()
        {
            ChatRoomListChanged(GetChatRoomNames(), null);
        }

        private string GetChatRoomNames()
        {
            string chatRoomNames = String.Empty;

            if (chatRooms.Count != 0)
            {
                chatRooms.ForEach(chat =>
                {
                    chatRoomNames += chat.Name + ",";
                });
                chatRoomNames = chatRoomNames.Remove(chatRoomNames.Length - 1);
            }

            return "broadcast:" + chatRoomNames;
        }

        public string GetMissedMessageCount(Client client)
        {
            string res = "refresh:";

            chatRooms.ForEach(room =>
            {
                res += room.Name;
                if (room.ClientExists(client))
                {
                    int diffrence = room.messages - room.messageCounter[room.GetClientIndex(client)];
                    if (!client.IsInRoom)
                    {
                        res += String.Format(" ({0})", diffrence);
                    }
                }
                res += ",";
            });
            if (res.EndsWith(","))
            {
                res = res.Remove(res.Length - 1);
            }

            return res;
        }
        #endregion

        public ChatRoom GetByName(string roomName)
        {
            if (roomName.Contains("("))
            {
                roomName = roomName.Remove(roomName.IndexOf("("));
                roomName = roomName.TrimEnd();
            }

            var room = from r in chatRooms
                       where r.Name.Equals(roomName)
                       select r;

            return room.First();
        }

        public void AdminRoomConnection(object sender, EventArgs e)
        {
            Admin admin = sender as Admin;
            chatRooms.ForEach(chat => {
                chat.AddClient(admin);
            });
        }

    }
}
