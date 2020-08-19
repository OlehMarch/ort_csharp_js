using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDAO
{
    public sealed class PersonDAO_Mock : IPersonDAO
    {
        private List<Person> personList;

        public PersonDAO_Mock()
        {
            personList = new List<Person>();
            personList.Add(new Person(1, "Аркадий", "Райкин", 80));
            personList.Add(new Person(2, "Евгений", "Петросян", 35));
            personList.Add(new Person(3, "Дмитрий", "Павлоградов", 100));
            personList.Add(new Person(4, "Василий", "Пупкин", 56));
            personList.Add(new Person(5, "Василий", "Алибабаевич", 45));
            personList.Add(new Person(6, "Святослав", "Гуляев", 68));
            personList.Add(new Person(7, "Александр", "Пюшкин", 35));
            personList.Add(new Person(8, "Марат", "Абубабебобич", 25));
            personList.Add(new Person(9, "Акакий", "Петруханов", 46));
            personList.Add(new Person(10, "Дмитрий", "Кокшенов", 56));
            personList.Add(new Person(11, "Григорий", "Саркисян", 48));
            personList.Add(new Person(12, "Алексей", "Пух", 18));
            personList.Add(new Person(13, "Марат", "Суркис", 40));
            personList.Add(new Person(14, "Антон", "Павлов", 68));
            personList.Add(new Person(15, "Давид", "Марков", 31));
            personList.Add(new Person(16, "Альберт", "Дорн", 19));
            personList.Add(new Person(17, "Вячеслав", "Суров", 13));
            personList.Add(new Person(18, "Александра", "Бородач", 36));
            personList.Add(new Person(19, "Константин", "Ронин", 24));
            personList.Add(new Person(20, "Савва", "Хоботов", 15));
            personList.Add(new Person(21, "Диоген", "Бочковой", 91));
            personList.Add(new Person(22, "Платон", "Арчебальдович", 18));
            personList.Add(new Person(23, "Светлана", "Забодаева", 28));
            personList.Add(new Person(24, "Уха", "Лобзиковна", 25));
            personList.Add(new Person(25, "Григорий", "Саруханов", 76));
        }

        public string ConnectionString
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Create(Person persona)
        {
            this.personList.Add(new Person(persona));
        }

        public void Delete(Person persona)
        {
            personList.Remove(personList.First(p => p.Id == persona.Id));
        }

        public IEnumerable<Person> Read()
        {
            return this.personList;
        }

        public void Update(Person persona)
        {
            foreach (var item in personList)
            {
                if (item.Id == persona.Id)
                {
                    item.FirstName = persona.FirstName;
                    item.LastName = persona.LastName;
                    item.Age = persona.Age;
                    break;
                }
            }
        }
    }
}
