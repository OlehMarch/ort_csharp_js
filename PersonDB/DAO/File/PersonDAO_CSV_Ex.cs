using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
using System.IO;

namespace PersonDB
{
    public class PersonDAO_CSV_Ex : APersonDao
    {
        public override string ConnectionString
        {
            get;
            set;
        }

        public PersonDAO_CSV_Ex()
        {
            ConnectionString = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB_Ex.csv";
        }

        public override void Writer(List<Person> personList)
        {
            var serializedValue = CsvSerializer.SerializeToCsv<Person>(personList);
            StreamWriter writer = new StreamWriter(ConnectionString);
            writer.Write(serializedValue);
            writer.Close();
            writer.Dispose();
        }

        public override List<Person> Reader()
        {
            StreamReader reader = new StreamReader(ConnectionString);

            var result = CsvSerializer.DeserializeFromReader<List<Person>>(reader);
            reader.Close();
            reader.Dispose();
            return result;
        }
    }
}
