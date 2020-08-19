using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace PersonDB
{
    public class PersonDAO_Mongo : IPersonDAO
    {
        private List<Person> personList;
        private string dbName;
        MongoClient client;
        IMongoDatabase db;

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

        public PersonDAO_Mongo()
        {
            dbName = "dbperson";
            personList = new List<Person>();
        }

        private IMongoCollection<Person> GetCollection(string dbName)
        {
            if (client == null || db == null)
            {
                client = new MongoClient();
                db = client.GetDatabase(dbName);
            }
            return db.GetCollection<Person>("person");
        }
        public void Create(Person persona)
        {
            var coll = GetCollection(dbName);
            coll.InsertOneAsync(persona);
        }
        public IEnumerable<Person> Read()
        {
            var coll = GetCollection(dbName);
            foreach (var el in coll.Find(_ => true).ToList())
            {
                personList.Add(new Person(el.Id, el.LastName, el.FirstName, el.Age));
            }
            return personList;
        }
        public void Delete(Person persona)
        {
            var coll = GetCollection(dbName);
            coll.DeleteMany(Builders<Person>.Filter.Eq(c => c.Id, persona.Id));
        }

        public void Update(Person persona)
        {
            var coll = GetCollection(dbName);
            coll.ReplaceOne(f => f.Id == persona.Id, persona);
        }
    }
}
