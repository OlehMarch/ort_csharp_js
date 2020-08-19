using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PersonDB
{
    public class PersonDAO_JSON_Ex : APersonDao
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


        public PersonDAO_JSON_Ex()
        {
            pathToFile = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB_Ex.json";
        }

        #region Additional functions

        public override List<Person> Reader()
        {
            StreamReader fs = new StreamReader(pathToFile);
            string jsonString = fs.ReadToEnd();
            fs.Dispose();

            List<Person> personList = JsonConvert.DeserializeObject<List<Person>>(jsonString);

            if (personList == null)
            {
                personList = new List<Person>();
            }
            return personList;
        }

        public override void Writer(List<Person> personList)
        {
            StreamWriter fs = new StreamWriter(pathToFile);
            fs.Write(JsonConvert.SerializeObject(personList));
            fs.Dispose();
        }

        #endregion

    }
}
