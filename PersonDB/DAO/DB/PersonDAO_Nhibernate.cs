using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public sealed class PersonDAO_Nhibernate : IPersonDAO
    {
        private List<Person> personList;
        ISession session;
        ISQLQuery query;
        public string ConnectionString { get; set; }


        public PersonDAO_Nhibernate()
        {
            personList = new List<Person>();
            ConnectionString = "server = localhost; user = root; database = streetdb;";
        }

        #region CRUD
        public void Create(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("INSERT INTO Person(FirstName, LastName, Age) VALUES('{0}', '{1}', {2})",
                person.Id, person.FirstName, person.LastName, person.Age)
            );

            query.ExecuteUpdate();

            DisposeConnection();
        }

        public IEnumerable<Person> Read()
        {
            CreateConnectionAndQuery("SELECT Id, FirstName, LastName, Age FROM person");
            IList list = query.List();

            personList = new List<Person>();

            //while (dataReader.Read())
            //{
            //    personList.Add(
            //        new Person(
            //            (uint)dataReader["Id"],
            //            dataReader["FirstName"].ToString(),
            //            dataReader["LastName"].ToString(),
            //            (uint)dataReader["Age"]
            //        )
            //    );
            //}

            //dataReader.Close();
            //dataReader.Dispose();
            DisposeConnection();

            return personList;
        }

        public void Update(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("UPDATE Person SET FirstName = '{0}', LastName = '{1}', Age = {2} WHERE Id = {3}",
                person.Id, person.FirstName, person.LastName, person.Age)
            );

            query.ExecuteUpdate();

            DisposeConnection();
        }

        public void Delete(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("DELETE FROM Person WHERE Id = {0}", person.Id)
            );

            query.ExecuteUpdate();

            DisposeConnection();
        }
        #endregion

        #region Additional functions
        private void CreateConnection()
        {
            if (session.Connection == null)
            {
                session.Connection.ConnectionString = ConnectionString;
                session.Connection.Open();
            }
        }

        private void CreateConnectionAndQuery(string queryString)
        {
            CreateConnection();
            query = session.CreateSQLQuery(queryString);
        }

        private void DisposeConnection()
        {
            session.Connection.Close();
        }
        #endregion

    }
}
