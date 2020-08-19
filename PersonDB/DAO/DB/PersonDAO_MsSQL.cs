using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonDB
{
    public sealed class PersonDAO_MsSQL : IPersonDAO
    {
        private List<Person> personList;
        private SqlConnection connection;

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

        public PersonDAO_MsSQL()
        {
            personList = new List<Person>();
            connection = null;
        }

        private void createConnection()
        {
            if (connection == null)
            {
                SqlConnectionStringBuilder connectStrBuilder = new SqlConnectionStringBuilder();
                connectStrBuilder.DataSource = "DESKTOP-D9F70GC";
                connectStrBuilder.InitialCatalog = "master";
                connectStrBuilder.UserID = "DESKTOP-D9F70GC/Dmitry";
                connectStrBuilder.IntegratedSecurity = true;
                connection = new SqlConnection(connectStrBuilder.ConnectionString);
            }
        }

        public void Create(Person persona)
        {
            createConnection();
            string insertScript = String.Format("INSERT INTO Person(FirstName, LastName, Age) VALUES('{0}', '{1}', {2})", persona.FirstName, persona.LastName, persona.Age);
            SqlCommand insertQuery = null;
            try
            {
                connection.Open();
                insertQuery = new SqlCommand(insertScript, connection);
            }
            catch (SqlException ex)
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
            SqlCommand selectQuery = null;
            SqlDataReader dataReader = null;
            string selectScript = "SELECT Id, FirstName, LastName, Age FROM person";
            try
            {
                connection.Open();
                selectQuery = new SqlCommand(selectScript, connection);
                dataReader = selectQuery.ExecuteReader();
            }
            catch (SqlException ex)
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
            SqlCommand deleteQuery = null;
            try
            {
                connection.Open();
                deleteQuery = new SqlCommand(insertScript, connection);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            deleteQuery.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Person persona)
        {
            createConnection();
            string insertScript = String.Format("UPDATE Person SET FirstName = '{0}', LastName = '{1}', Age = {2} WHERE Id = {3}",
                persona.FirstName, persona.LastName, persona.Age, persona.Id);
            SqlCommand updateQuery = null;
            try
            {
                connection.Open();
                updateQuery = new SqlCommand(insertScript, connection);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            updateQuery.ExecuteNonQuery();
            connection.Close();
        }
    }
}
