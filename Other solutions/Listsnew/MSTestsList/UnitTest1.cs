//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Linq;
//using List;
//namespace MSTestsList
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        //AList0 al = new AList0();
//       // AList1 al = new AList1();
//       // AList2 al = new AList2();
//        LList1 al = new LList1();

//        [TestInitialize()]
//        public void clear_al()
//        {
//            al.Clear();
//        }
//        [TestMethod]
//        public void TestInit_many_ToArray()
//        {

//            int[] ar = new int[] { 2, 5, 8, 1, 8, 2 };
//            al.Init(ar);
//            CollectionAssert.AreEqual(ar, al.ToArray());
//        }
//        [TestMethod]
//        public void TestInit_one_ToArray()
//        {

//            int[] ar = new int[] { 2 };
//            al.Init(ar);
//            CollectionAssert.AreEqual(ar, al.ToArray());
//        }
//        [TestMethod]
//        public void TestInit_two_ToArray()
//        {

//            int[] ar = new int[] { 8, 2 };
//            al.Init(ar);
//            CollectionAssert.AreEqual(ar, al.ToArray());
//        }
//        [TestMethod]
//        public void TestInit_null_ToArray()
//        {
//            int[] ar = null;
//            al.Init(ar);
//            int[] exp = { };
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestInit_0_ToArray()
//        {

//            int[] ar = new int[] { };
//            al.Init(ar);
//            CollectionAssert.AreEqual(ar, al.ToArray());
//        }
//        [TestMethod]
//        public void TestSize_many()
//        {

//            int[] ar = new int[] { 9, 10, 9, 2, 1, 5, 2 };
//            al.Init(ar);
//            Assert.AreEqual(7, al.Size());
//        }
//        [TestMethod]
//        public void TestSize_1()
//        {

//            int[] ar = new int[] { 9 };
//            al.Init(ar);
//            Assert.AreEqual(1, al.Size());
//        }
//        [TestMethod]
//        public void TestSize_2()
//        {

//            int[] ar = new int[] { 9, 10 };
//            al.Init(ar);
//            Assert.AreEqual(2, al.Size());
//        }
//        [TestMethod]
//        public void TestSize_0()
//        {

//            int[] ar = new int[] { };
//            al.Init(ar);
//            Assert.AreEqual(0, al.Size());
//        }
//        [TestMethod]
//        public void TestClear_many()
//        {

//            int[] ar = new int[] { 1, 6, 4, 8, 9, 3, 7 };
//            al.Init(ar);
//            al.Clear();
//            Assert.AreEqual(0, al.Size());

//        }
//        [TestMethod]
//        public void TestClear_1()
//        {

//            int[] ar = new int[] { 1 };
//            al.Init(ar);
//            al.Clear();
//            Assert.AreEqual(0, al.Size());

//        }
//        [TestMethod]
//        public void TestClear_2()
//        {

//            int[] ar = new int[] { 1, 6 };
//            al.Init(ar);
//            al.Clear();
//            Assert.AreEqual(0, al.Size());

//        }
//        [TestMethod]
//        public void TestClear_0()
//        {

//            int[] ar = new int[] { };
//            al.Init(ar);
//            al.Clear();
//            Assert.AreEqual(0, al.Size());

//        }
//        [TestMethod]
//        public void TestAddStart_many()
//        {

//            al.AddStart(2);
//            al.AddStart(3);
//            al.AddStart(9);
//            al.AddStart(4);
//            al.AddStart(1);
//            int[] exp = new int[] { 1, 4, 9, 3, 2 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddStart_1()
//        {

//            al.AddStart(2);
//            int[] exp = new int[] { 2 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddStart_2()
//        {

//            al.AddStart(2);
//            al.AddStart(3);
//            int[] exp = new int[] { 3, 2 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddStart_3()
//        {

//            int[] ar = new int[] { 3, 2, 8, 10 };
//            al.Init(ar);
//            al.AddStart(2);
//            al.AddStart(3);
//            int[] exp = new int[] { 3, 2, 3, 2, 8, 10 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestToString_many()
//        {

//            al.AddStart(2);
//            al.AddStart(3);
//            al.AddStart(7);
//            al.AddStart(3);
//            al.AddStart(5);
//            string exp = "5 3 7 3 2";
//            Assert.AreEqual(exp, al.ToString());
//        }
//        [TestMethod]
//        public void TestToString_1()
//        {

//            al.AddStart(2);
//            string exp = "2";
//            Assert.AreEqual(exp, al.ToString());
//        }
//        [TestMethod]
//        public void TestToString_2()
//        {

//            al.AddStart(3);
//            al.AddStart(5);
//            string exp = "5 3";
//            Assert.AreEqual(exp, al.ToString());
//        }
//        [TestMethod]
//        public void TestAddPos_2()
//        {

//            int[] ar = new int[] { 3, 2, 8, 10 };
//            al.Init(ar);
//            al.AddPos(2, 5);
//            al.AddPos(3, 7);
//            int[] exp = new int[] { 3, 2, 5, 7, 8, 10 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddPos_many()
//        {
//            al.AddPos(0, 5);
//            al.AddPos(1, 7);
//            al.AddPos(2, 7);
//            int[] exp = new int[] { 5, 7, 7 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddPos_Startmore()
//        {
//            al.AddStart(5);
//            al.AddStart(5);
//            al.AddStart(5);
//            al.AddStart(5);
//            al.AddPos(3, 2);
//            al.AddPos(3, 2);
//            al.AddPos(3, 2);
//            int[] exp = new int[] { 5, 5, 5, 2, 2, 2, 5 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddPos_endMore()
//        {
//            al.AddEnd(5);
//            al.AddEnd(5);
//            al.AddEnd(5);
//            al.AddEnd(5);
//            al.AddPos(3, 2);
//            al.AddPos(3, 2);
//            al.AddPos(3, 2);
//            int[] exp = new int[] { 5, 5, 5, 2, 2, 2, 5 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddEnd_1()
//        {

//            al.AddEnd(3);
//            al.AddEnd(7);
//            al.AddEnd(21);
//            int[] exp = new int[] { 3, 7, 21 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddEnd_2()
//        {

//            al.AddEnd(3);
//            int[] exp = new int[] { 3 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddEnd_3()
//        {

//            al.AddEnd(3);
//            al.AddEnd(7);
//            int[] exp = new int[] { 3, 7 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestAddEnd_4()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2 };
//            al.Init(ar);
//            al.AddEnd(3);
//            al.AddEnd(7);
//            al.AddEnd(21);
//            int[] exp = new int[] { 3, 7, 7, 2, 3, 7, 21 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestDelSAtart_many()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelStart();
//            al.DelStart();
//            al.DelStart();
//            al.DelStart();
//            int[] exp = new int[] { 8, 2 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestDelSAtart_1()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelStart();
//            int[] exp = new int[] { 7, 7, 2, 8, 2 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestDelSAtart_2()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelStart();
//            al.DelStart();
//            int[] exp = new int[] { 7, 2, 8, 2 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestDelend_()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelEnd();
//            al.DelEnd();
//            al.DelEnd();
//            al.DelEnd();
//            int[] exp = new int[] { 3, 7 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestDelend_1()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelEnd();
//            int[] exp = new int[] { 3, 7, 7, 2, 8 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestDelend_2()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelEnd();
//            al.DelEnd();
//            int[] exp = new int[] { 3, 7, 7, 2 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }

//        [TestMethod]
//        public void TestDelPos_1()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelPos(5);
//            al.DelPos(2);
//            int[] exp = new int[] { 3, 7, 2, 8 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestDelPos_2()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelPos(5);
//            al.DelPos(2);
//            al.DelPos(0);
//            int[] exp = new int[] { 7, 2, 8 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestDelPos_startmore()
//        {
//            al.AddStart(5);
//            al.AddStart(3);
//            al.AddStart(1);
//            al.AddStart(7);
//            al.AddStart(9);

//            al.DelPos(4);
//            al.DelPos(0);
//            int[] exp = new int[] { 7, 1, 3 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestDelPos_EndMore()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelPos(5);
//            al.DelPos(2);
//            al.DelPos(0);
//            int[] exp = new int[] { 7, 2, 8 };

//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        [ExpectedException(typeof(IndexOutOfRangeException))]
//        public void TestDelPos_00()
//        {
//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.DelPos(7);
//        }
//        [TestMethod]
//        public void TestSet_0()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.Set(2, 8);
//            int[] exp = new int[] { 3, 7, 8, 2, 8, 2 };
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        [ExpectedException(typeof(IndexOutOfRangeException))]
//        public void TestSet_1()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            al.Set(9, 8);


//        }
//        [TestMethod]
//        public void TestGet_1()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            int exp = 7;
//            Assert.AreEqual(exp, al.Get(2));
//        }
//        [TestMethod]
//        public void TestGet_3()
//        {
//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            int exp = 3;
//            Assert.AreEqual(exp, al.Get(0));
//        }
//        [TestMethod]
//        public void Testrevers_many()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            int[] exp = new int[] { 2, 8, 2, 7, 7, 3 };
//            al.Reverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void Testrevers_1()
//        {

//            int[] ar = new int[] { 3 };
//            al.Init(ar);
//            int[] exp = new int[] { 3 };
//            al.Reverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void Testrevers_2()
//        {

//            int[] ar = new int[] { 8, 2 };
//            al.Init(ar);
//            int[] exp = new int[] { 2, 8 };
//            al.Reverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void Testrevers_0()
//        {

//            int[] ar = new int[] { };
//            al.Init(ar);
//            int[] exp = new int[] { };
//            al.Reverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void Testrevers_odd()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2, 2 };
//            al.Init(ar);
//            int[] exp = new int[] { 2, 2, 8, 2, 7, 7, 3 };
//            al.Reverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestHalfReverse_many()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            int[] exp = new int[] { 2, 8, 2, 3, 7, 7 };
//            al.HalfReverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestHalfReverse_1()
//        {

//            int[] ar = new int[] { 3 };
//            al.Init(ar);
//            int[] exp = new int[] { 3 };
//            al.HalfReverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestHalfReverse_2()
//        {

//            int[] ar = new int[] { 3, 7 };
//            al.Init(ar);
//            int[] exp = new int[] { 7, 3 };
//            al.HalfReverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestHalfReverse_odd()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 2 };
//            al.Init(ar);
//            int[] exp = new int[] { 2, 8, 2, 3, 7, 7 };
//            al.HalfReverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestHalfReverse_0()
//        {

//            int[] exp = new int[] { };
//            al.HalfReverse();
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestIndMin_many()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 1 };
//            al.Init(ar);
//            int exp = 5;
//            Assert.AreEqual(exp, al.IndMin());
//        }
//        [TestMethod]
//        public void TestIndMin_odd()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 1, 0 };
//            al.Init(ar);
//            int exp = 6;
//            Assert.AreEqual(exp, al.IndMin());
//        }
//        [TestMethod]
//        public void TestIndMin_1()
//        {

//            int[] ar = new int[] { 3 };
//            al.Init(ar);
//            int exp = 0;
//            Assert.AreEqual(exp, al.IndMin());
//        }
//        [TestMethod]
//        public void TestIndMin_0()
//        {

//            int[] ar = new int[] { 3 };
//            al.Init(ar);
//            int exp = 0;
//            Assert.AreEqual(exp, al.IndMin());
//        }
//        [TestMethod]
//        public void TestIndMin_2()
//        {

//            int[] ar = new int[] { 3, 7 };
//            al.Init(ar);
//            int exp = 0;
//            Assert.AreEqual(exp, al.IndMin());
//        }
//        [TestMethod]
//        [ExpectedException(typeof(NullReferenceException))]
//        public void TestIndMin_00()
//        {
//            al.IndMin();
//            int[] exp = new int[] { };
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestIndMax_many()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 1 };
//            al.Init(ar);
//            int exp = 4;
//            Assert.AreEqual(exp, al.IndMax());
//        }
//        [TestMethod]
//        public void TestIndMax_1()
//        {

//            int[] ar = new int[] { 3, 7 };
//            al.Init(ar);
//            int exp = 1;
//            Assert.AreEqual(exp, al.IndMax());
//        }
//        [TestMethod]
//        public void TestIndMax_2()
//        {

//            int[] ar = new int[] { 3 };
//            al.Init(ar);
//            int exp = 0;
//            Assert.AreEqual(exp, al.IndMax());
//        }
//        [TestMethod]
//        [ExpectedException(typeof(NullReferenceException))]
//        public void TestIndMax_0()
//        {

//            al.IndMax();
//            int[] arr = new int[] { };
//            CollectionAssert.AreEqual(arr, al.ToArray());
//        }
//        [TestMethod]
//        public void TestMin_()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 1 };
//            al.Init(ar);
//            int exp = 1;
//            Assert.AreEqual(exp, al.Min());
//        }
//        [TestMethod]
//        public void TestMin_2()
//        {

//            int[] ar = new int[] { 3, 7 };
//            al.Init(ar);
//            int exp = 3;
//            Assert.AreEqual(exp, al.Min());
//        }
//        [TestMethod]
//        public void TestMin_1()
//        {

//            int[] ar = new int[] { 8 };
//            al.Init(ar);
//            int exp = 8;
//            Assert.AreEqual(exp, al.Min());
//        }

//        [TestMethod]
//        public void TestMax_many()
//        {

//            int[] ar = new int[] { 3, 7, 7, 2, 8, 1 };
//            al.Init(ar);
//            int exp = 8;
//            Assert.AreEqual(exp, al.Max());
//        }
//        [TestMethod]
//        public void TestMax_1()
//        {

//            int[] ar = new int[] { 1 };
//            al.Init(ar);
//            int exp = 1;
//            Assert.AreEqual(exp, al.Max());
//        }
//        [TestMethod]
//        public void TestMax_2()
//        {

//            int[] ar = new int[] { 8, 1 };
//            al.Init(ar);
//            int exp = 8;
//            Assert.AreEqual(exp, al.Max());
//        }
//        [TestMethod]
//        [ExpectedException(typeof(NullReferenceException))]
//        public void TestMax_()
//        {
//            al.Max();
//            int[] exp = new int[] { };
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestSort_many()
//        {
//            int[] ar = new int[] { 9, 2, 6, 3, 0, 1 };
//            al.Init(ar);
//            al.Sort();
//            int[] exp = new int[] { 0, 1, 2, 3, 6, 9 };
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestSort_1()
//        {

//            int[] ar = new int[] { 1 };
//            al.Init(ar);
//            al.Sort();
//            int[] exp = new int[] { 1 };
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestSort_2()
//        {


//            int[] ar = new int[] { 9, 6 };
//            al.Init(ar);
//            al.Sort();
//            int[] exp = new int[] { 6, 9 };
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestSort_0()
//        {

//            int[] ar = new int[] { };
//            al.Init(ar);
//            al.Sort();
//            int[] exp = new int[] { };
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TestMethod]
//        public void TestSort_odd()
//        {

//            int[] ar = new int[] { 9, 2, 6, 3, 0, 1, 10 };
//            al.Init(ar);
//            al.Sort();
//            int[] exp = new int[] { 0, 1, 2, 3, 6, 9, 10 };
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//    }
//}
