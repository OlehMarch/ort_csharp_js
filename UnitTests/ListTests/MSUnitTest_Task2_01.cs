using System;
using Task2_01;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTests
{
    [TestClass]
    public class MSUnitTest_Task2_01
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

        #region AddStart
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Add$", DataAccessMethod.Sequential)]
        public void AddStart()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            string exp = TestContext.DataRow["Expected string of AddStart"].ToString();
            int value = Convert.ToInt32(TestContext.DataRow["Value to Add"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            list.AddStart(value);
            string act = list.ToString();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region AddEnd
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Add$", DataAccessMethod.Sequential)]
        public void AddEnd()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            string exp = TestContext.DataRow["Expected string of AddEnd"].ToString();
            int value = Convert.ToInt32(TestContext.DataRow["Value to Add"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            list.AddEnd(value);
            string act = list.ToString();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region AddPos
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddPos_OneValue_PosBeneath_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { 0 });
            list.AddPos(-1, 1);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddPos_OneValue_PosAbove_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { 0 });
            list.AddPos(1, 1);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Add$", DataAccessMethod.Sequential)]
        public void AddPos()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            string exp = TestContext.DataRow["Expected string of AddPos"].ToString();
            int value = Convert.ToInt32(TestContext.DataRow["Value to Add"]);
            int pos = Convert.ToInt32(TestContext.DataRow["Add Position"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            list.AddPos(pos, value);
            string act = list.ToString();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region DelStart
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void DelStart_ArrayEmpty_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { });
            list.DelStart();
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Delete$", DataAccessMethod.Sequential)]
        public void DelStart()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            string exp = TestContext.DataRow["Expected string of DelStart"].ToString();
            int delVal = Convert.ToInt32(TestContext.DataRow["Deleted value Start"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            if (exp == "Empty")
            {
                exp = "";
            }
            list.Init(ini);
            int res = list.DelStart();
            string act = list.ToString();

            Assert.AreEqual(delVal, res);
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region DelEnd
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void DelEnd_ArrayEmpty_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { });
            list.DelEnd();
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Delete$", DataAccessMethod.Sequential)]
        public void DelEnd()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            string exp = TestContext.DataRow["Expected string of DelEnd"].ToString();
            int delVal = Convert.ToInt32(TestContext.DataRow["Deleted value End"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            if (exp == "Empty")
            {
                exp = "";
            }
            list.Init(ini);
            int res = list.DelEnd();
            string act = list.ToString();

            Assert.AreEqual(delVal, res);
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region DelPos
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void DelPos_ArrayEmpty_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { });
            list.DelPos(0);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void DelPos_OneValue_PosBeneath_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { 0 });
            list.DelPos(-1);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void DelPos_OneValue_PosAbove_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { 0 });
            list.DelPos(1);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Delete$", DataAccessMethod.Sequential)]
        public void DelPos()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            string exp = TestContext.DataRow["Expected string of DelPos"].ToString();
            int pos = Convert.ToInt32(TestContext.DataRow["Del Position"]);
            int delVal = Convert.ToInt32(TestContext.DataRow["Deleted value Pos"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            if (exp == "Empty")
            {
                exp = "";
            }
            list.Init(ini);
            int res = list.DelPos(pos);
            string act = list.ToString();

            Assert.AreEqual(delVal, res);
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Set
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void Set_ArrayEmpty_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { });
            list.Set(0, 10);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void Set_OneValue_PosBeneath_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { 0 });
            list.Set(-1, 10);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void Set_OneValue_PosAbove_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { 0 });
            list.Set(1, 10);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Get'n'Set$", DataAccessMethod.Sequential)]
        public void Set()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            string exp = TestContext.DataRow["Expected string of Set"].ToString();
            int value = Convert.ToInt32(TestContext.DataRow["Value to set"]);
            int pos = Convert.ToInt32(TestContext.DataRow["Position to set"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            list.Set(pos, value);

            string act = list.ToString();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Get
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_ArrayEmpty_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { });
            list.Get(0);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_OneValue_PosBeneath_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { 0 });
            list.Get(-1);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_OneValue_PosAbove_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { 0 });
            list.Get(1);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Get'n'Set$", DataAccessMethod.Sequential)]
        public void Get()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            int exp = Convert.ToInt32(TestContext.DataRow["Expected value"]);
            int pos = Convert.ToInt32(TestContext.DataRow["Position to get"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            int act = list.Get(pos);

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Reverse
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Sort'n'Reverse$", DataAccessMethod.Sequential)]
        public void Reverse()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            int[] exp = ConvertToArray(TestContext.DataRow["Expected array of Reverse"].ToString());
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            list.Reverse();
            int[] act = list.ToArray();

            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region HalfReverse
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Sort'n'Reverse$", DataAccessMethod.Sequential)]
        public void HalfReverse()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            int[] exp = ConvertToArray(TestContext.DataRow["Expected array of HalfReverse"].ToString());
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            list.HalfReverse();
            int[] act = list.ToArray();

            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Sort
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Sort'n'Reverse$", DataAccessMethod.Sequential)]
        public void Sort()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Array"].ToString());
            int[] exp = ConvertToArray(TestContext.DataRow["Expected array of Sort"].ToString());
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            list.Sort();
            int[] act = list.ToArray();

            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region IndMin
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndMin_ArrEmpty_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { });
            list.IndMin();
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Min'n'Max$", DataAccessMethod.Sequential)]
        public void IndMin()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Min Array"].ToString());
            int exp = Convert.ToInt32(TestContext.DataRow["Expected Min Index"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            int act = list.IndMin();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region IndMax
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndMax_ArrEmpty_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { });
            list.IndMax();
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Min'n'Max$", DataAccessMethod.Sequential)]
        public void IndMax()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Max Array"].ToString());
            int exp = Convert.ToInt32(TestContext.DataRow["Expected Max Index"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            int act = list.IndMax();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Min
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void Min_ArrEmpty_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { });
            list.Min();
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Min'n'Max$", DataAccessMethod.Sequential)]
        public void Min()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Min Array"].ToString());
            int exp = Convert.ToInt32(TestContext.DataRow["Expected Min"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            int act = list.Min();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Max
        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Exception$", DataAccessMethod.Sequential), ExpectedException(typeof(IndexOutOfRangeException))]
        public void Max_ArrEmpty_Exc()
        {
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());
            list.Init(new int[] { });
            list.Max();
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Min'n'Max$", DataAccessMethod.Sequential)]
        public void Max()
        {
            int[] ini = ConvertToArray(TestContext.DataRow["Initial Max Array"].ToString());
            int exp = Convert.ToInt32(TestContext.DataRow["Expected Max"]);
            IList list = ConvertToListType(TestContext.DataRow["List Type"].ToString());

            list.Init(ini);
            int act = list.Max();

            Assert.AreEqual(exp, act);
        }
        #endregion

    }
}

// check the equallity of init tests by size, just as one of many variations
// exp not expected
// act not actual
// collectionAssert for checking arrays

// in Del and some others we need to write 3 assert (ret value, size and whole array)
// if using in C# CollectionAssert don't need to write 3 assert, only 2
// need to use same set of tests to test all of ALists
// ToArray must return actual set of elements