using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDAO
{
    public class PersonPacket
    {
        public string QueryType { set; get; } // Create | Read | Update | Delete
        public List<Person> Persons { set; get; }

        public PersonPacket(string queryType, List<Person> persons)
        {
            this.QueryType = queryType;
            this.Persons = persons;
        }

        public PersonPacket()
        {
            QueryType = "";
            Persons = new List<Person>();
        }
    }
}
