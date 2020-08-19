using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PersonDB.DAO.File
{
    public class PersonDAO_XML_Reflection : APersonDao
    {
        public override string ConnectionString { get; set; }

        public PersonDAO_XML_Reflection()
        {
            ConnectionString = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB.xml";
        }

        #region Additional functions
        private Person SetPersonWithValuesViaReflection(uint id, string fName, string lName, uint age)
        {
            var persona = new Person();
            var type = persona.GetType();
            var properties = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            properties[0].SetValue(persona, id);
            properties[1].SetValue(persona, fName);
            properties[2].SetValue(persona, lName);
            properties[3].SetValue(persona, age);
            return persona;
        }

        public override List<Person> Reader()
        {
            List<Person> personList = new List<Person>();
            StreamReader fs = new StreamReader(ConnectionString);
            List<string> personDataStorage = new List<string>();

            while (!fs.EndOfStream)
            {
                string currLine = fs.ReadLine();

                if (currLine.Contains("<Person") || currLine.Trim() == "</Persons>")
                {
                    continue;
                }
                if (currLine.Trim() == "</Person>")
                {
                    personList.Add(
                        SetPersonWithValuesViaReflection(
                            Convert.ToUInt32(personDataStorage[0]),
                            personDataStorage[1],
                            personDataStorage[2],
                            Convert.ToUInt32(personDataStorage[3])
                        )
                    );
                    personDataStorage = new List<string>();
                    continue;
                }

                personDataStorage.Add(
                    currLine.Remove(currLine.LastIndexOf('<')).Remove(0, currLine.IndexOf('>') + 1)
                );
            }
            fs.Dispose();
            return personList;
        }

        public override void Writer(List<Person> personList)
        {
            string persons = "<Persons>" + Environment.NewLine;
            for (int i = 0; i < personList.Count; ++i)
            {
                var type = personList[i].GetType();
                var properties = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                uint id = (uint)properties[0].GetValue(personList[i]);
                string fName = (string)properties[1].GetValue(personList[i]);
                string lName = (string)properties[2].GetValue(personList[i]);
                uint age = (uint)properties[3].GetValue(personList[i]);

                persons += "  <Person>" + Environment.NewLine;
                persons += String.Format("    <id>{0}</id>", id) + Environment.NewLine;
                persons += String.Format("    <firstName>{0}</firstName>", fName) + Environment.NewLine;
                persons += String.Format("    <lastName>{0}</lastName>", lName) + Environment.NewLine;
                persons += String.Format("    <age>{0}</age>", age) + Environment.NewLine;
                persons += "  </Person>" + Environment.NewLine;
            }
            persons += "</Persons>";

            StreamWriter fs = new StreamWriter(ConnectionString);
            fs.WriteLine(persons);
            fs.Dispose();
        }
        #endregion

    }
}
