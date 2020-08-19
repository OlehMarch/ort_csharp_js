using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public class PersonDAO_XML : APersonDao
    {
        private string pathToFile;
        public override string ConnectionString
        {
            set { pathToFile = value; }
            get { return pathToFile; }
        }

        public PersonDAO_XML()
        {
            pathToFile = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB.xml";
        }

        #region Additional functions

        public override List<Person> Reader()
        {
            List<Person> personList = new List<Person>();
            StreamReader fs = new StreamReader(pathToFile);
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
                        new Person(
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
                persons += "  <Person>" + Environment.NewLine;
                persons += String.Format("    <id>{0}</id>", personList[i].Id) + Environment.NewLine;
                persons += String.Format("    <firstName>{0}</firstName>", personList[i].FirstName) + Environment.NewLine;
                persons += String.Format("    <lastName>{0}</lastName>", personList[i].LastName) + Environment.NewLine;
                persons += String.Format("    <age>{0}</age>", personList[i].Age) + Environment.NewLine;
                persons += "  </Person>" + Environment.NewLine;
            }
            persons += "</Persons>";

            StreamWriter fs = new StreamWriter(pathToFile);
            fs.WriteLine(persons);
            fs.Dispose();
        }

        #endregion

    }
}
