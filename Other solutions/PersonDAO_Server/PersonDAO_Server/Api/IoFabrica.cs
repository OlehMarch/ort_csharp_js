using PersonDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDAO_Server.Api
{
    public class IoFabrica
    {
        private PacketMaster master;
        private IPersonDAO dao;
        private event EventHandler Reply;

        public IoFabrica(EventHandler replyMethod)
        {
            master = new PacketMaster();
            dao = new PersonDAO_Mock();
            Reply += replyMethod;
        }

        public void CrudListen(string incomeMessage)
        {
            var packet = master.DecodePacket(incomeMessage);
            switch (packet.QueryType)
            {
                case "READ":
                    {
                        string reply = master.CreateResponsePacket(dao.Read());
                        byte[] replyMessage = Encoding.UTF8.GetBytes(reply);
                        Reply(replyMessage, null);
                        break;
                    }
                case "CREATE":
                    {
                        dao.Create(packet.Persons[0]);
                        break;
                    }
                case "UPDATE":
                    {
                        dao.Update(packet.Persons[0]);
                        break;
                    }
                case "DELETE":
                    {
                        dao.Delete(packet.Persons[0]);
                        break;
                    }
            }
        }
    }
}
