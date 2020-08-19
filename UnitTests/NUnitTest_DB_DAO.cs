using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using PersonDB;
using System.IO;

namespace DBTest
{
    [TestFixture(typeof(PersonDAO_CSV))]
    //[TestFixture(typeof(PersonDAO_JSON))]
    //[TestFixture(typeof(PersonDAO_XML))]
    //[TestFixture(typeof(PersonDAO_YML))]
    public class NUnitTest_DB_DAO<DAO> where DAO : class, new()
    {
        IPersonDAO dao = (IPersonDAO)new DAO();
        string CurrentDirectory = @"D:\Projects\CSharpPrograms\ORT\UnitTests\bin\Debug\";
        string fileFormat;


        private void PersonAssert(List<Person> act, List<Person> exp)
        {
            bool res = true;
            if (act.Count != exp.Count)
            {
                res = false;
            }
            else
            {
                for (int i = 0; i < act.Count; ++i)
                {
                    if (act[i].Id != exp[i].Id 
                        || act[i].FirstName != exp[i].FirstName 
                        || act[i].LastName != exp[i].LastName 
                        || act[i].Age != exp[i].Age)
                    {
                        res = false;
                        break;
                    }
                }
            }
            Assert.AreEqual(true, res);
        }

        [TestFixtureSetUp]
        public void SetUp()
        {
            fileFormat = "." + dao.GetType().ToString().Replace("Task4_01.PersonDAO_", "").ToLower();
        }

        [TestCase("DBTestFiles\\noFile", TestName = "No File Create")]
        [TestCase("DBTestFiles\\noFile", TestName = "No File Read")]
        [TestCase("DBTestFiles\\noFile", TestName = "No File Update")]
        [TestCase("DBTestFiles\\noFile", TestName = "No File Delete")]
        public void TestFileDoesNotExist(string actual)
        {
            FileAssert.DoesNotExist(CurrentDirectory + actual + fileFormat);
        }

        #region Create
        [TestCase("DBTestFiles\\empty", "DBTestFiles\\expEmptyCreate", 1, "Avrora", "Gulchatay", 13, TestName = "File empty Create")]
        public void TestEmptyCreate(string actualPath, string expectedPath, int id, string fName, string lName, int age)
        {
            Person p = new Person(Convert.ToUInt32(id), fName, lName, Convert.ToUInt32(age));

            dao.ConnectionString = CurrentDirectory + actualPath + fileFormat;
            dao.Create(p);
            List<Person> actual = (List<Person>)dao.Read();
            using (StreamWriter fs = new StreamWriter(dao.ConnectionString))
            {
                fs.Write("");
            }

            dao.ConnectionString = CurrentDirectory + expectedPath + fileFormat;
            List<Person> expected = (List<Person>)dao.Read();

            PersonAssert(actual, expected);
        }

        [TestCase("DBTestFiles\\header", "DBTestFiles\\expEmptyCreate", 1, "Avrora", "Gulchatay", 13, TestName = "File n header Create")]
        [TestCase("DBTestFiles\\one", "DBTestFiles\\expOneCreate", 2, "Avrora", "Gulchatay", 13, TestName = "File one Create")]
        [TestCase("DBTestFiles\\two", "DBTestFiles\\expTwoCreate", 3, "Avrora", "Gulchatay", 13, TestName = "File two Create")]
        [TestCase("DBTestFiles\\many", "DBTestFiles\\expManyCreate", 7, "Avrora", "Gulchatay", 13, TestName = "File many Create")]
        public void TestCreate(string actualPath, string expectedPath, int id, string fName, string lName, int age)
        {
            Person p = new Person(Convert.ToUInt32(id), fName, lName, Convert.ToUInt32(age));

            dao.ConnectionString = CurrentDirectory + actualPath + fileFormat;
            dao.Create(p);
            List<Person> actual = (List<Person>)dao.Read();
            dao.Delete(p);

            dao.ConnectionString = CurrentDirectory + expectedPath + fileFormat;
            List<Person> expected = (List<Person>)dao.Read();

            PersonAssert(actual, expected);
        }
        #endregion

        #region Read
        [TestCase("DBTestFiles\\empty", TestName = "File empty Read")]
        [TestCase("DBTestFiles\\header", TestName = "File n header Read")]
        public void TestReadEmpty(string actual)
        {
            List<Person> persons = new List<Person>();

            dao.ConnectionString = CurrentDirectory + actual + fileFormat;

            PersonAssert(persons, (List<Person>)dao.Read());
        }

        [TestCase("DBTestFiles\\one", TestName = "File one Read")]
        public void TestReadOne(string actual)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person(1, "Aaron", "Paul", 23));

            dao.ConnectionString = CurrentDirectory + actual + fileFormat;

            PersonAssert(persons, (List<Person>)dao.Read());
        }

        [TestCase("DBTestFiles\\two", TestName = "File two Read")]
        public void TestReadTwo(string actual)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person(1, "Aaron", "Paul", 23));
            persons.Add(new Person(2, "Mark", "Wallberg", 32));

            dao.ConnectionString = CurrentDirectory + actual + fileFormat;

            PersonAssert(persons, (List<Person>)dao.Read());
        }

        [TestCase("DBTestFiles\\many", TestName = "File many Read")]
        public void TestReadMany(string actual)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person(1, "Aaron", "Paul", 23));
            persons.Add(new Person(2, "Mark", "Wallberg", 32));
            persons.Add(new Person(3, "Mark \"Rock, and, Roll\"", "Wallberg", 32));
            persons.Add(new Person(4, "Aaron", "Paul", 23));
            persons.Add(new Person(5, "Mark", "Wallberg", 32));
            persons.Add(new Person(6, "Mark \"Rock, and, Roll\"", "Wallberg", 32));

            dao.ConnectionString = CurrentDirectory + actual + fileFormat;

            PersonAssert(persons, (List<Person>)dao.Read());
        }
        #endregion

        #region Update
        [TestCase("DBTestFiles\\empty", "DBTestFiles\\expHeader", 1, "Avrora", "Gulchatay", 13, TestName = "File empty Update")]
        public void TestEmptyUpdate(string actualPath, string expectedPath, int id, string fName, string lName, int age)
        {
            Person p = new Person(Convert.ToUInt32(id), fName, lName, Convert.ToUInt32(age));

            dao.ConnectionString = CurrentDirectory + actualPath + fileFormat;
            dao.Update(p);
            List<Person> actual = (List<Person>)dao.Read();
            using (StreamWriter fs = new StreamWriter(dao.ConnectionString))
            {
                fs.Write("");
            }

            dao.ConnectionString = CurrentDirectory + expectedPath + fileFormat;
            List<Person> expected = (List<Person>)dao.Read();

            PersonAssert(actual, expected);
        }

        [TestCase("DBTestFiles\\header", "DBTestFiles\\expHeader", 1, "Avrora", "Gulchatay", 13, TestName = "File n header Update")]
        [TestCase("DBTestFiles\\one", "DBTestFiles\\expOneUpdate", 1, "Avrora", "Gulchatay", 13, TestName = "File one Update")]
        [TestCase("DBTestFiles\\two", "DBTestFiles\\expTwoUpdate", 2, "Avrora", "Gulchatay", 13, TestName = "File two Update")]
        [TestCase("DBTestFiles\\many", "DBTestFiles\\expManyUpdate", 6, "Avrora", "Gulchatay", 13, TestName = "File many Update")]
        public void TestUpdate(string actualPath, string expectedPath, int id, string fName, string lName, int age)
        {
            Person p = new Person(Convert.ToUInt32(id), fName, lName, Convert.ToUInt32(age));
            dao.ConnectionString = CurrentDirectory + actualPath + fileFormat;
            List<Person> ini = (List<Person>)dao.Read();
            Person prevP = null;
            for (int i = 0; i < ini.Count; ++i)
            {
                if (ini[i].Id == p.Id)
                {
                    prevP = ini[i];
                    break;
                }
            }

            dao.Update(p);
            List<Person> actual = (List<Person>)dao.Read();
            dao.Update(prevP);

            dao.ConnectionString = CurrentDirectory + expectedPath + fileFormat;
            List<Person> expected = (List<Person>)dao.Read();

            PersonAssert(actual, expected);
        }
        #endregion

        #region Delete
        [TestCase("DBTestFiles\\empty", "DBTestFiles\\expHeader", 1, "", "", 13, TestName = "File empty Delete")]
        public void TestEmptyDelete(string actualPath, string expectedPath, int id, string fName, string lName, int age)
        {
            Person p = new Person(Convert.ToUInt32(id), fName, lName, Convert.ToUInt32(age));

            dao.ConnectionString = CurrentDirectory + actualPath + fileFormat;
            dao.Delete(p);
            List<Person> actual = (List<Person>)dao.Read();
            using (StreamWriter fs = new StreamWriter(dao.ConnectionString))
            {
                fs.Write("");
            }

            dao.ConnectionString = CurrentDirectory + expectedPath + fileFormat;
            List<Person> expected = (List<Person>)dao.Read();

            PersonAssert(actual, expected);
        }

        [TestCase("DBTestFiles\\header", "DBTestFiles\\expHeader", 1, "", "", 13, TestName = "File n header Delete")]
        [TestCase("DBTestFiles\\one", "DBTestFiles\\expHeader", 1, "", "", 13, TestName = "File one Delete")]
        [TestCase("DBTestFiles\\two", "DBTestFiles\\expTwoDelete", 2, "", "", 13, TestName = "File two Delete")]
        [TestCase("DBTestFiles\\many", "DBTestFiles\\expManyDelete", 6, "", "", 13, TestName = "File many Delete")]
        public void TestDelete(string actualPath, string expectedPath, int id, string fName, string lName, int age)
        {
            Person p = new Person(Convert.ToUInt32(id), fName, lName, Convert.ToUInt32(age));
            dao.ConnectionString = CurrentDirectory + actualPath + fileFormat;
            List<Person> ini = (List<Person>)dao.Read();
            Person prevP = null;
            for (int i = 0; i < ini.Count; ++i)
            {
                if (ini[i].Id == p.Id)
                {
                    prevP = ini[i];
                    break;
                }
            }

            dao.Delete(p);
            List<Person> actual = (List<Person>)dao.Read();
            if (prevP != null)
            {
                dao.Create(prevP);
            }

            dao.ConnectionString = CurrentDirectory + expectedPath + fileFormat;
            List<Person> expected = (List<Person>)dao.Read();

            PersonAssert(actual, expected);
        }
        #endregion

    }
}
