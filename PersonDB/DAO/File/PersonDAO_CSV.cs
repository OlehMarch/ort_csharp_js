using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public class PersonDAO_CSV : APersonDao
    {
        private string pathToFile;

        public override string ConnectionString
        {
            set { pathToFile = value; }
            get { return pathToFile; }
        }

        public PersonDAO_CSV()
        {
            pathToFile = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB.csv";
        }
       
        #region Additional functions

        public override List<Person> Reader()
        {
            var personList = new List<Person>();
            StreamReader fs = new StreamReader(pathToFile);

            while (!fs.EndOfStream)
            {
                string currLine = fs.ReadLine();

                if (currLine.Trim() == "" || currLine.Trim() == "Id,FirstName,LastName,Age")
                {
                    continue;
                }

                string[] personDataStorage = currLine
                    .Replace(", ", "; ")
                    .Replace("\",", ",")
                    .Replace(",\"", ",")
                    .Replace("\"\"", "\"")
                    .Split(',');

                personList.Add(
                    new Person(
                        Convert.ToUInt32(personDataStorage[0]),
                        personDataStorage[1].Replace("; ", ", "),
                        personDataStorage[2].Replace("; ", ", "),
                        Convert.ToUInt32(personDataStorage[3])
                    )
                );
            }

            fs.Dispose();
            return personList;
        }

        public override void Writer(List<Person> personList)
        {
            string persons = "Id,FirstName,LastName,Age" + Environment.NewLine;
            for (int i = 0; i < personList.Count; ++i)
            {
                persons += personList[i].Id + ",\""
                    + personList[i].FirstName.Replace("\"", "\"\"") + "\",\""
                    + personList[i].LastName.Replace("\"", "\"\"") + "\","
                    + personList[i].Age + Environment.NewLine;
            }

            StreamWriter fs = new StreamWriter(pathToFile);
            fs.WriteLine(persons);
            fs.Dispose();
        }
        #endregion

    }
}
