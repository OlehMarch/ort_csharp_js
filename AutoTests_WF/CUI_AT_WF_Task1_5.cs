using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace UIT_Task2
{
    /// <summary>
    /// Сводное описание для UITest_WF_Task1_5
    /// </summary>
    [CodedUITest]
    public class CUI_AT_WF_Task1_5
    {
        public CUI_AT_WF_Task1_5()
        {
        }

        [TestMethod]
        public void WF_UITestMethod_Plus_Int()
        {
            this.UIMap.UIT_Plus_Int();
            this.UIMap.VerifyResult_Plus_Int();
        }

        [TestMethod]
        public void WF_UITestMethod_Minus_Int()
        {
            this.UIMap.UIT_Minus_Int();
            this.UIMap.VerifyResult_Minus_Int();
        }

        [TestMethod]
        public void WF_UITestMethod_Mul_Int()
        {
            this.UIMap.UIT_Mul_Int();
            this.UIMap.VerifyResult_Mul_Int();
        }

        [TestMethod]
        public void WF_UITestMethod_Div_Int()
        {
            this.UIMap.UIT_Div_Int();
            this.UIMap.VerifyResult_Div_Int();
        }

        [TestMethod]
        public void WF_UITestMethod_Plus_Float()
        {
            this.UIMap.UIT_Plus_Float();
            this.UIMap.VerifyResult_Plus_Float();
        }

        [TestMethod]
        public void WF_UITestMethod_Minus_Float()
        {
            this.UIMap.UIT_Minus_Float();
            this.UIMap.VerifyResult_Minus_Float();
        }

        [TestMethod]
        public void WF_UITestMethod_Mul_Float()
        {
            this.UIMap.UIT_Mul_Float();
            this.UIMap.VerifyResult_Mul_Float();
        }

        [TestMethod]
        public void WF_UITestMethod_Div_Float()
        {
            this.UIMap.UIT_Div_Float();
            this.UIMap.VerifyResult_Div_Float();
        }

        [TestMethod]
        public void WF_UITestMethod_EmptyField_Exc()
        {
            try
            {
                this.UIMap.UIT_EmptyField_Exc();
            }
            catch (FormatException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void WF_UITestMethod_LettersInField_Exc()
        {
            try
            {
                this.UIMap.UIT_LettersInField_Exc();
            }
            catch (FormatException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void WF_UITestMethod_SignField_Exc()
        {
            try
            {
                this.UIMap.UIT_SignField_Exc();
            }
            catch (ArgumentException)
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
            pathToApp = @"D:/Projects/CSharpPrograms/ORT/Task1_5/bin/Debug";
            appToTest = ApplicationUnderTest.Launch(Path.Combine(pathToApp, "Task1_5.exe"));
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

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
