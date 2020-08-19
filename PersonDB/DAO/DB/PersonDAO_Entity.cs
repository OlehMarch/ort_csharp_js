using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using MySql.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace PersonDB
{
    public sealed class PersonDAO_Entity : IPersonDAO
    {
        private List<Person> personList;
        DbContext context;
        DbCommand query;
        DbConnection connection;
        public string ConnectionString { get; set; }
        

        public PersonDAO_Entity()
        {
            personList = new List<Person>();
            ConnectionString = "server=localhost;user id=root;database=test";

            

        }

        #region CRUD
        public void Create(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("INSERT INTO Person(FirstName, LastName, Age) VALUES('{0}', '{1}', {2})",
                person.Id, person.FirstName, person.LastName, person.Age)
            );

            query.ExecuteNonQuery();

            DisposeConnection();
        }

        public IEnumerable<Person> Read()
        {
            CreateConnectionAndQuery("SELECT Id, FirstName, LastName, Age FROM person");
            DbDataReader dataReader = query.ExecuteReader();

            personList = new List<Person>();

            while (dataReader.Read())
            {
                personList.Add(
                    new Person(
                        (uint)dataReader["Id"],
                        dataReader["FirstName"].ToString(),
                        dataReader["LastName"].ToString(),
                        (uint)dataReader["Age"]
                    )
                );
            }

            dataReader.Close();
            dataReader.Dispose();
            DisposeConnection();

            return personList;
        }

        public void Update(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("UPDATE Person SET FirstName = '{0}', LastName = '{1}', Age = {2} WHERE Id = {3}",
                person.Id, person.FirstName, person.LastName, person.Age)
            );

            query.ExecuteNonQuery();

            DisposeConnection();
        }

        public void Delete(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("DELETE FROM Person WHERE Id = {0}", person.Id)
            );

            query.ExecuteNonQuery();

            DisposeConnection();
        }
        #endregion

        #region Additional functions
        private void CreateConnection()
        {
            if (connection == null)
            {
                connection = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection();
                connection.ConnectionString = ConnectionString;
                context = new DbContext(connection, true);
                connection.Open();
            }
        }

        private void CreateConnectionAndQuery(string queryString)
        {
            CreateConnection();
            query = new MySql.Data.MySqlClient.MySqlCommand(queryString, (MySql.Data.MySqlClient.MySqlConnection)connection);
        }

        private void DisposeConnection()
        {
            connection.Close();
            connection = null;
            context.Dispose();
        }
        #endregion

    }
}
