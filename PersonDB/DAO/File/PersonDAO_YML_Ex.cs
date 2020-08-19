using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using YamlDotNet.Serialization;

namespace PersonDB
{
    public class PersonDAO_YML_Ex : APersonDao
    {
        public override string ConnectionString
        {
            get;
            set;
        }

        public PersonDAO_YML_Ex()
        {
            ConnectionString = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB_Ex.yml";
        }

        public override void Writer(List<Person> personList)
        {
            Serializer serializer = new Serializer();
            StreamWriter writer = new StreamWriter(ConnectionString);
            serializer.Serialize(writer, personList);
            writer.Close();
            writer.Dispose();
        }

        public override List<Person> Reader()
        {
            StreamReader reader = new StreamReader(ConnectionString);
            Deserializer serializer = new Deserializer();
            List<Person> personList = serializer.Deserialize<List<Person>>(reader);
            reader.Close();
            reader.Dispose();
            return personList;
        }
    }
}
