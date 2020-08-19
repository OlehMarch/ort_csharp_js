using SQLite;

namespace NativePortable
{
    public class Person : Realms.RealmObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public Person(int id, string name, string lastName, int age, string phone, string mail)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Age = age;
            Phone = phone;
            Mail = mail;
        }

        public Person()
        {
            Id = default(int);
            Name = default(string);
            LastName = default(string);
            Age = default(int);
            Phone = default(string);
            Mail = default(string);
        }

        public override string ToString()
        {
            return string.Format("[Person: Id={0}, Name={1}, LastName={2}], Age={3}], Phone={4}], Mail={5}]", Id, Name, LastName, Age, Phone, Mail);
        }
    }
}