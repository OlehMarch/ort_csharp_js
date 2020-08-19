using System;
using Task1_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_Task1_1
    {
        [TestMethod]
        public void TestMethod_Task1_Even()
        {
            int res = 0;

            res = Program.Task1(10, 20);

            Assert.AreEqual(res, 200);
        }

        [TestMethod]
        public void TestMethod_Task1_Odd()
        {
            int res = 0;

            res = Program.Task1(1, 20);

            Assert.AreEqual(res, 21);
        }

        [TestMethod]
        public void TestMethod_Task1_Null()
        {
            int res = 0;

            res = Program.Task1(0, 20);

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void TestMethod_Task1_NegEven()
        {
            int res = 0;

            res = Program.Task1(-10, 20);

            Assert.AreEqual(res, -200);
        }

        [TestMethod]
        public void TestMethod_Task1_NegOdd()
        {
            int res = 0;

            res = Program.Task1(-1, 20);

            Assert.AreEqual(res, 19);
        }
/////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task2_Quarter1()
        {
            int res = 0;

            res = Program.Task2(10, 20);

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task2_Quarter2()
        {
            int res = 0;

            res = Program.Task2(-10, 20);

            Assert.AreEqual(res, 2);
        }

        [TestMethod]
        public void TestMethod_Task2_Quarter3()
        {
            int res = 0;

            res = Program.Task2(-10, -20);

            Assert.AreEqual(res, 3);
        }

        [TestMethod]
        public void TestMethod_Task2_Quarter4()
        {
            int res = 0;

            res = Program.Task2(10, -20);

            Assert.AreEqual(res, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task2_OnAxisY_Exc()
        {
            Program.Task2(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task2_OnAxisX_Exc()
        {
            Program.Task2(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task2_OnBothAxis_Exc()
        {
            Program.Task2(0, 0);
        }
/////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task3_3Pos()
        {
            int res = 0;

            res = Program.Task3(1, 2, 3);

            Assert.AreEqual(res, 6);
        }

        [TestMethod]
        public void TestMethod_Task3_2Pos()
        {
            int res = 0;

            res = Program.Task3(-1, 2, 3);

            Assert.AreEqual(res, 5);
        }

        [TestMethod]
        public void TestMethod_Task3_1Pos()
        {
            int res = 0;

            res = Program.Task3(-1, -2, 3);

            Assert.AreEqual(res, 3);
        }

        [TestMethod]
        public void TestMethod_Task3_3Neg()
        {
            int res = 0;

            res = Program.Task3(-1, -2, -3);

            Assert.AreEqual(res, 0);
        }
/////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task4_LMax()
        {
            int res = 0;

            res = Program.Task4(2, 2, 2);

            Assert.AreEqual(res, 11);
        }

        [TestMethod]
        public void TestMethod_Task4_RMax()
        {
            int res = 0;

            res = Program.Task4(1, 1, 1);

            Assert.AreEqual(res, 6);
        }

        [TestMethod]
        public void TestMethod_Task4_Equal()
        {
            int res = 0;

            res = Program.Task4(0, 0, 0);

            Assert.AreEqual(res, 3);
        }
/////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task5_TopF()
        {
            string res = "";

            res = Program.Task5(19);

            Assert.AreEqual(res, "F");
        }

        [TestMethod]
        public void TestMethod_Task5_BottomF()
        {
            string res = "";

            res = Program.Task5(0);

            Assert.AreEqual(res, "F");
        }

        [TestMethod]
        public void TestMethod_Task5_MiddleF()
        {
            string res = "";

            res = Program.Task5(10);

            Assert.AreEqual(res, "F");
        }

        [TestMethod]
        public void TestMethod_Task5_TopE()
        {
            string res = "";

            res = Program.Task5(39);

            Assert.AreEqual(res, "E");
        }

        [TestMethod]
        public void TestMethod_Task5_BottomE()
        {
            string res = "";

            res = Program.Task5(20);

            Assert.AreEqual(res, "E");
        }

        [TestMethod]
        public void TestMethod_Task5_MiddleE()
        {
            string res = "";

            res = Program.Task5(30);

            Assert.AreEqual(res, "E");
        }

        [TestMethod]
        public void TestMethod_Task5_TopD()
        {
            string res = "";

            res = Program.Task5(59);

            Assert.AreEqual(res, "D");
        }

        [TestMethod]
        public void TestMethod_Task5_BottomD()
        {
            string res = "";

            res = Program.Task5(40);

            Assert.AreEqual(res, "D");
        }

        [TestMethod]
        public void TestMethod_Task5_MiddleD()
        {
            string res = "";

            res = Program.Task5(50);

            Assert.AreEqual(res, "D");
        }

        [TestMethod]
        public void TestMethod_Task5_TopC()
        {
            string res = "";

            res = Program.Task5(74);

            Assert.AreEqual(res, "C");
        }

        [TestMethod]
        public void TestMethod_Task5_BottomC()
        {
            string res = "";

            res = Program.Task5(60);

            Assert.AreEqual(res, "C");
        }

        [TestMethod]
        public void TestMethod_Task5_MiddleC()
        {
            string res = "";

            res = Program.Task5(67);

            Assert.AreEqual(res, "C");
        }

        [TestMethod]
        public void TestMethod_Task5_TopB()
        {
            string res = "";

            res = Program.Task5(89);

            Assert.AreEqual(res, "B");
        }

        [TestMethod]
        public void TestMethod_Task5_BottomB()
        {
            string res = "";

            res = Program.Task5(75);

            Assert.AreEqual(res, "B");
        }

        [TestMethod]
        public void TestMethod_Task5_MiddleB()
        {
            string res = "";

            res = Program.Task5(82);

            Assert.AreEqual(res, "B");
        }

        [TestMethod]
        public void TestMethod_Task5_TopA()
        {
            string res = "";

            res = Program.Task5(100);

            Assert.AreEqual(res, "A");
        }

        [TestMethod]
        public void TestMethod_Task5_BottomA()
        {
            string res = "";

            res = Program.Task5(90);

            Assert.AreEqual(res, "A");
        }

        [TestMethod]
        public void TestMethod_Task5_MiddleA()
        {
            string res = "";

            res = Program.Task5(95);

            Assert.AreEqual(res, "A");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task5_BeneathRange_Exc()
        {
            Program.Task5(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task5_AboveRange_Exc()
        {
            Program.Task5(101);
        }

    }
}
