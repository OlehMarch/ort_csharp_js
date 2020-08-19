using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;


namespace PersonDB
{
    public sealed class PersonDAO_Cassandra : IPersonDAO
    {
        private List<Person> personList;
        private static Cluster cluster;
        private ISession session;
        private Row[] rows;
        private string hostIP;
        private string dbName;

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

        public PersonDAO_Cassandra()
        {
            personList = new List<Person>();
            cluster = null;
            session = null;
            hostIP = "127.0.0.1";
            dbName = "Persons";
        }


        #region CRUD
        public void Create(Person person)
        {
            CreateConnectionAndQuery(String.Format(
                "insert into person (id, first_name, last_name, age) values ({0}, '{1}', '{2}', {3})",
                person.Id, person.FirstName, person.LastName, person.Age
            ));

            DisposeConnection();
        }

        public IEnumerable<Person> Read()
        {
            CreateConnectionAndQuery("select * from person");

            personList = new List<Person>();
            for (int i = 0; i < rows.Length; ++i)
            {
                personList.Add(
                    new Person(
                        Convert.ToUInt32(rows[i]["id"]),
                        rows[i]["first_name"].ToString(),
                        rows[i]["last_name"].ToString(),
                        Convert.ToUInt32(rows[i]["age"])
                    )
                );
            }

            DisposeConnection();

            return personList;
        }

        public void Update(Person person)
        {
            CreateConnectionAndQuery(String.Format(
                String.Format("update person set first_name = '{0}', last_name = '{1}', age = {2} where id = {3}",
                    person.FirstName, person.LastName, person.Age, person.Id)
            ));

            DisposeConnection();
        }

        public void Delete(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("delete from person where id = {0}", person.Id)
            );

            DisposeConnection();
        }
        #endregion

        #region Additional functions
        private void CreateConnection()
        {
            if (cluster == null)
            {
                cluster = Cluster.Builder().AddContactPoint(hostIP).Build();
                session = cluster.Connect(dbName);
            }
        }

        private void CreateConnectionAndQuery(string iniQuery)
        {
            CreateConnection();
            rows = session.Execute(iniQuery).GetRows().ToArray<Row>();
        }

        private void DisposeConnection()
        {
            cluster = null;
            session = null;
        }
        #endregion

    }
}
