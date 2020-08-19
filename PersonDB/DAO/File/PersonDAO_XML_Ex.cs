using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PersonDB
{
    public sealed class PersonDAO_XML_Ex : APersonDao
    {
        private string pathToFile;
        public override string ConnectionString
        {
            get
            {
                return pathToFile;
            }
            set
            {
                pathToFile = value;
            }
        }


        public PersonDAO_XML_Ex()
        {
            pathToFile = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB_Ex.xml";
        }

        #region Additional functions

        public override List<Person> Reader()
        {
            StreamReader reader = new StreamReader(ConnectionString);
            List<Person> personList = (List<Person>)new XmlSerializer(typeof(List<Person>)).Deserialize(reader);
            reader.Close();
            reader.Dispose();
            return personList;
        }

        public override void Writer(List<Person> personList)
        {
            StreamWriter writer = new StreamWriter(pathToFile);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            serializer.Serialize(writer, personList);
            writer.Close();
            writer.Dispose();
        }

        #endregion

    }
}
