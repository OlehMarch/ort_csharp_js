using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

namespace PersonDB
{
    public sealed class PersonDAO_MySQL : IPersonDAO
    {
        private List<Person> personList;
        private MySqlConnection connection;
        private string connectionParameters = "server = localhost; user = root; database = ort_1;";

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

        public PersonDAO_MySQL()
        {
            personList = new List<Person>();
            connection = null;
        }

        private void createConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionParameters);
            }
        }

        public void Create(Person persona)
        {
            createConnection();
            string insertScript = String.Format("INSERT INTO Person(FirstName, LastName, Age) VALUES('{0}', '{1}', {2})",
                persona.FirstName, persona.LastName, persona.Age);
            MySqlCommand insertQuery = null;
            try
            {
                connection.Open();
                insertQuery = new MySqlCommand(insertScript, connection);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            insertQuery.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Person> Read()
        {
            createConnection();
            MySqlCommand selectQuery = null;
            MySqlDataReader dataReader = null;
            string selectScript = "SELECT Id, FirstName, LastName, Age FROM person";
            try
            {
                connection.Open();
                selectQuery = new MySqlCommand(selectScript, connection);
                dataReader = selectQuery.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            while (dataReader.Read())
            {
                personList.Add(
                new Person(
                    (uint)dataReader["Id"],
                    dataReader["FirstName"].ToString(),
                    dataReader["LastName"].ToString(),
                    (uint)dataReader["Age"]
                ));
            }

            dataReader.Close();
            dataReader.Dispose();
            selectQuery.Dispose();
            connection.Close();

            return personList;
        }

        public void Delete(Person persona)
        {
            createConnection();
            string insertScript = String.Format("DELETE FROM Person WHERE Id = {0}", persona.Id);
            MySqlCommand iniQuery = null;
            try
            {
                connection.Open();
                iniQuery = new MySqlCommand(insertScript, connection);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            iniQuery.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Person persona)
        {
            createConnection();
            string insertScript = String.Format("UPDATE Person SET FirstName = '{0}', LastName = '{1}', Age = {2} WHERE Id = {3}",
                persona.FirstName, persona.LastName, persona.Age, persona.Id);
            MySqlCommand iniQuery = null;
            try
            {
                connection.Open();
                iniQuery = new MySqlCommand(insertScript, connection);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            iniQuery.ExecuteNonQuery();
            connection.Close();
        }
    }
}
