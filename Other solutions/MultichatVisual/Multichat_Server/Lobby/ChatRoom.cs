using Multichat_Server.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multichat_Server.Lobby
{
    public class ChatRoom
    {
        public ChatRoom(string name, Client iniClient)
        {
            Name = name;
            clients = new List<Client>();
            messageCounter = new List<int>();
            clients.Add(iniClient);
            messageCounter.Add(0);
            messages = 0;
        }


        public string Name { get; set; }
        private List<Client> clients;
        public List<int> messageCounter;
        public int messages;


        public void AddClient(Client client)
        {
            clients.Add(client);
            messageCounter.Add(0);
        }

        public void RemoveClient(Client client)
        {
            int ind = GetClientIndex(client);
            clients.RemoveAt(ind);
            messageCounter.RemoveAt(ind);
        }

        public bool ClientExists(Client client)
        {
            return clients.Any(c => c.Name.Equals(client.Name));
        }

        public void Say(string message)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                var sw = new StreamWriter(clients[i].ClientSocket.GetStream());
                sw.WriteLine("message:" + message);
                sw.Flush();
            }
        }

        public int GetClientIndex(Client client)
        {
            int ind = 0;

            ind = clients.IndexOf(client);

            return ind;
        }

        public int GetAdminIndex()
        {
            int ind = 0;

            ind = clients.IndexOf(clients.First(cl => cl.Name.Equals("Admin")));

            return ind;
        }

    }
}
