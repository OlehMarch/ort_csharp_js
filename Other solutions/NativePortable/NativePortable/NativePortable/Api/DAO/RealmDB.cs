using Realms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NativePortable
{
    public class RealmDB : IPersonDAO
    {
        private Realm realmDb;

        public RealmDB()
        {
            realmDb = Realm.GetInstance();
        }

        public void Create(Person person)
        {
            realmDb.Write(() =>
            {
                realmDb.Add(person);
            });
        }

        public IEnumerable<Person> ReadAll()
        {
            return realmDb.All<Person>();
        }

        public Person Read(int id)
        {
            return realmDb.All<Person>().Where<Person>(person => person.Id == id).First();
        }

        public void Update(Person person)
        {
            var p = realmDb.All<Person>().Where<Person>(pers => pers.Id == person.Id).First();
            realmDb.Write(() =>
            {
                p.Id = person.Id;
                p.Name = person.Name;
                p.LastName = person.LastName;
                p.Age = person.Age;
                p.Phone = person.Phone;
                p.Mail = person.Mail;
            });
        }

        public void Delete(Person person)
        {
            var p = realmDb.All<Person>().Where<Person>(per => per.Id == person.Id).First();
            realmDb.Write(() =>
            {
                realmDb.Remove(p);
            });
        }

    }
}

