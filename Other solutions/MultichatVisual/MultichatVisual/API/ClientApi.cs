using MultichatVisual.UI.Moderate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ChatForm = MultichatVisual.UI.Chat.Chat;

namespace MultichatVisual.API
{
    public class ClientApi
    {
        public ClientApi(EventHandler BroadcastHandle, ChatForm chat, ModerateForm moderate)
        {
            Port = 8888;
            this.chat = chat;
            this.moderate = moderate;
            this.BroadcastHandle = BroadcastHandle;
            clientSocket = new TcpClient("localhost", Port);
            threadListener = new Thread(new ThreadStart(ListenLoop));
        }


        private TcpClient clientSocket;
        private Thread threadListener;
        private EventHandler BroadcastHandle;
        private ChatForm chat;
        private ModerateForm moderate;
        private readonly int Port;


        public void ThreadStart()
        {
            threadListener.Start();
        }

        private void ListenLoop()
        {
            var ns = clientSocket.GetStream();

            while (true)
            {
                var sr = new StreamReader(ns);
                if (ns.DataAvailable)
                {
                    var message = sr.ReadLine();
                    var resp = ResponseFactory.GetResponse(message);
                    DoResponse(resp, message);
                }
            }
        }

        private void DoResponse(ServerResponse servResp, string message)
        {
            message = message.Remove(0, message.IndexOf(":") + 1);

            switch (servResp)
            {
                case ServerResponse.Create:
                    {
                        if (message.Equals("yes"))
                        {
                            new Thread(new ThreadStart(() => chat.ShowDialog())).Start();
                        }
                        break;
                    }
                case ServerResponse.Connect:
                    {
                        if (message.StartsWith("yes"))
                        {
                            message = message.Remove(0, 4);
                            chat.SetMessages(message);
                            new Thread(new ThreadStart(() => chat.ShowDialog())).Start();
                        }
                        break;
                    }
                case ServerResponse.Broadcast:
                    {
                        Say("refresh:");
                        break;
                    }
                case ServerResponse.Message:
                    {
                        chat.Say(message);
                        Thread.Sleep(100);
                        Say("refresh:");
                        break;
                    }
                case ServerResponse.Refresh:
                    {
                        BroadcastHandle(message, null);
                        break;
                    }
                case ServerResponse.Admin:
                    {
                        DoResponseAdmin(message);
                        break;
                    }
                case ServerResponse.Private:
                    {
                        DoResponsePrivate(message);
                        break;
                    }

                default:
                    break;
            }
        }

        private void DoResponsePrivate(string message)
        {
            var cmd = message.Remove(message.IndexOf(","));
            message = message.Replace(cmd + ",", "");

            switch (cmd)
            {
                case "refresh":
                    {
                        chat.SetUsers(message);
                        break;
                    }
                case "message":
                    {
                        var nameFrom = message.Remove(message.IndexOf(","));
                        message = message.Replace(nameFrom + ",", "");
                        message = message.Replace(",", "\r\n");

                        System.Windows.Forms.MessageBox.Show(message, "From " + nameFrom,
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                        break;
                    }

                default:
                    break;
            }
        }

        private void DoResponseAdmin(string message)
        {
            message = message.Remove(0, message.IndexOf(",") + 1);
            var names = message.Split(',');
            moderate.UpdateUserList(names);
        }

        public void SayBridge(object sender, EventArgs e)
        {
            Say(sender as string);
        }

        public void Say(string message)
        {
            var sw = new StreamWriter(clientSocket.GetStream());
            sw.WriteLine(message);
            sw.Flush();
        }
    }
}
