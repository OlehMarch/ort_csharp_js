using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTests_JS
{
    [TestClass]
    public class MS_AT_JS_Task1_5
    {
        private string url = "file:///D:/Projects/CSharpPrograms/ORT/Task1_5/JS/JS_Calculator.html";

        private string ExecuteInBrowser(string firstOperand, string secondOperand, string operation)
        {
            string res = "";

            IWebElement tb_firstOperand = null;
            IWebElement tb_secondOperand = null;
            IWebElement tb_operation = null;
            IWebElement tb_result = null;
            IWebElement b_calculate = null;
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl(url);
                tb_firstOperand = driver.FindElement(By.Id("TB_FO"));
                tb_secondOperand = driver.FindElement(By.Id("TB_SO"));
                tb_operation = driver.FindElement(By.Id("TB_O"));
                tb_result = driver.FindElement(By.Id("TB_R"));
                b_calculate = driver.FindElement(By.Id("B_Calc"));

                tb_firstOperand.SendKeys(firstOperand);
                tb_operation.SendKeys(operation);
                tb_secondOperand.SendKeys(secondOperand);
                b_calculate.Click();

                res = tb_result.GetAttribute("value");
            }
            finally
            {
                driver.Quit();
            }

            return res;
        }
/////////////////////////////////////////////////////////////
        [TestMethod]
        public void JS_Task1_5_B_Plus_Int()
        {
            string res = "";

            res = ExecuteInBrowser("123", "123", "+");

            Assert.AreEqual(res, "246");
        }

        [TestMethod]
        public void JS_Task1_5_B_Minus_Int()
        {
            string res = "";

            res = ExecuteInBrowser("271", "91", "-");

            Assert.AreEqual(res, "180");
        }

        [TestMethod]
        public void JS_Task1_5_B_Mul_Int()
        {
            string res = "";

            res = ExecuteInBrowser("12", "12", "*");

            Assert.AreEqual(res, "144");
        }

        [TestMethod]
        public void JS_Task1_5_B_Div_Int()
        {
            string res = "";

            res = ExecuteInBrowser("256", "64", "/");

            Assert.AreEqual(res, "4");
        }

        [TestMethod]
        public void JS_Task1_5_B_Plus_Float()
        {
            string res = "";

            res = ExecuteInBrowser("12.3", "1.23", "+");

            Assert.AreEqual(res, "13.53");
        }

        [TestMethod]
        public void JS_Task1_5_B_Minus_Float()
        {
            string res = "";

            res = ExecuteInBrowser("2.71", "9.1", "-");

            Assert.AreEqual(res, "-6.39");
        }

        [TestMethod]
        public void JS_Task1_5_B_Mul_Float()
        {
            string res = "";

            res = ExecuteInBrowser("1.2", "1.2", "*");

            Assert.AreEqual(res, "1.44");
        }

        [TestMethod]
        public void JS_Task1_5_B_Div_Float()
        {
            string res = "";

            res = ExecuteInBrowser("256.256", "64", "/");

            Assert.AreEqual(res, "4.004");
        }

        [TestMethod]
        public void JS_Task1_5_B_SignExc()
        {
            string res = "";

            res = ExecuteInBrowser("123", "123", "%");

            Assert.AreEqual(res, "");
        }

        [TestMethod]
        public void JS_Task1_5_B_ArgExc()
        {
            string res = "";

            res = ExecuteInBrowser("abc", "123", "+");

            Assert.AreEqual(res, "NaN");
        }
    }
}
