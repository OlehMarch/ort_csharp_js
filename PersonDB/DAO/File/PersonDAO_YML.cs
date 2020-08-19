using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public class PersonDAO_YML : APersonDao
    {
        private string pathToFile;
        public override string ConnectionString
        {
            set { pathToFile = value; }
            get { return pathToFile; }
        }


        public PersonDAO_YML()
        {
            pathToFile = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB.yml";
        }

        #region Additional functions
       
        public override List<Person> Reader()
        {
            var personList = new List<Person>();
            StreamReader fs = new StreamReader(pathToFile);

            while (!fs.EndOfStream)
            {
                string currLine = fs.ReadLine().TrimStart();

                if (currLine.StartsWith("Persons:"))
                {
                    continue;
                }
                if (currLine.StartsWith("-"))
                {
                    string[] temp = currLine.Replace("-", "").Replace("}", "").Replace("{", "").Replace(", ", ",").Trim().Split(',');
                    personList.Add(
                        new Person(
                            Convert.ToUInt32(GetData(temp[0])),
                            GetData(temp[1]),
                            GetData(temp[2]),
                            Convert.ToUInt32(GetData(temp[3]))
                        )
                    );
                    continue;
                }
            }
            fs.Dispose();
            return personList;
        }

        public override void Writer(List<Person> personList)
        {
            string persons = "Persons:" + Environment.NewLine;
            for (int i = 0; i < personList.Count; ++i)
            {
                persons += " - {";
                persons += String.Format("id: {0},", personList[i].Id);
                persons += String.Format(" firstName: '{0}',", personList[i].FirstName);
                persons += String.Format(" lastName: '{0}',", personList[i].LastName);
                persons += String.Format(" age: {0}", personList[i].Age);
                persons += "}" + Environment.NewLine;
            }

            StreamWriter fs = new StreamWriter(pathToFile);
            fs.Write(persons);
            fs.Dispose();
        }

        private string GetData(string ini)
        {
            return ini.Split(':')[1].Replace("'", "").Replace(",", "").Trim();
        }

        #endregion

    }
}
