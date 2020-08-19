using PersonDAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PersonDAO_Client.Api
{
    public class PacketMaster
    {
        public string CreatePacket(string packetType, Person persona)
        {
            string result = null;
            PersonPacket packet = null;
            List<Person> persons = new List<Person>();
            persons.Add(persona);
            switch (packetType)
            {
                case "CREATE":
                    {
                        packet = new PersonPacket(packetType, persons);
                        break;
                    }
                case "READ":
                    {
                        packet = new PersonPacket(packetType, null);
                        break;
                    }
                case "UPDATE":
                    {
                        packet = new PersonPacket(packetType, persons);
                        break;
                    }
                case "DELETE":
                    {
                        packet = new PersonPacket(packetType, persons);
                        break;
                    }
            }

            XmlSerializer serializer = new XmlSerializer(typeof(PersonPacket));
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, packet);
                result = textWriter.ToString();
            }

            return result;
        }

        public PersonPacket DecodePacket(string packet)
        {
            PersonPacket inPacket = null;
            XmlSerializer serializer = new XmlSerializer(typeof(PersonPacket));
            using (StringReader textReader = new StringReader(packet))
            {
                inPacket = (PersonPacket)serializer.Deserialize(textReader);
            }
            return inPacket;
        }
    }
}
