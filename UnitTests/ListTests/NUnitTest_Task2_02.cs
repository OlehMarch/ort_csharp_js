using System;
using Task2_01;
using NUnit;
using NUnit.Framework;


namespace UnitTests
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(AListR))]
    [TestFixture(typeof(LList1))]
    [TestFixture(typeof(LList2))]
    [TestFixture(typeof(LListR))]
    public class NUnitTest_Task2_02<TList> where TList : IList, new()
    {
        IList list = new TList();

        [PreTest]
        private void PreTest()
        {
            list.Clear();
        }

        #region AddStart
        [Test]
        [TestCase(new int[0], 0, 1, "0", TestName = "AddStart 0")]
        [TestCase(new int[] { 1 }, 3, 2, "3 1", TestName = "AddStart 1")]
        [TestCase(new int[] { 1, 2 }, 2, 3, "2 1 2", TestName = "AddStart 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 7, 7, "7 1 2 3 4 5 6", TestName = "AddStart Many")]
        public void NU_AddStart(int[] ini, int val, int size, string exp)
        {
            list.Init(ini);
            list.AddStart(val);
            string act = list.ToString();

            Assert.AreEqual(size, list.Size());
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region AddEnd
        [Test]
        [TestCase(new int[0], 0, 1, "0", TestName = "AddEnd 0")]
        [TestCase(new int[] { 1 }, 3, 2, "1 3", TestName = "AddEnd 1")]
        [TestCase(new int[] { 1, 2 }, 2, 3, "1 2 2", TestName = "AddEnd 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 7, 7, "1 2 3 4 5 6 7", TestName = "AddEnd Many")]
        public void NU_AddEnd(int[] ini, int val, int size, string exp)
        {
            list.Init(ini);
            list.AddEnd(val);
            string act = list.ToString();

            Assert.AreEqual(size, list.Size());
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region AddPos
        [Test]
        [TestCase(new int[0], 1, 1, TestName = "AddPos PosAbove Exc")]
        [TestCase(new int[0], -1, 1, TestName = "AddPos PosBeneath Exc")]
        public void NU_AddPos_Exc(int[] ini, int pos, int val)
        {
            list.Init(ini);
            Assert.That(() => list.AddPos(pos, val), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        [TestCase(new int[0], 0, 1, 1, "1", TestName = "AddPos 0")]
        [TestCase(new int[] { 1 }, 0, 0, 2, "0 1", TestName = "AddPos 1")]
        [TestCase(new int[] { 1, 2 }, 1, 3, 3, "1 3 2", TestName = "AddPos 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 4, 9, 7, "1 2 3 4 9 5 6", TestName = "AddPos Many")]
        public void NU_AddPos(int[] ini, int pos, int val, int size, string exp)
        {
            list.Init(ini);
            list.AddPos(pos, val);
            string act = list.ToString();

            Assert.AreEqual(size, list.Size());
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region DelStart
        [Test]
        [TestCase(new int[0], TestName = "DelStart 0 Exc")]
        public void NU_DelStart_Exc(int[] ini)
        {
            list.Init(ini);
            Assert.That(() => list.DelStart(), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        [TestCase(new int[] { 1 }, new int[0], 1, TestName = "DelStart 1")]
        [TestCase(new int[] { 2, 1 }, new int[] { 1 }, 2, TestName = "DelStart 2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 }, 0, TestName = "DelStart Many")]
        public void NU_DelStart(int[] ini, int[] exp, int delVal)
        {
            list.Init(ini);
            int res = list.DelStart();
            int[] act = list.ToArray();

            Assert.AreEqual(delVal, res);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region DelEnd
        [Test]
        [TestCase(new int[0], TestName = "DelEnd 0 Exc")]
        public void NU_DelEnd_Exc(int[] ini)
        {
            list.Init(ini);
            Assert.That(() => list.DelEnd(), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        [TestCase(new int[] { 1 }, new int[0], 1, TestName = "DelEnd 1")]
        [TestCase(new int[] { 2, 1 }, new int[] { 2 }, 1, TestName = "DelEnd 2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5 }, 6, TestName = "DelEnd Many")]
        public void NU_DelEnd(int[] ini, int[] exp, int delVal)
        {
            list.Init(ini);
            int res = list.DelEnd();
            int[] act = list.ToArray();

            Assert.AreEqual(delVal, res);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region DelPos
        [Test]
        [TestCase(new int[0], 0, TestName = "DelPos 0 Exc")]
        [TestCase(new int[] { 1 }, 1, TestName = "DelPos PosAbove Exc")]
        [TestCase(new int[] { 1 }, -1, TestName = "DelPos PosBeneath Exc")]
        public void NU_DelPos_Exc(int[] ini, int pos)
        {
            list.Init(ini);
            Assert.That(() => list.DelPos(pos), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        [TestCase(new int[] { 1 }, 0, 1, new int[0], TestName = "DelPos 1")]
        [TestCase(new int[] { 2, 1 }, 1, 1, new int[] { 2 }, TestName = "DelPos 2")]
        [TestCase(new int[] { 1, 6, 7, 4, 2, 1, 0, 1 }, 6, 0, new int[] { 1, 6, 7, 4, 2, 1, 1}, TestName = "DelPos Many")]
        public void NU_DelPos(int[] ini, int pos, int delVal, int[] exp)
        {
            list.Init(ini);
            int res = list.DelPos(pos);
            int[] act = list.ToArray();

            Assert.AreEqual(delVal, res);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Set
        [Test]
        [TestCase(new int[] { }, 0, 10, TestName = "Set 0 Exc")]
        [TestCase(new int[] { 0 }, 1, 10, TestName = "Set PosAbove Exc")]
        [TestCase(new int[] { 0 }, -1, 10, TestName = "Set PosBeneath Exc")]
        public void NU_Set_Exc(int[] ini, int pos, int val)
        {
            list.Init(ini);
            Assert.That(() => list.Set(pos, val), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        [TestCase(new int[] { 0 }, 0, 10, "10", TestName = "Set 1")]
        [TestCase(new int[] { 0, 1 }, 1, 8, "0 8", TestName = "Set 2")]
        [TestCase(new int[] { 0, 2, 3, 4, 5, 6, 7 }, 5, 10, "0 2 3 4 5 10 7", TestName = "Set Many")]
        public void NU_Set(int[] ini, int pos, int val, string exp)
        {
            list.Init(ini);
            list.Set(pos, val);
            string act = list.ToString();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Get
        [Test]
        [TestCase(new int[] { }, 0, TestName = "Get 0 Exc")]
        [TestCase(new int[] { 0 }, 1, TestName = "Get PosAbove Exc")]
        [TestCase(new int[] { 0 }, -1, TestName = "Get PosBeneath Exc")]
        public void NU_Get_Exc(int[] ini, int pos)
        {
            list.Init(ini);
            Assert.That(() => list.Get(pos), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        [TestCase(new int[] { 0 }, 0, 0, "0", TestName = "Get 1")]
        [TestCase(new int[] { 0, 1 }, 1, 1, "0 1", TestName = "Get 2")]
        [TestCase(new int[] { 0, 2, 3, 4, 5, 6, 7 }, 6, 7, "0 2 3 4 5 6 7", TestName = "Get Many")]
        public void NU_Get(int[] ini, int pos, int val, string exp)
        {
            list.Init(ini);
            int res = list.Get(pos);
            string act = list.ToString();

            Assert.AreEqual(val, res);
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Reverse
        [Test]
        [TestCase(new int[] { }, new int[] { }, TestName = "Reverse 0")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "Reverse 1")]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 }, TestName = "Reverse 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 }, TestName = "Reverse Many Even")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 7, 6, 5, 4, 3, 2, 1 }, TestName = "Reverse Many Odd")]
        public void NU_Reverse(int[] ini, int[] exp)
        {
            list.Init(ini);
            list.Reverse();
            int[] act = list.ToArray();

            Assert.AreEqual(ini.Length, exp.Length);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region HalfReverse
        [Test]
        [TestCase(new int[] { }, new int[] { }, TestName = "HalfReverse 0")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "HalfReverse 1")]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 }, TestName = "HalfReverse 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 }, TestName = "HalfReverse Many Even")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 5, 6, 7, 4, 1, 2, 3 }, TestName = "HalfReverse Many Odd")]
        public void NU_HalfReverse(int[] ini, int[] exp)
        {
            list.Init(ini);
            list.HalfReverse();
            int[] act = list.ToArray();

            Assert.AreEqual(ini.Length, exp.Length);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Sort
        [Test]
        [TestCase(new int[] { }, new int[] { }, TestName = "Sort 0")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "Sort 1")]
        [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 }, TestName = "Sort 2")]
        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5, 6 }, TestName = "Sort Many Even")]
        [TestCase(new int[] { 7, 6, 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, TestName = "Sort Many Odd")]
        public void NU_Sort(int[] ini, int[] exp)
        {
            list.Init(ini);
            list.Sort();
            int[] act = list.ToArray();

            Assert.AreEqual(exp.Length, act.Length);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region IndMin
        [Test]
        [TestCase(new int[0], TestName = "IndMin 0 Exc")]
        public void NU_IndMin_Exc(int[] ini)
        {
            list.Init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => list.IndMin());
        }

        [Test]
        [TestCase(new int[] { 1 }, 0, TestName = "IndMin 1")]
        [TestCase(new int[] { 1, 0 }, 1, TestName = "IndMin 2")]
        [TestCase(new int[] { 6, 5, 4, 3, 2, 1, 0 }, 6, TestName = "IndMin Many")]
        public void NU_IndMin(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.IndMin();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region IndMax
        [Test]
        [TestCase(new int[0], TestName = "IndMax 0 Exc")]
        public void NU_IndMax_Exc(int[] ini)
        {
            list.Init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => list.IndMax());
        }

        [Test]
        [TestCase(new int[] { 1 }, 0, TestName = "IndMax 1")]
        [TestCase(new int[] { 0, 1 }, 1, TestName = "IndMax 2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 6, TestName = "IndMax Many")]
        public void NU_IndMax(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.IndMax();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Min
        [Test]
        [TestCase(new int[0], TestName = "Min 0 Exc")]
        public void NU_Min_Exc(int[] ini)
        {
            list.Init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => list.Min());
        }

        [Test]
        [TestCase(new int[] { 1 }, 1, TestName = "Min 1")]
        [TestCase(new int[] { 1, 0 }, 0, TestName = "Min 2")]
        [TestCase(new int[] { 6, 5, 4, 3, 2, 1, 0 }, 0, TestName = "Min Many")]
        public void NU_Min(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.Min();

            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Max
        [Test]
        [TestCase(new int[0], TestName = "Max 0 Exc")]
        public void NU_Max_Exc(int[] ini)
        {
            list.Init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => list.Max());
        }

        [Test]
        [TestCase(new int[] { 1 }, 1, TestName = "Max 1")]
        [TestCase(new int[] { 0, 1 }, 1, TestName = "Max 2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 6, TestName = "Max Many")]
        public void NU_Max(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.Max();

            Assert.AreEqual(exp, act);
        }
        #endregion

    }
}
