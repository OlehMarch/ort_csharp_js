using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.IO;

namespace UIT_Task2
{
    /// <summary>
    /// Сводное описание для CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CUI_AT_WF_Task2_2
    {
        public CUI_AT_WF_Task2_2()
        {
        }

        [TestMethod]
        public void WF_Task2_2_ButtonTest()
        {
            this.UIMap.WF_ButtonTest();
            this.UIMap.VerifyResult_ButtonTest();
        }

        [TestMethod]
        public void WF_Task2_2_Plus()
        {
            this.UIMap.WF_Plus();
            this.UIMap.VerifyResult_Plus();
        }

        [TestMethod]
        public void WF_Task2_2_Minus()
        {
            this.UIMap.WF_Minus();
            this.UIMap.VerifyResult_Minus();
        }

        [TestMethod]
        public void WF_Task2_2_Mul()
        {
            this.UIMap.WF_Mul();
            this.UIMap.VerifyResult_Mul();
        }

        [TestMethod]
        public void WF_Task2_2_Div()
        {
            this.UIMap.WF_Div();
            this.UIMap.VerifyResult_Div();
        }

        [TestMethod]
        public void WF_Task2_2_DivByNull_Exc()
        {
            try
            {
                this.UIMap.WF_DivByNull();
            }
            catch (DivideByZeroException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void WF_Task2_2_ArgExc()
        {
            try
            {
                this.UIMap.WF_ArgExc();
            }
            catch (FormatException)
            {
                Assert.IsTrue(true);
            }
        }

        #region Дополнительные атрибуты тестирования

        // При написании тестов можно использовать следующие дополнительные атрибуты:
        string pathToApp;
        ApplicationUnderTest appToTest;

        //TestInitialize используется для выполнения кода перед запуском каждого теста 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            pathToApp = @"D:\Projects\CSharpPrograms\ORT\Task2_02\bin\Debug";
            appToTest = ApplicationUnderTest.Launch(Path.Combine(pathToApp, "Task2_02.exe"));
        }

        //TestCleanup используется для выполнения кода после завершения каждого теста
        [TestCleanup()]
        public void MyTestCleanup()
        {
            appToTest.Close();
        }

        #endregion

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap2 UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap2();
                }

                return this.map;
            }
        }

        private UIMap2 map;
    }
}
