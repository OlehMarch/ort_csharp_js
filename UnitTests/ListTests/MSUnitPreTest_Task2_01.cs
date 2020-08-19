using System;
using Task2_01;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTests
{
    [TestClass]
    public class MSUnitPreTest_Task2_01
    {
        #region Data Provider
        private const string dataDriver = "System.Data.OleDb";
        private const string pathToExcelFile = @"D:\Projects\CSharpPrograms\ORT\UnitTests\TestSets.xlsx";
        private const string connectionStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            + pathToExcelFile
            + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        
        private int[] ConvertToArray(string iniString)
        {
            if (iniString == "Empty")
            {
                return new int[0];
            }

            string[] iniArray = iniString.Split(' ');
            int[] resArray = new int[iniArray.Length];
            for (int i = 0; i < iniArray.Length; ++i)
            {
                resArray[i] = Convert.ToInt32(iniArray[i]);
            }

            return resArray;
        }

        private IList ConvertToListType(string iniString)
        {
            IList list = null;
            switch (iniString)
            {
                case "AList0":
                    list = new AList0();
                    break;
                case "AList1":
                    list = new AList1();
                    break;
                case "AList2":
                    list = new AList2();
                    break;
                case "AListR":
                    list = new AListR();
                    break;
                case "LList1":
                    list = new LList1();
                    break;
                default:
                    break;
            }
            return list;
        }
        #endregion

        #region Init
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(NullReferenceException))]
        public void Init_ArrayNull_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(null);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Init$", DataAccessMethod.Sequential)]
        public void Init()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            int[] exp = ConvertToArray(TestContext.DataRow["Expected Array"].ToString());
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            int[] act = list.ToArray();

            CollectionAssert.AreEqual(exp, act);
        }
        #endregion
        
        #region ToString
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Init$", DataAccessMethod.Sequential)]
        public void ToString_Test()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            string exp = TestContext.DataRow["Expected Array"].ToString();
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            if (exp == "Empty")
            {
                exp = "";
            }
            list.Init(ini);
            string act = list.ToString();

            Assert.AreEqual(exp, act);
        }
        #endregion
        
        #region ToArray
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Init$", DataAccessMethod.Sequential)]
        public void ToArray()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            int[] exp = ConvertToArray(TestContext.DataRow["Expected Array"].ToString());
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            int[] act = list.ToArray();

            CollectionAssert.AreEqual(exp, act);
        }
        #endregion
        
        #region Size
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Size$", DataAccessMethod.Sequential)]
        public void Size()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            int exp = Convert.ToInt32(TestContext.DataRow["Expected Size"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            int act = list.Size();

            Assert.AreEqual(exp, act);
        }
        #endregion
        
        #region Clear
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Size$", DataAccessMethod.Sequential)]
        public void Clear_ArrayEmpty()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            list.Clear();
            int act = list.Size();

            Assert.AreEqual(0, act);
        }
        #endregion
        
    }
}
