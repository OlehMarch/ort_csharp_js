using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public class PersonDAO_JSON : APersonDao
    {
        private string pathToFile;
        public override string ConnectionString
        {
            set { pathToFile = value; }
            get { return pathToFile; }
        }

        public PersonDAO_JSON()
        {
            pathToFile = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB.json";
        }



        #region Additional functions
       
        public override List<Person> Reader()
        {
            var personList = new List<Person>();
            StreamReader fs = new StreamReader(pathToFile);
            string currLine = fs.ReadLine();
            if (currLine == null || currLine == "" || currLine == "{ }")
            {
                fs.Dispose();
                return personList;
            }
            string[] persons = currLine.Replace("{", "").Replace("},", "}").Replace("} }", "").Trim().Split('}');
            fs.Dispose();
            List<string> personDataStorage = new List<string>();

            for (int i = 0; i < persons.Length; ++i)
            {
                string[] temp = persons[i].Split(',');
                personList.Add(
                    new Person(
                        Convert.ToUInt32(GetData(temp[0])),
                        GetData(temp[1]),
                        GetData(temp[2]),
                        Convert.ToUInt32(GetData(temp[3]))
                    )
                );
            }
            return personList;
        }

        private string GetData(string ini)
        {
            return ini.Split(':')[1].Replace("\"", "").Replace(",", "").Trim();
        }

        public override void Writer(List<Person> personList)
        {
            string persons = "{ ";
            for (int i = 0; i < personList.Count; ++i)
            {
                persons += "{";
                persons += String.Format(" \"id\": {0},", personList[i].Id);
                persons += String.Format(" \"firstName\": \"{0}\",", personList[i].FirstName);
                persons += String.Format(" \"lastName\": \"{0}\",", personList[i].LastName);
                persons += String.Format(" \"age\": {0}", personList[i].Age);
                persons += " }, ";
            }
            if (personList.Count > 0)
            {
                persons = persons.Remove(persons.LastIndexOf(","), 1);
            }
            persons += "}";

            StreamWriter fs = new StreamWriter(pathToFile);
            fs.Write(persons);
            fs.Dispose();
        }
        #endregion

    }
}
