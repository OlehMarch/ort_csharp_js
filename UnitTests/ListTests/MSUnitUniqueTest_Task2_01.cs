using System;
using Task2_01;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTests
{
    [TestClass]
    public class MSUnitUniqueTest_Task2_01
    {

        #region Specific tests for AList1
        [TestMethod]
        public void Init_AList1()
        {
            AList1 list = new AList1();
            list.Init(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.AreEqual(11, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddStart_AList1()
        {
            AList1 list = new AList1();
            list.Init(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            list.AddStart(0);

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(10, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddEnd_AList1()
        {
            AList1 list = new AList1();
            list.Init(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            list.AddEnd(9);

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(10, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddPos_AList1()
        {
            AList1 list = new AList1();
            list.Init(new int[] { 0, 1, 2, 4, 5, 6, 7, 8, 9 });
            list.AddPos(3, 3);

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(10, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Specific tests for AList2
        [TestMethod]
        public void Init_AList2()
        {
            AList2 list = new AList2();
            int[] exp = new int[40] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            list.Init(exp);

            int[] act = list.ToArray();

            Assert.AreEqual(40, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddStart_AList2()
        {
            AList2 list = new AList2();
            for (int i = 0; i < 16; ++i)
            {
                list.AddStart(0);
            }

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.AreEqual(16, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddStart_Upscale_AList2()
        {
            AList2 list = new AList2();
            for (int i = 0; i < 31; ++i)
            {
                list.AddStart(0);
            }

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.AreEqual(31, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddEnd_AList2()
        {
            AList2 list = new AList2();
            for (int i = 0; i < 16; ++i)
            {
                list.AddEnd(0);
            }

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.AreEqual(16, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddEnd_Upscale_AList2()
        {
            AList2 list = new AList2();
            for (int i = 0; i < 31; ++i)
            {
                list.AddEnd(0);
            }

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.AreEqual(31, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddPos_AList2()
        {
            AList2 list = new AList2();
            list.Init(new int[] { 1, 1 });
            for (int i = 0; i < 16 - 2; ++i)
            {
                list.AddPos(1, 0);
            }

            int[] act = list.ToArray();
            int[] exp = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

            Assert.AreEqual(16, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddPos_Upscale_AList2()
        {
            AList2 list = new AList2();
            list.Init(new int[] { 1, 1 });
            for (int i = 0; i < 31 - 2; ++i)
            {
                list.AddPos(1, 0);
            }

            int[] act = list.ToArray();
            int[] exp = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

            Assert.AreEqual(31, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Specific tests for AListR
        [TestMethod]
        public void ToString_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 6 });
            for (int i = 5; i >= 0; i--)
            {
                list.AddStart(i);
            }
            string act = list.ToString();
            string exp = "0 1 2 3 4 5 6";

            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void Init_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.AreEqual(11, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddStart_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            list.AddStart(0);

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(10, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddEnd_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            list.AddEnd(9);

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(10, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void AddPos_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 0, 1, 2, 4, 5, 6, 7, 8, 9 });
            list.AddPos(3, 3);

            int[] act = list.ToArray();
            int[] exp = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(10, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void DelStart_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 0, 1, 2, 3, 4, 5, 6 });
            int res = 0;
            for (int i = 1; i <= 6; ++i)
            {
                res = list.DelStart();
            }
            int[] act = list.ToArray();

            Assert.AreEqual(5, res);
            CollectionAssert.AreEqual(new int[] { 6 }, act);
        }

        [TestMethod]
        public void DelPos_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 1, 6, 7, 4, 2 });
            int res = list.DelPos(3);
            int[] act = list.ToArray();
            int[] exp = new int[] { 1, 6, 7, 2 };

            Assert.AreEqual(4, res);
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void DelPos_Overlapped_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 1, 6, 7, 4, 2, 1 });
            int res = list.DelPos(3);
            int[] act = list.ToArray();
            int[] exp = new int[] { 1, 6, 7, 2, 1 };

            Assert.AreEqual(4, res);
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        public void IndMin_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 6 });
            for (int i = 5; i >= 0; i--)
            {
                list.AddStart(i);
            }
            int act = list.IndMin();

            Assert.AreEqual(0, act);
        }

        [TestMethod]
        public void IndMax_AListR()
        {
            AListR list = new AListR();
            list.Init(new int[] { 6 });
            for (int i = 5; i >= 0; i--)
            {
                list.AddStart(i);
            }
            int act = list.IndMax();

            Assert.AreEqual(6, act);
        }
        #endregion

    }
}
