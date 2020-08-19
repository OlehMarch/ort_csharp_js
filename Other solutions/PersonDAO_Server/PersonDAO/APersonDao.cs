using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PersonDAO
{
    public abstract class APersonDao : IPersonDAO
    {
        public abstract string ConnectionString
        {
            get;
            set;
        }

        public abstract List<Person> Reader();
        public abstract void Writer(List<Person> personList);

        public void CheckConnectionAbility()
        {
            if (!File.Exists(ConnectionString))
            {
                throw new FileNotFoundException();
            }
        }

        public void Create(Person person)
        {
            List<Person> personList = null;
            CheckConnectionAbility();

            personList = Reader();
            personList.Add(person);

            Writer(personList);
        }

        public IEnumerable<Person> Read()
        {
            CheckConnectionAbility();
            List<Person> personList = null;
            personList = Reader();

            return personList;
        }

        public void Update(Person person)
        {
            CheckConnectionAbility();
            List<Person> personList = null;
            personList = Reader();
            foreach (var item in personList)
            {
                if (item.Id == person.Id)
                {
                    item.FirstName = person.FirstName;
                    item.LastName = person.LastName;
                    item.Age = person.Age;
                    break;
                }
            }

            Writer(personList);
        }

        public void Delete(Person person)
        {
            CheckConnectionAbility();

            List<Person> personList = null;
            personList = Reader();
            personList.Remove(personList.First<Person>(persona => persona.Id == person.Id));
            Writer(personList);
        }
    }
}
