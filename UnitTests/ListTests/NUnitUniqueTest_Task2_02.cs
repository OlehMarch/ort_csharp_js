using System;
using Task2_01;
using NUnit;
using NUnit.Framework;
using System.Reflection;

namespace UnitTests
{
    [TestFixture]
    public class NUnitUniqueTest_Task2_02
    {

        #region Specific tests for AList1
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 0, 1 }, new int[] { 0, 1 })]
        [TestCase(new int[] { 0, 1, 4, 3, 2, 5, 6, 7, 8 }, new int[] { 0, 1, 4, 3, 2, 5, 6, 7, 8 })]
        public void TestEnumerator_AList1(int[] ini, int[] expected)
        {
            AList1 list = new AList1();
            list.Init(ini);
            int[] actual = new int[ini.Length];
            int iterator = 0;
            foreach (var item in list)
            {
                actual[iterator++] = (int)item;
            }
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 11, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, TestName = "AList1 Init Upscale")]
        public void NU_Init_AList1(int[] ini, int size, int[] exp)
        {
            AList1 list = new AList1();
            list.Init(ini);

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, TestName = "AList1 AddStart Upscale")]
        public void NU_AddStart_AList1(int[] ini, int val, int size, int[] exp)
        {
            AList1 list = new AList1();
            list.Init(ini);
            list.AddStart(val);

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 9, 10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, TestName = "AList1 AddEnd Upscale")]
        public void NU_AddEnd_AList1(int[] ini, int val, int size, int[] exp)
        {
            AList1 list = new AList1();
            list.Init(ini);
            list.AddEnd(val);

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 0, 1, 2, 4, 5, 6, 7, 8, 9 }, 3, 3, 10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, TestName = "AList1 AddPos Upscale")]
        public void NU_AddPos_AList1(int[] ini, int pos, int val, int size, int[] exp)
        {
            AList1 list = new AList1();
            list.Init(ini);
            list.AddPos(pos, val);

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Specific tests for AList2
        [Test]
        [TestCase(
            new int[40] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            40, 
            new int[40] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            TestName = "AList2 Init Upscale"
        )]
        public void NU_Init_AList2(int[] ini, int size, int[] exp)
        {
            AList2 list = new AList2();
            list.Init(ini);

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(
            0, 
            16, 
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            TestName = "AList2 AddStart Centering"
        )]
        [TestCase(
            1,
            31,
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            TestName = "AList2 AddStart Upscale"
        )]
        public void NU_AddStart_AList2(int val, int size, int[] exp)
        {
            AList2 list = new AList2();
            for (int i = 0; i < size; ++i)
            {
                list.AddStart(val);
            }

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(
            0,
            16,
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            TestName = "AList2 AddEnd Centering"
        )]
        [TestCase(
            1,
            31,
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            TestName = "AList2 AddEnd Upscale"
        )]
        public void NU_AddEnd_AList2(int val, int size, int[] exp)
        {
            AList2 list = new AList2();
            for (int i = 0; i < size; ++i)
            {
                list.AddEnd(val);
            }

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(
            0,
            16,
            new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            TestName = "AList2 AddPos Centering"
        )]
        [TestCase(
            0,
            31,
            new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            TestName = "AList2 AddPos Upscale"
        )]
        public void NU_AddPos_AList2(int val, int size, int[] exp)
        {
            AList2 list = new AList2();
            list.Init(new int[] { 1, 1 });
            for (int i = 0; i < size - 2; ++i)
            {
                list.AddPos(1, val);
            }

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Specific tests for AListR
        [TestCase(new int[] { 6 }, "0 1 2 3 4 5 6", TestName = "AListR ToString Overlapped")]
        public void NU_ToString_AListR(int[] ini, string exp)
        {
            AListR list = new AListR();
            list.Init(ini);
            for (int i = 5; i >= 0; i--)
            {
                list.AddStart(i);
            }
            string act = list.ToString();

            Assert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 11, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, TestName = "AListR Init Upscale")]
        public void NU_Init_AListR(int[] ini, int size, int[] exp)
        {
            AListR list = new AListR();
            list.Init(ini);

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, TestName = "AListR AddStart Upscale")]
        public void NU_AddStart_AListR(int[] ini, int val, int size, int[] exp)
        {
            AListR list = new AListR();
            list.Init(ini);
            list.AddStart(val);

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 9, 10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, TestName = "AListR AddEnd Upscale")]
        public void NU_AddEnd_AListR(int[] ini, int val, int size, int[] exp)
        {
            AListR list = new AListR();
            list.Init(ini);
            list.AddEnd(val);

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(new int[] { 0, 1, 2, 4, 5, 6, 7, 8, 9 }, 3, 3, 10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, TestName = "AListR AddPos Upscale")]
        public void NU_AddPos_AListR(int[] ini, int pos, int val, int size, int[] exp)
        {
            AListR list = new AListR();
            list.Init(ini);
            list.AddPos(pos, val);

            int[] act = list.ToArray();

            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 6 }, 5, TestName = "AListR DelStart Overlapped")]
        public void NU_DelStart_AListR(int[] ini, int[] exp, int delVal)
        {
            AListR list = new AListR();
            list.Init(ini);
            int res = 0;
            for (int i = 1; i <= 6; ++i)
            {
                res = list.DelStart();
            }
            int[] act = list.ToArray();

            Assert.AreEqual(delVal, res);
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(new int[] { 1, 6, 7, 4, 2 }, 3, 4, new int[] { 1, 6, 7, 2 }, TestName = "AListR DelPos Edge")]
        [TestCase(new int[] { 1, 6, 7, 4, 2, 1 }, 3, 4, new int[] { 1, 6, 7, 2, 1 }, TestName = "AListR DelPos Overlapped")]
        public void NU_DelPos_AListR(int[] ini, int pos, int delVal, int[] exp)
        {
            AListR list = new AListR();
            list.Init(ini);
            int res = list.DelPos(pos);
            int[] act = list.ToArray();

            Assert.AreEqual(delVal, res);
            CollectionAssert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 6 }, 0, TestName = "AListR IndMin Overlapped")]
        public void NU_IndMin_AListR(int[] ini, int exp)
        {
            AListR list = new AListR();
            list.Init(ini);
            for (int i = 5; i >= 0; i--)
            {
                list.AddStart(i);
            }
            int act = list.IndMin();

            Assert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 6 }, 6, TestName = "AListR IndMax Overlapped")]
        public void NU_IndMax_AListR(int[] ini, int exp)
        {
            AListR list = new AListR();
            list.Init(ini);
            for (int i = 5; i >= 0; i--)
            {
                list.AddStart(i);
            }
            int act = list.IndMax();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Specific tests for LList1
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 0, 1 }, new int[] { 0, 1 })]
        [TestCase(new int[] { 0, 1, 4, 3, 2, 5, 6, 7, 8 }, new int[] { 0, 1, 4, 3, 2, 5, 6, 7, 8 })]
        public void TestEnumerator_LList1(int[] ini, int[] expected)
        {
            LList1 list = new LList1();
            list.Init(ini);
            int[] actual = new int[ini.Length];
            int iterator = 0;
            foreach (var item in list)
            {
                actual[iterator++] = (int)item;
            }
            CollectionAssert.AreEqual(actual, expected);
        }
        #endregion

    }
}
