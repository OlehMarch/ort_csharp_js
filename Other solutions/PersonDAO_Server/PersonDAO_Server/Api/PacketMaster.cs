using PersonDAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PersonDAO_Server.Api
{
    public class PacketMaster
    {
        public string CreateResponsePacket(IEnumerable<Person> persons)
        {
            string result = null;
            var readPacket = new PersonPacket("READ", (List<Person>)persons);
            XmlSerializer serializer = new XmlSerializer(typeof(PersonPacket));
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, readPacket);
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
