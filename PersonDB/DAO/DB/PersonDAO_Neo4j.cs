using System;
using System.Collections.Generic;
using System.Linq;
using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;


namespace PersonDB
{
    public sealed class PersonDAO_Neo4j : IPersonDAO
    {
        private List<Person> personList;
        private GraphClient connection;
        private string uriString;
        private string username;
        private string password;

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

        public PersonDAO_Neo4j()
        {
            personList = new List<Person>();
            connection = null;

            uriString = "http://localhost:7474/db/data";
            username = "neo4j";
            password = "753951";
        }


        #region CRUD
        public void Create(Person person)
        {
            CreateConnection();

            connection.Cypher
                .Create(
                    "(n:Person { "
                    + String.Format("id: {0}, name: '{1}', last_name: '{2}', age: {3}", 
                        person.Id, person.FirstName, person.LastName, person.Age)
                    + " })"
                )
                .ExecuteWithoutResults();

            DisposeConnection();
        }

        public IEnumerable<Person> Read()
        {
            CreateConnection();

            personList = new List<Person>();
            PersonWrapper[] results = connection.Cypher
                .Match("(n:Person)").Return(() => Return.As<PersonWrapper>("n"))
                .Results.ToArray();

            for (int i = 0; i < results.Length; ++i)
            {
                personList.Add(
                    new Person(
                        results[i].Id,
                        results[i].FirstName,
                        results[i].LastName,
                        results[i].Age
                    )
                );
            }

            return personList;
        }

        public void Update(Person person)
        {
            CreateConnection();

            connection.Cypher
                .Match("(n:Person)")
                .Where("n.id = " + person.Id)
                .Set(
                    "n += { "
                    + String.Format("name: '{0}', last_name: '{1}', age: {2}",
                        person.FirstName, person.LastName, person.Age)
                    + " }"
                )
                .ExecuteWithoutResults();

            DisposeConnection();
        }

        public void Delete(Person person)
        {
            CreateConnection();

            connection.Cypher
                .Match("(n:Person)")
                .Where("n.id = " + person.Id)
                .DetachDelete("n")
                .ExecuteWithoutResults();

            DisposeConnection();
        }
        #endregion

        #region Additional functions
        private void CreateConnection()
        {
            if (connection == null)
            {
                connection = new GraphClient(new Uri(uriString), username, password);
                connection.Connect();
            }
        }

        private void DisposeConnection()
        {
            connection = null;
        }
        #endregion

        private class PersonWrapper
        {
            [JsonProperty("id")]
            public uint Id { get; set; }

            [JsonProperty("age")]
            public uint Age { get; set; }

            [JsonProperty("name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }
        }

    }
}
