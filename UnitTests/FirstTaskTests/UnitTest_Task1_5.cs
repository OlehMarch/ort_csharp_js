using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1_5;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_Task1_5
    {
        [TestMethod]
        public void WF_Task1_5_UT_Plus_Int()
        {
            string res = "";

            res = Calculation.Calculate("123", "123", "+");

            Assert.AreEqual(res, "246");
        }

        [TestMethod]
        public void WF_Task1_5_UT_Minus_Int()
        {
            string res = "";

            res = Calculation.Calculate("271", "91", "-");

            Assert.AreEqual(res, "180");
        }

        [TestMethod]
        public void WF_Task1_5_UT_Mul_Int()
        {
            string res = "";

            res = Calculation.Calculate("12", "12", "*");

            Assert.AreEqual(res, "144");
        }

        [TestMethod]
        public void WF_Task1_5_UT_Div_Int()
        {
            string res = "";

            res = Calculation.Calculate("256", "64", "/");

            Assert.AreEqual(res, "4");
        }

        [TestMethod]
        public void WF_Task1_5_UT_Plus_Float()
        {
            string res = "";

            res = Calculation.Calculate("12,3", "1,23", "+");

            Assert.AreEqual(res, "13,53");
        }

        [TestMethod]
        public void WF_Task1_5_UT_Minus_Float()
        {
            string res = "";

            res = Calculation.Calculate("2,71", "9,1", "-");

            Assert.AreEqual(res, "-6,39");
        }

        [TestMethod]
        public void WF_Task1_5_UT_Mul_Float()
        {
            string res = "";

            res = Calculation.Calculate("1,2", "1,2", "*");

            Assert.AreEqual(res, "1,44");
        }

        [TestMethod]
        public void WF_Task1_5_UT_Div_Float()
        {
            string res = "";

            res = Calculation.Calculate("256,256", "64", "/");

            Assert.AreEqual(res, "4,004");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void WF_Task1_5_UT_EmptyField_FormatExc()
        {
            Calculation.Calculate("", "123", "/");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WF_Task1_5_UT_SignExc()
        {
            Calculation.Calculate("123", "123", "%");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void WF_Task1_5_UT_LettersInField_ArgExc()
        {
            Calculation.Calculate("abc", "123", "+");
        }

    }
}
