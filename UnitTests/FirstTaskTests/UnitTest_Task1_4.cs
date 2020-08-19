using System;
using Task1_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_Task1_4
    {
        [TestMethod]
        public void TestMethod_Task1_WithinRange_Top()
        {
            string res = "";

            res = Program.Task1(7);

            Assert.AreEqual(res, "воскресенье");
        }

        [TestMethod]
        public void TestMethod_Task1_WithinRange_Middle()
        {
            string res = "";

            res = Program.Task1(4);

            Assert.AreEqual(res, "четверг");
        }

        [TestMethod]
        public void TestMethod_Task1_WithinRange_Bottom()
        {
            string res = "";

            res = Program.Task1(1);

            Assert.AreEqual(res, "понедельник");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task1_BeneathRange_Exc()
        {
            Program.Task1(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task1_AboveRange_Exc()
        {
            Program.Task1(8);
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task4_DiffPoints()
        {
            double res = 0;

            res = Program.Task4(2, 2, -8, 2);

            Assert.AreEqual(res, 10);
        }

        [TestMethod]
        public void TestMethod_Task4_SamePoint()
        {
            double res = 0;

            res = Program.Task4(0, 0, 0, 0);

            Assert.AreEqual(res, 0);
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task2_0()
        {
            string res = "";

            res = Program.Task2(0);

            Assert.AreEqual(res, "zero");
        }

        [TestMethod]
        public void TestMethod_Task2_7()
        {
            string res = "";

            res = Program.Task2(7);

            Assert.AreEqual(res, "seven");
        }

        [TestMethod]
        public void TestMethod_Task2_11()
        {
            string res = "";

            res = Program.Task2(11);

            Assert.AreEqual(res, "eleven");
        }

        [TestMethod]
        public void TestMethod_Task2_100()
        {
            string res = "";

            res = Program.Task2(100);

            Assert.AreEqual(res, "one hundred");
        }

        [TestMethod]
        public void TestMethod_Task2_101()
        {
            string res = "";

            res = Program.Task2(101);

            Assert.AreEqual(res, "one hundred one");
        }

        [TestMethod]
        public void TestMethod_Task2_110()
        {
            string res = "";

            res = Program.Task2(110);

            Assert.AreEqual(res, "one hundred ten");
        }

        [TestMethod]
        public void TestMethod_Task2_111()
        {
            string res = "";

            res = Program.Task2(111);

            Assert.AreEqual(res, "one hundred eleven");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task2_AboveRange_Exc()
        {
            Program.Task2(1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task2_BeneathRange_Exc()
        {
            Program.Task2(-1);
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task3_0()
        {
            long res = 0;

            res = Program.Task3("zero");

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void TestMethod_Task3_7()
        {
            long res = 0;

            res = Program.Task3("seven");

            Assert.AreEqual(res, 7);
        }

        [TestMethod]
        public void TestMethod_Task3_11()
        {
            long res = 0;

            res = Program.Task3("eleven");

            Assert.AreEqual(res, 11);
        }

        [TestMethod]
        public void TestMethod_Task3_100()
        {
            long res = 0;

            res = Program.Task3("one hundred");

            Assert.AreEqual(res, 100);
        }

        [TestMethod]
        public void TestMethod_Task3_101()
        {
            long res = 0;

            res = Program.Task3("one hundred one");

            Assert.AreEqual(res, 101);
        }

        [TestMethod]
        public void TestMethod_Task3_110()
        {
            long res = 0;

            res = Program.Task3("one hundred ten");

            Assert.AreEqual(res, 110);
        }

        [TestMethod]
        public void TestMethod_Task3_111()
        {
            long res = 0;

            res = Program.Task3("one hundred eleven");

            Assert.AreEqual(res, 111);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task3_BeneathRange_Exc()
        {
            Program.Task3("minus one hundred eleven");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task3_AboveRange_Exc()
        {
            Program.Task3("one thousand");
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task5_Thousand()
        {
            string res = "";

            res = Program.Task5(11206);

            Assert.AreEqual(res, "eleven thousand two hundred six");
        }

        [TestMethod]
        public void TestMethod_Task5_Million()
        {
            string res = "";

            res = Program.Task5(13411206);

            Assert.AreEqual(res, "thirteen million four hundred eleven thousand two hundred six");
        }

        [TestMethod]
        public void TestMethod_Task5_Billion()
        {
            string res = "";

            res = Program.Task5(7113411206);

            Assert.AreEqual(res, "seven billion one hundred thirteen million four hundred eleven thousand two hundred six");
        }

        [TestMethod]
        public void TestMethod_Task5_OnlyThousand()
        {
            string res = "";

            res = Program.Task5(11000);

            Assert.AreEqual(res, "eleven thousand");
        }

        [TestMethod]
        public void TestMethod_Task5_OnlyMillion()
        {
            string res = "";

            res = Program.Task5(10000000);

            Assert.AreEqual(res, "ten million");
        }

        [TestMethod]
        public void TestMethod_Task5_OnlyBillion()
        {
            string res = "";

            res = Program.Task5(100000000000);

            Assert.AreEqual(res, "one hundred billion");
        }

        [TestMethod]
        public void TestMethod_Task5_WithoutHundred()
        {
            string res = "";

            res = Program.Task5(7113411000);

            Assert.AreEqual(res, "seven billion one hundred thirteen million four hundred eleven thousand");
        }

        [TestMethod]
        public void TestMethod_Task5_WithoutThousand()
        {
            string res = "";

            res = Program.Task5(7113000206);

            Assert.AreEqual(res, "seven billion one hundred thirteen million two hundred six");
        }

        [TestMethod]
        public void TestMethod_Task5_WithoutMillion()
        {
            string res = "";

            res = Program.Task5(7000411206);

            Assert.AreEqual(res, "seven billion four hundred eleven thousand two hundred six");
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
            Program.Task5(1000000000000);
        }
//////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestMethod_Task6_Thousand()
        {
            long res = 0;

            res = Program.Task6("eleven thousand two hundred six");

            Assert.AreEqual(res, 11206);
        }

        [TestMethod]
        public void TestMethod_Task6_Million()
        {
            long res = 0;

            res = Program.Task6("thirteen million four hundred eleven thousand two hundred six");

            Assert.AreEqual(res, 13411206);
        }

        [TestMethod]
        public void TestMethod_Task6_Billion()
        {
            long res = 0;

            res = Program.Task6("seven billion one hundred thirteen million four hundred eleven thousand two hundred six");

            Assert.AreEqual(res, 7113411206);
        }

        [TestMethod]
        public void TestMethod_Task6_OnlyThousand()
        {
            long res = 0;

            res = Program.Task6("eleven thousand");

            Assert.AreEqual(res, 11000);
        }

        [TestMethod]
        public void TestMethod_Task6_OnlyMillion()
        {
            long res = 0;

            res = Program.Task6("ten million");

            Assert.AreEqual(res, 10000000);
        }

        [TestMethod]
        public void TestMethod_Task6_OnlyBillion()
        {
            long res = 0;

            res = Program.Task6("one hundred billion");

            Assert.AreEqual(res, 100000000000);
        }

        [TestMethod]
        public void TestMethod_Task6_WithoutHundred()
        {
            long res = 0;

            res = Program.Task6("seven billion one hundred thirteen million four hundred eleven thousand");

            Assert.AreEqual(res, 7113411000);
        }

        [TestMethod]
        public void TestMethod_Task6_WithoutThousand()
        {
            long res = 0;

            res = Program.Task6("seven billion one hundred thirteen million two hundred six");

            Assert.AreEqual(res, 7113000206);
        }

        [TestMethod]
        public void TestMethod_Task6_WithoutMillion()
        {
            long res = 0;

            res = Program.Task6("seven billion four hundred eleven thousand two hundred six");

            Assert.AreEqual(res, 7000411206);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task6_AboveRange_Exc()
        {
            Program.Task6("one trillion");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task6_BeneathRange_Exc()
        {
            Program.Task6("minus one billion eleven");
        }

    }
}
