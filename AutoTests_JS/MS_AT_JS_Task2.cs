using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests_JS
{
    [TestClass]
    public class MS_AT_JS_Task2
    {
        private POM pom;
        private const string url = "file:///D:/Projects/CSharpPrograms/ORT/Task2_02/JS/JS_Calculator.html";
        private const string dataDriver = "System.Data.OleDb";
        private const string pathToExcelFile = @"D:\Projects\CSharpPrograms\ORT\AutoTests_JS\TestSets.xlsx";
        private const string connectionStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            + pathToExcelFile
            + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


        [TestCleanup]
        public void Cleaup()
        {
            pom.Dispose();
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "TestSet1$", DataAccessMethod.Sequential)]
        public void TestElementExistance()
        {
            string buttonID = TestContext.DataRow["Input Button"].ToString();
            string webDriver = TestContext.DataRow["WebDriver"].ToString();

            pom = new POM(GetDriver(webDriver), url);
            pom.ClickButton(buttonID);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "TestSet2$", DataAccessMethod.Sequential)]
        public void TestButton()
        {
            string buttonID = TestContext.DataRow["Input Button"].ToString();
            string webDriver = TestContext.DataRow["WebDriver"].ToString();
            string exp = TestContext.DataRow["Expected Result"].ToString();

            pom = new POM(GetDriver(webDriver), url);
            pom.ClickButton(buttonID);
            string actual = pom.GetResult();

            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "TestSet3$", DataAccessMethod.Sequential)]
        public void TestOperation()
        {
            string buttonID_A = TestContext.DataRow["Input Button A"].ToString();
            string buttonID_B = TestContext.DataRow["Input Button B"].ToString();
            string buttonID_Sign = TestContext.DataRow["Input Button Sign"].ToString();
            string webDriver = TestContext.DataRow["WebDriver"].ToString();
            string exp = TestContext.DataRow["Expected Result"].ToString();

            pom = new POM(GetDriver(webDriver), url);
            pom.ClickButton(buttonID_A);
            pom.ClickButton(buttonID_Sign);
            pom.ClickButton(buttonID_B);
            pom.ClickCalcButton();
            string actual = pom.GetResult();

            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "TestSet4$", DataAccessMethod.Sequential)]
        public void TestDivZeroException()
        {
            string buttonID_A = TestContext.DataRow["Input Button A"].ToString();
            string buttonID_B = TestContext.DataRow["Input Button B"].ToString();
            string buttonID_Sign = TestContext.DataRow["Input Button Sign"].ToString();
            string webDriver = TestContext.DataRow["WebDriver"].ToString();
            string exp = TestContext.DataRow["Expected Result"].ToString();

            pom = new POM(GetDriver(webDriver), url);
            pom.ClickButton(buttonID_A);
            pom.ClickButton(buttonID_Sign);
            pom.ClickButton(buttonID_B);
            pom.ClickCalcButton();
            string actual = pom.GetAlertMessage();

            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "TestSet5$", DataAccessMethod.Sequential)]
        public void TestOverflowException()
        {
            string buttonID_A = TestContext.DataRow["Input Button A"].ToString();
            string buttonID_B = TestContext.DataRow["Input Button B"].ToString();
            string buttonID_Sign = TestContext.DataRow["Input Button Sign"].ToString();
            string webDriver = TestContext.DataRow["WebDriver"].ToString();
            string exp = TestContext.DataRow["Expected Result"].ToString();

            pom = new POM(GetDriver(webDriver), url);
            for (int i = 0; i < 15; i++)
            {
                pom.ClickButton(buttonID_A);
            }
            pom.ClickButton(buttonID_Sign);
            pom.ClickButton(buttonID_B);
            pom.ClickCalcButton();
            string actual = pom.GetResult();

            if (actual == exp)
            {
                pom.CreateSceenshot();
            }

            Assert.AreEqual(exp, actual);
        }

        private RemoteWebDriver GetDriver(string webDriver)
        {
            RemoteWebDriver driver;

            switch (webDriver)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new WebDriverException();
            }

            return driver;
        }

    }
}
