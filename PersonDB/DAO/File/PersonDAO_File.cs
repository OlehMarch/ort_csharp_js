using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public sealed class PersonDAO_File
    {
        private IPersonDAO daoDB = null;

        public PersonDAO_File(int index)
        {
            //this.daoDB = PersonDAO_Implementation.GetInstance(index);
            daoDB = PersonDAO_DynamicImplementation.GetDynamicInstance(index);
        }

        public void Create(Person persona)
        {
            daoDB.Create(persona);
        }

        public IEnumerable<Person> Read()
        {
            List<Person> list = null;
            list = (List<Person>)daoDB.Read();
            return list;
        }

        public void Update(Person persona)
        {
            daoDB.Update(persona);
        }

        public void Delete(Person persona)
        {
            daoDB.Delete(persona);
        }
    }
}
