using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativePortable
{
    public class SQLiteDB : IPersonDAO
    {
        SQLiteConnection db;

        public SQLiteDB()
        {
            db = new SQLiteConnection("sqliteDB.db");
            db.CreateTable<Person>();
        }

        public void Create(Person person)
        {
            db.BeginTransaction();
            db.Insert(person, typeof(Person));
            db.Commit();
        }

        public void Delete(Person person)
        {
            db.BeginTransaction();
            db.Delete<Person>(person);
            db.Commit();
        }

        public Person Read(int id)
        {
            Person p = db.Get<Person>(id);
            return p;
        }

        public IEnumerable<Person> ReadAll()
        {
            var p = db.Table<Person>();
            return p;
        }

        public void Update(Person person)
        {
            db.BeginTransaction();
            db.Update(person, typeof(Person));
            db.Commit();
        }

    }
}
