using System;
using Task1_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_Task1_2
    {
        [TestMethod]
        public void TestMethod_Task1_Sum()
        {
            int res = 0;

            res = Program.Task1_Sum();

            Assert.AreEqual(res, 2450);
        }

        [TestMethod]
        public void TestMethod_Task1_Quantity()
        {
            int res = 0;

            res = Program.Task1_Quantity();

            Assert.AreEqual(res, 49);
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task2_Simple()
        {
            bool res = false;

            res = Program.Task2(271);

            Assert.AreEqual(res, true);
        }

        [TestMethod]
        public void TestMethod_Task2_Complex()
        {
            bool res = false;

            res = Program.Task2(273);

            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void TestMethod_Task2_Null()
        {
            bool res = false;

            res = Program.Task2(0);

            Assert.AreEqual(res, true);
        }

        [TestMethod]
        public void TestMethod_Task2_One()
        {
            bool res = false;

            res = Program.Task2(1);

            Assert.AreEqual(res, true);
        }

        [TestMethod]
        public void TestMethod_Task2_Neg()
        {
            bool res = false;

            res = Program.Task2(-1);

            Assert.AreEqual(res, false);
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task3_Null()
        {
            int res = 0;

            res = Program.Task3(0);

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void TestMethod_Task3_Pos()
        {
            int res = 0;

            res = Program.Task3(15);

            Assert.AreEqual(res, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task3_Neg()
        {
            Program.Task3(-15);
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task4_Neg()
        {
            Program.Task4(-1);
        }

        [TestMethod]
        public void TestMethod_Task4_Null()
        {
            int res = 0;

            res = Program.Task4(0);

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void TestMethod_Task4_1()
        {
            int res = 0;

            res = Program.Task4(1);

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task4_5()
        {
            int res = 0;

            res = Program.Task4(5);

            Assert.AreEqual(res, 120);
        }

        [TestMethod]
        public void TestMethod_Task4_Many()
        {
            int res = 0;

            res = Program.Task4(12);

            Assert.AreEqual(res, 479001600);
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task5_Neg()
        {
            Program.Task5(-1);
        }

        [TestMethod]
        public void TestMethod_Task5_Null()
        {
            int res = 0;

            res = Program.Task5(0);

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void TestMethod_Task5_1()
        {
            int res = 0;

            res = Program.Task5(1);

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task5_Many()
        {
            int res = 0;

            res = Program.Task5(1234567);

            Assert.AreEqual(res, 28);
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task6_Neg()
        {
            Program.Task6(-1);
        }

        [TestMethod]
        public void TestMethod_Task6_Null()
        {
            int res = 0;

            res = Program.Task6(0);

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void TestMethod_Task6_10()
        {
            int res = 0;

            res = Program.Task6(10);

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task6_1023()
        {
            int res = 0;

            res = Program.Task6(1023);

            Assert.AreEqual(res, 3201);
        }

        [TestMethod]
        public void TestMethod_Task6_123()
        {
            int res = 0;

            res = Program.Task6(123);

            Assert.AreEqual(res, 321);
        }

        [TestMethod]
        public void TestMethod_Task6_111()
        {
            int res = 0;

            res = Program.Task6(111);

            Assert.AreEqual(res, 111);
        }

    }
}
