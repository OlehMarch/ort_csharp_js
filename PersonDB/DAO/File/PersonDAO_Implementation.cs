using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public static class PersonDAO_Implementation
    {
        public static IPersonDAO GetInstance(int index)
        {
            IPersonDAO daoDB = null;
            switch (index)
            {
                case 0: { daoDB = new PersonDAO_Mock(); break; }
                case 1: { daoDB = new PersonDAO_H2(); break; }
                case 2: { daoDB = new PersonDAO_MsSQL(); break; }
                case 3: { daoDB = new PersonDAO_MySQL(); break; }
                case 4: { daoDB = new PersonDAO_Mongo(); break; }
                case 5: { daoDB = new PersonDAO_Redis(); break; }
                case 6: { daoDB = new PersonDAO_Neo4j(); break; }
                case 7: { daoDB = new PersonDAO_CSV(); break; }
                case 8: { daoDB = new PersonDAO_JSON(); break; }
                case 9: { daoDB = new PersonDAO_XML(); break; }
                case 10: { daoDB = new PersonDAO_YML(); break; }
                case 11: { daoDB = new PersonDAO_CSV_Ex(); break; }
                case 12: { daoDB = new PersonDAO_YML_Ex(); break; }
                case 13: { daoDB = new PersonDAO_XML_Ex(); break; }
                case 14: { daoDB = new PersonDAO_JSON_Ex(); break; }
                case 15: { daoDB = new PersonDAO_Cassandra(); break; }
                case 16: { daoDB = new PersonDAO_Entity(); break; }
                case 17: { daoDB = new PersonDAO_Nhibernate(); break; }
            }
            return daoDB;
        }
    }
}
