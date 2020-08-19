using System;
using NUnit;
using NUnit.Framework;
using Task2_01;

namespace UnitTests
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(AListR))]
    [TestFixture(typeof(LList1))]
    [TestFixture(typeof(LList2))]
    [TestFixture(typeof(LListR))]
    class NUnitPreTest_Task2_02<TList> where TList : IList, new()
    {
        IList list = new TList();

        [PreTest]
        private void PreTest()
        {
            list.Clear();
        }

        #region Init
        [Test]
        [TestCase(null, TestName = "Init Null Exc")]
        public void NU_Init_Exc(int[] ini)
        {
            Assert.That(() => list.Init(ini), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        [TestCase(new int[0], new int[0], TestName = "Init 0")]
        [TestCase(new int[] { 0 }, new int[] { 0 }, TestName = "Init 1")]
        [TestCase(new int[] { 0, 1 }, new int[] { 0, 1 }, TestName = "Init 2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5, 6 }, TestName = "Init Many")]
        public void NU_Init(int[] ini, int[] exp)
        {
            list.Init(ini);
            int[] act = list.ToArray();

            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region ToString
        [Test]
        [TestCase(new int[0], "", TestName = "ToString 0")]
        [TestCase(new int[] { 0 }, "0", TestName = "ToString 1")]
        [TestCase(new int[] { 0, 1 }, "0 1", TestName = "ToString 2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, "0 1 2 3 4 5 6", TestName = "ToString Many")]
        public void NU_ToString(int[] ini, string exp)
        {
            list.Init(ini);
            string act = list.ToString();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region ToArray
        [Test]
        [TestCase(new int[0], new int[0], TestName = "ToArray 0")]
        [TestCase(new int[] { 0 }, new int[] { 0 }, TestName = "ToArray 1")]
        [TestCase(new int[] { 0, 1 }, new int[] { 0, 1 }, TestName = "ToArray 2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5, 6 }, TestName = "ToArray Many")]
        public void NU_ToArray(int[] ini, int[] exp)
        {
            list.Init(ini);
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Size
        [Test]
        [TestCase(new int[0], 0, TestName = "Size 0")]
        [TestCase(new int[] { 0 }, 1, TestName = "Size 1")]
        [TestCase(new int[] { 0, 1 }, 2, TestName = "Size 2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 7, TestName = "Size Many")]
        public void NU_Size(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.Size();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Clear
        [Test]
        [TestCase(new int[0], 0, TestName = "Clear 0")]
        [TestCase(new int[] { 0 }, 0, TestName = "Clear 1")]
        [TestCase(new int[] { 0, 1 }, 0, TestName = "Clear 2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 0, TestName = "Clear Many")]
        public void NU_Clear(int[] ini, int exp)
        {
            list.Init(ini);
            list.Clear();
            int act = list.Size();

            Assert.AreEqual(exp, act);
        }
        #endregion
    }
}
