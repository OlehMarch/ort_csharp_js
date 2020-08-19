using System;
using System.Collections.Generic;
using java.sql;

namespace PersonDB
{
    public sealed class PersonDAO_H2 : IPersonDAO
    {
        private List<Person> personList;
        private Connection connection;
        private PreparedStatement query;
        private string connectionURL = "jdbc:h2:~/test";
        private string connectionUser = "sa";

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

        public PersonDAO_H2()
        {
            personList = new List<Person>();
            connection = null;
            query = null;
        }

        public void Create(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("INSERT INTO Person(FirstName, LastName, Age) VALUES('{0}', '{1}', {2})",
                    person.FirstName, person.LastName, person.Age)
            );

            query.execute();

            DisposeConnection();
        }

        public IEnumerable<Person> Read()
        {
            CreateConnectionAndQuery("SELECT Id, FirstName, LastName, Age FROM person");
            ResultSet dataReader  = query.executeQuery();

            personList.Clear();

            while (dataReader.next())
            {
                personList.Add(
                    new Person(
                        (uint)dataReader.getInt(0),
                        dataReader.getString(1),
                        dataReader.getString(2),
                        (uint)dataReader.getInt(3)
                    )
                );
            }

            dataReader.close();
            dataReader.Dispose();
            DisposeConnection();

            return personList;
        }

        public void Update(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("UPDATE Person SET FirstName = '{0}', LastName = '{1}', Age = {2} WHERE Id = {3}",
                    person.FirstName, person.LastName, person.Age, person.Id)
            );

            query.execute();

            DisposeConnection();
        }

        public void Delete(Person person)
        {
            CreateConnectionAndQuery(
                String.Format("DELETE FROM Person WHERE Id = {0}", person.Id)
            );

            query.execute();

            DisposeConnection();
        }

        private void CreateConnection()
        {
            if (connection == null)
            {
                org.h2.Driver.load();
                connection = DriverManager.getConnection(connectionURL, connectionUser, "");
            }
        }

        private void CreateConnectionAndQuery(string iniQuery)
        {
            CreateConnection();
            query = connection.prepareStatement(iniQuery);
        }

        private void DisposeConnection()
        {
            query.Dispose();
            connection.close();
        }

    }
}
