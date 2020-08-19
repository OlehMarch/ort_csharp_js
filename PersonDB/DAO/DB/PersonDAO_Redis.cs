using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PersonDB
{
    public sealed class PersonDAO_Redis : IPersonDAO, IDisposable
    {
        private List<Person> personList;
        private static ConnectionMultiplexer redis;
        private IDatabase connection;
        private IServer server;

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

        public PersonDAO_Redis()
        {
            personList = new List<Person>();
            connection = null;
        }

        private void CreateConnection()
        {
            if (connection == null)
            {
                redis = ConnectionMultiplexer.Connect("localhost");
                connection = redis.GetDatabase();
                server = redis.GetServer("localhost:6379");
            }
        }

        #region CRUD

        public void Create(Person person)
        {
            CreateConnection();

            connection.HashSet(person.Id.ToString(), new HashEntry[] {
                new HashEntry("Name", person.FirstName),
                new HashEntry("Last Name", person.LastName),
                new HashEntry("Age", person.Age)
            });

            Dispose();
        }

        public IEnumerable<Person> Read()
        {
            CreateConnection();

            foreach (var key in server.Keys(pattern: "*"))
            {
                string tmp = key.ToString();
                personList.Add(
                    new Person(
                        Convert.ToUInt32(key.ToString()),
                        connection.HashGet(key.ToString(), "Name"),
                        connection.HashGet(key.ToString(), "Last Name"),
                        Convert.ToUInt32(connection.HashGet(key.ToString(), "Age"))
                    )    
                );
            }

            return personList;
        }

        public void Update(Person person)
        {
            CreateConnection();

            connection.HashSet(person.Id.ToString(), new HashEntry[] {
                new HashEntry("Name", person.FirstName),
                new HashEntry("Last Name", person.LastName),
                new HashEntry("Age", person.Age)
            });

            Dispose();
        }

        public void Delete(Person person)
        {
            CreateConnection();

            connection.KeyDelete(person.Id.ToString());

            Dispose();
        }
        #endregion

        #region CleanUp

        public void Dispose()
        {
            redis = null;
            connection = null;
            server = null;
        }

        #endregion

    }
}
