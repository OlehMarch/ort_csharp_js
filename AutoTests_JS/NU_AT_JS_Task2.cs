using System;
using RelevantCodes.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;


namespace AutoTests_JS
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public class NU_AT_JS_Task2<TDriver> where TDriver : RemoteWebDriver, new()
    {
        private POM pom = new POM(new TDriver(), "file:///D:/Projects/CSharpPrograms/ORT/Task2_02/JS/JS_Calculator.html");
        public ExtentReports extent;
        public ExtentTest test;


        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));

            string reportPath = @"D:\Projects\CSharpPrograms\ORT\AutoTests_JS\ExtentStepLogs1.html";
            extent = new ExtentReports(reportPath, true);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            extent.EndTest(test);
            test.Log(LogStatus.Info, "EndTest() method will stop capturing information about the test log");
            extent.Flush();
            test.Log(LogStatus.Info, "Flush() method of ExtentReports wil push/write everything to the document");
            extent.Close();
            test.Log(LogStatus.Info, "Close() method will clear/close all resource of the ExtentReports object");

            pom.Dispose();
        }

        [TestCase("B_0", TestName = "Test button 0 existance")]
        [TestCase("B_1", TestName = "Test button 1 existance")]
        [TestCase("B_2", TestName = "Test button 2 existance")]
        [TestCase("B_3", TestName = "Test button 3 existance")]
        [TestCase("B_4", TestName = "Test button 4 existance")]
        [TestCase("B_5", TestName = "Test button 5 existance")]
        [TestCase("B_6", TestName = "Test button 6 existance")]
        [TestCase("B_7", TestName = "Test button 7 existance")]
        [TestCase("B_8", TestName = "Test button 8 existance")]
        [TestCase("B_9", TestName = "Test button 9 existance")]
        [TestCase("B_Plus", TestName = "Test button Plus existance")]
        [TestCase("B_Minus", TestName = "Test button Minus existance")]
        [TestCase("B_Mul", TestName = "Test button Multiplication existance")]
        [TestCase("B_Div", TestName = "Test button Division existance")]
        [TestCase("B_Calc", TestName = "Test button Calculate existance")]
        [TestCase("TB_R", TestName = "Test Result field existance")]
        public void TestElementExistance(string buttonID)
        {
            test = extent.StartTest("Existance test of " + buttonID);

            test.Log(LogStatus.Info, "StartTest() method will return the Extent Test object ");
            test.Log(LogStatus.Info, "I am in actual test method");
            test.Log(LogStatus.Info, "We Can Write The Actual Test Logic In This Test");

            pom.NavigateToPage();
            Assert.AreEqual(true, pom.ButtonDisplayed(buttonID));

            extent.EndTest(test);
        }

        [TestCase("B_0", "0", TestName = "Test button 0 click")]
        [TestCase("B_1", "1", TestName = "Test button 1 click")]
        [TestCase("B_2", "2", TestName = "Test button 2 click")]
        [TestCase("B_3", "3", TestName = "Test button 3 click")]
        [TestCase("B_4", "4", TestName = "Test button 4 click")]
        [TestCase("B_5", "5", TestName = "Test button 5 click")]
        [TestCase("B_6", "6", TestName = "Test button 6 click")]
        [TestCase("B_7", "7", TestName = "Test button 7 click")]
        [TestCase("B_8", "8", TestName = "Test button 8 click")]
        [TestCase("B_9", "9", TestName = "Test button 9 click")]
        public void TestButton(string buttonID, string exp)
        {
            test = extent.StartTest("Click test of " + buttonID);

            test.Log(LogStatus.Info, "StartTest() method will return the Extent Test object ");
            test.Log(LogStatus.Info, "I am in actual test method");
            test.Log(LogStatus.Info, "We Can Write The Actual Test Logic In This Test");

            pom.NavigateToPage();
            pom.ClickButton(buttonID);
            string actual = pom.GetResult();
            Assert.AreEqual(exp, actual);

            extent.EndTest(test);
        }

        [TestCase("B_8", "B_2", "B_Mul", "16", TestName = "Test Multiplication")]
        [TestCase("B_8", "B_2", "B_Div", "4", TestName = "Test Division")]
        [TestCase("B_8", "B_2", "B_Plus", "10", TestName = "Test Plus")]
        [TestCase("B_8", "B_2", "B_Minus", "6", TestName = "Test Minus")]
        public void TestOperation(string elementA, string elementB, string operation, string exp)
        {
            test = extent.StartTest("Test of " + operation);

            test.Log(LogStatus.Info, "StartTest() method will return the Extent Test object ");
            test.Log(LogStatus.Info, "I am in actual test method");
            test.Log(LogStatus.Info, "We Can Write The Actual Test Logic In This Test");

            pom.NavigateToPage();
            pom.ClickButton(elementA);
            pom.ClickButton(operation);
            pom.ClickButton(elementB);
            pom.ClickCalcButton();
            string actual = pom.GetResult();
            Assert.AreEqual(exp, actual);

            extent.EndTest(test);
        }

        [TestCase("B_8", "B_0", "B_Div", "SyntaxError: DivisionOnZero!", TestName = "Test division by zero exception handling")]
        public void TestDivZeroException(string elementA, string elementB, string operation, string exp)
        {
            test = extent.StartTest("Exception test: " + exp);

            test.Log(LogStatus.Info, "StartTest() method will return the Extent Test object ");
            test.Log(LogStatus.Info, "I am in actual test method");
            test.Log(LogStatus.Info, "We Can Write The Actual Test Logic In This Test");

            pom.NavigateToPage();
            pom.ClickButton(elementA);
            pom.ClickButton(operation);
            pom.ClickButton(elementB);
            pom.ClickCalcButton();
            string actual = pom.GetAlertMessage();
            Assert.AreEqual(exp, actual);

            extent.EndTest(test);
        }

        [TestCase("B_8", "B_5", "B_Mul", "Error", TestName = "Test overflow exception handling")]
        public void TestOverflowException(string elementA, string elementB, string operation, string exp)
        {
            test = extent.StartTest("Exception test: OverflowException");

            test.Log(LogStatus.Info, "StartTest() method will return the Extent Test object ");
            test.Log(LogStatus.Info, "I am in actual test method");
            test.Log(LogStatus.Info, "We Can Write The Actual Test Logic In This Test");

            pom.NavigateToPage();
            for (int i = 0; i < 15; i++)
            {
                pom.ClickButton(elementA);
            }
            pom.ClickButton(operation);
            pom.ClickButton(elementB);
            pom.ClickCalcButton();
            string actual = pom.GetResult();
            if (actual == exp)
            {
                pom.CreateSceenshot();
            }
            Assert.AreEqual(exp, actual);

            extent.EndTest(test);
        }

    }
}
