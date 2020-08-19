using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTests_JS
{
    public class POM
    {
        public POM(RemoteWebDriver driver, string path)
        {
            _driver = driver;
            _path = path;

            NavigateToPage();
            PomObjInit();
        }


        public Dictionary<string, IWebElement> pomObj = new Dictionary<string, IWebElement>();

        private IWebElement button0;
        private IWebElement button1;
        private IWebElement button2;
        private IWebElement button3;
        private IWebElement button4;
        private IWebElement button5;
        private IWebElement button6;
        private IWebElement button7;
        private IWebElement button8;
        private IWebElement button9;
        private IWebElement buttonPlus;
        private IWebElement buttonMinus;
        private IWebElement buttonMul;
        private IWebElement buttonDiv;
        private IWebElement buttonEqual;
        private IWebElement inputResult;
        private RemoteWebDriver _driver;
        private string _path;


        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(_path);

            PomObjInit();
        }

        public void NavigateToPage(string path)
        {
            _driver.Navigate().GoToUrl(path);

            PomObjInit();
        }

        public void ClickCalcButton()
        {
            buttonEqual.Click();
        }

        public bool ButtonDisplayed(string button)
        {
            return pomObj[button].Displayed;
        }

        public void ClickButton(string button)
        {
            pomObj[button].Click();
        }

        public void ClickButton(string[] buttons)
        {
            foreach (string button in buttons)
            {
                pomObj[button].Click();
            }
        }

        public string GetResult()
        {
            return inputResult.GetAttribute("value");
        }

        public string GetAlertMessage()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            string res = alert.Text;
            alert.Accept();

            return res;
        }

        public void CreateSceenshot()
        {
            Screenshot printscreen = _driver.GetScreenshot();
            Directory.CreateDirectory("Screen");
            string path = "Screen/OverflowException" + DateTime.Now.Hour.ToString() +
                "_" + DateTime.Now.Minute.ToString() +
                "_" + DateTime.Now.Second.ToString() + ".jpg";
            printscreen.SaveAsFile(path, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        private void PomObjInit()
        {
            button0 = _driver.FindElement(By.Id("B_0"));
            button1 = _driver.FindElement(By.Id("B_1"));
            button2 = _driver.FindElement(By.Id("B_2"));
            button3 = _driver.FindElement(By.Id("B_3"));
            button4 = _driver.FindElement(By.Id("B_4"));
            button5 = _driver.FindElement(By.Id("B_5"));
            button6 = _driver.FindElement(By.Id("B_6"));
            button7 = _driver.FindElement(By.Id("B_7"));
            button8 = _driver.FindElement(By.Id("B_8"));
            button9 = _driver.FindElement(By.Id("B_9"));
            buttonPlus = _driver.FindElement(By.Id("B_Plus"));
            buttonMinus = _driver.FindElement(By.Id("B_Minus"));
            buttonMul = _driver.FindElement(By.Id("B_Mul"));
            buttonDiv = _driver.FindElement(By.Id("B_Div"));
            buttonEqual = _driver.FindElement(By.Id("B_Calc"));
            inputResult = _driver.FindElement(By.Id("TB_R"));

            pomObj = new Dictionary<string, IWebElement>();
            pomObj.Add(button0.GetAttribute("id"), button0);
            pomObj.Add(button1.GetAttribute("id"), button1);
            pomObj.Add(button2.GetAttribute("id"), button2);
            pomObj.Add(button3.GetAttribute("id"), button3);
            pomObj.Add(button4.GetAttribute("id"), button4);
            pomObj.Add(button5.GetAttribute("id"), button5);
            pomObj.Add(button6.GetAttribute("id"), button6);
            pomObj.Add(button7.GetAttribute("id"), button7);
            pomObj.Add(button8.GetAttribute("id"), button8);
            pomObj.Add(button9.GetAttribute("id"), button9);
            pomObj.Add(buttonPlus.GetAttribute("id"), buttonPlus);
            pomObj.Add(buttonMinus.GetAttribute("id"), buttonMinus);
            pomObj.Add(buttonMul.GetAttribute("id"), buttonMul);
            pomObj.Add(buttonDiv.GetAttribute("id"), buttonDiv);
            pomObj.Add(buttonEqual.GetAttribute("id"), buttonEqual);
            pomObj.Add(inputResult.GetAttribute("id"), inputResult);
        }

    }
}
