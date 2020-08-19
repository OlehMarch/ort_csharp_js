using NUnit.Framework;
using System;
using List;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestList
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(List.AList1))]
    [TestFixture(typeof(AList2))]
   [TestFixture(typeof(AListR))]
    [TestFixture(typeof(LList1))]
    [TestFixture(typeof(LList2))]
 //   [TestFixture(typeof(LListR))]

    public class TestListMetodsNUnit<TList> where TList : IList, new()
    {
        IList lst = new TList();

        [SetUp]
        public void Clear_al()
        {
            lst.Clear();
        }
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 10 }, 1)]
        [TestCase(new int[] { 10, 2 }, 2)]
        [TestCase(new int[] { 10, 2, 30, 4, 0 }, 5)]
        public void TestInit(int[] ar, int res)
        {
            lst.Init(ar);
            int act = lst.Size();
            Assert.AreEqual(res, act);
        }
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 10 }, 1)]
        [TestCase(new int[] { 10, 2 }, 2)]
        [TestCase(new int[] { 10, 2, 30, 4, 0 }, 5)]
        public void TestSize(int[] ar, int res)
        {
            lst.Init(ar);
            int act = lst.Size();
            Assert.AreEqual(res, act);
        }
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { })]
        [TestCase(new int[] { 10, 2 }, new int[] { })]
        [TestCase(new int[] { 10, 2, 30, 4, 0 }, new int[] { })]
        public void TestClear(int[] ar, int[] res)
        {
            lst.Init(ar);
            lst.Clear();
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(res, act);
        }
        [TestCase(new int[] { }, "")]
        [TestCase(new int[] { 10 }, "10")]
        [TestCase(new int[] { 10, 2 }, "10 2")]
        [TestCase(new int[] { 5, 15, 4, 0, 0, -3, -10 }, "5 15 4 0 0 -3 -10")]
        public void TestToString(int[] ar, String exp)
        {
            lst.Init(ar);
            String act = lst.ToString();
            Assert.AreEqual(exp, act);
        }
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { 10 })]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 2 })]
        [TestCase(new int[] { 5, 15, 4, 0, 0, -3, -10 }, new int[] { 5, 15, 4, 0, 0, -3, -10 })]
        public void TesTToArray(int[] ar, int[] exp)
        {
            lst.Init(ar);
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(new int[] { }, new int[] { 9 }, 9, 1)]
        [TestCase(new int[] { 10 }, new int[] { 9, 10 }, 9, 2)]
        [TestCase(new int[] { 10, 2 }, new int[] { 9, 10, 2 }, 9, 3)]
        [TestCase(new int[] { 5, 15, 4, 0, 0, -3, -10 }, new int[] { 9, 5, 15, 4, 0, 0, -3, -10 }, 9, 8)]
        public void TestAddStart(int[] ar, int[] exp, int val, int expSize)
        {
            lst.Init(ar);
            lst.AddStart(val);
            int[] act = lst.ToArray();
            int actSize = lst.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(new int[] { }, new int[] { 9 }, 9, 1)]
        [TestCase(new int[] { 10 }, new int[] { 10, 9 }, 9, 2)]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 2, 9 }, 9, 3)]
        [TestCase(new int[] { 5, 15, 4, 0, 0, -3, -10 }, new int[] { 5, 15, 4, 0, 0, -3, -10, 9 }, 9, 8)]
        public void TestAddEnd(int[] ar, int[] exp, int val, int expSize)
        {
            lst.Init(ar);
            lst.AddEnd(val);
            int[] act = lst.ToArray();
            int actSize = lst.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase()]
        public void TestAddPos_ex()
        {
            Assert.That(() => lst.AddPos(22, 9), Throws.TypeOf<IndexOutOfRangeException>());
        }
        [TestCase(new int[] { }, new int[] { 9 }, 0, 9, 1)]
        [TestCase(new int[] { 10 }, new int[] { 10, 9 }, 1, 9, 2)]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 9, 2 }, 1, 9, 3)]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 10, 20, 30, 9, 40, 50, 60, 70 }, 3, 9, 8)]
        public void TestAddPos(int[] ar, int[] exp, int pos, int val, int expSize)
        {
            lst.Init(ar);
            lst.AddPos(pos, val);
            int[] act = lst.ToArray();
            int actSize = lst.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase()]
        public void TestDelStart_ex()
        {
            Assert.That(() => lst.DelStart(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 10 }, new int[] { }, 10, 0)]
        [TestCase(new int[] { 10, 2 }, new int[] { 2 }, 10, 1)]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 20, 30, 40, 50, 60, 70 }, 10, 6)]
        public void TestDelStart(int[] ar, int[] exp, int expVal, int expSize)
        {
            lst.Init(ar);
            int actVal = lst.DelStart();
            int[] act = lst.ToArray();
            int actSize = lst.Size();
            Assert.AreEqual(expSize, actSize);
            Assert.AreEqual(expVal, actVal);
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(null)]
        public void TestDelEnd_ex(int[] ini)
        {
            lst.Init(ini);
            Assert.That(() => lst.DelEnd(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 1 }, new int[] { }, 1, 0)]
        [TestCase(new int[] { 2, 1 }, new int[] { 2 }, 1, 1)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5 }, 6, 6)]
        public void TestDelEnd(int[] ar, int[] exp, int expVal, int expSize)
        {
            lst.Init(ar);
            int actVal = lst.DelEnd();
            int[] act = lst.ToArray();
            int actSize = lst.Size();
            Assert.AreEqual(expSize, actSize);
            Assert.AreEqual(expVal, actVal);
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(null)]
        public void TestDelPos_ex(int[] ini)
        {
            Assert.That(() => lst.DelPos(-1), Throws.TypeOf<IndexOutOfRangeException>());
        }
        [TestCase(new int[] { 1 }, 0, 1, 0, new int[0])]
        [TestCase(new int[] { 2, 1 }, 1, 1, 1, new int[] { 2 })]
        [TestCase(new int[] { 1, 6, 7, 4, 2, 1, 0 }, 3, 4, 6, new int[] { 1, 6, 7, 2, 1, 0 })]
        public void TestDelPos(int[] ar, int pos, int expVal, int expSize, int[] exp)
        {
            lst.Init(ar);
            int actVal = lst.DelPos(pos);
            int[] act = lst.ToArray();
            int actSize = lst.Size();
            Assert.AreEqual(expVal, actVal);
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(null)]
        public void TestSet_ex(int[] ini)
        {
            lst.Init(ini);
            Assert.That(() => lst.Set(22, 0), Throws.TypeOf<IndexOutOfRangeException>());
        }
        [TestCase(new int[] { 10 }, new int[] { 89 }, 0, 89, 1)]
        [TestCase(new int[] { 1, 6 }, new int[] { 1, 89 }, 1, 89, 2)]
        [TestCase(new int[] { 1, 6, 87, 78, 90 }, new int[] { 1, 6, 87, 89, 90 }, 3, 89, 5)]
        public void TestSet(int[] ar, int[] res, int pos, int val, int expSize)
        {
            lst.Init(ar);
            lst.Set(pos, val);
            int[] act = lst.ToArray();
            int actSize = lst.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(act, res);
        }
        [TestCase(null)]
        public void TestGet_ex(int[] ini)
        {
            lst.Init(ini);
            Assert.That(() => lst.Get(22), Throws.TypeOf<IndexOutOfRangeException>());
        }
        [TestCase(new int[] { 10 }, 0, 10)]
        [TestCase(new int[] { 1, 6 }, 1, 6)]
        [TestCase(new int[] { 1, 6, 87, 78, 90 }, 3, 78)]
        public void TestGet(int[] ar, int pos, int exp)
        {
            lst.Init(ar);
            int act = lst.Get(pos);
            Assert.AreEqual(act, exp);
        }
        [TestCase(new int[] { 10 }, 10)]
        [TestCase(new int[] { 10, 2 }, 2)]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, 0)]
        public void TestMin(int[] ar, int res)
        {
            lst.Init(ar);
            int act = lst.Min();
            Assert.AreEqual(act, res);
        }
        [TestCase()]
        public void TestMin_ex()
        {
            Assert.That(() => lst.Min(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase()]
        public void TestMax_ex()
        {
            Assert.That(() => lst.Max(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 10 }, 10)]
        [TestCase(new int[] { 10, 2 }, 10)]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, 55)]
        public void TestMax(int[] ar, int exp)
        {
            lst.Init(ar);
            int act = lst.Max();
            Assert.AreEqual(act, exp);
        }
        [TestCase()]
        public void TestIndMin_ex()
        {
            Assert.That(() => lst.IndMin(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 10 }, 0)]
        [TestCase(new int[] { 10, 2 }, 1)]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, 4)]
        public void TestIndMin(int[] ar, int exp)
        {
            lst.Init(ar);
            int act = lst.IndMin();
            Assert.AreEqual(exp, act);
        }
        [TestCase()]
        public void TestIndMax_ex()
        {
            Assert.That(() => lst.IndMax(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 10 }, 0)]
        [TestCase(new int[] { 10, 2 }, 0)]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, 5)]
        public void TestIndMax(int[] ar, int exp)
        {
            lst.Init(ar);
            int act = lst.IndMax();
            Assert.AreEqual(act, exp);
        }
        [TestCase(new int[] { }, new int[] { }, 0)]
        [TestCase(new int[] { 10 }, new int[] { 10 }, 1)]
        [TestCase(new int[] { 1, 6 }, new int[] { 6, 1 }, 2)]
        [TestCase(new int[] { 1, 6, 87, 78, 90 }, new int[] { 90, 78, 87, 6, 1 }, 5)]
        public void TestReverse(int[] ar, int[] exp, int expSize)
        {
            lst.Init(ar);
            lst.Reverse();
            int actSize = lst.Size();
            int[] act = lst.ToArray();
            Assert.AreEqual(actSize, expSize);
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(new int[] { }, new int[] { }, 0)]
        [TestCase(new int[] { 10 }, new int[] { 10 }, 1)]
        [TestCase(new int[] { 1, 6 }, new int[] { 6, 1 }, 2)]
        [TestCase(new int[] { 1, 6, 87, 78, 90 }, new int[] { 78, 90, 87, 1, 6 }, 5)]
        [TestCase(new int[] { 1, 6, 87, 78, 90, 70 }, new int[] { 78, 90, 70, 1, 6, 87 }, 6)]
        public void TestHalfReverse(int[] ar, int[] exp, int expSize)
        {
            lst.Init(ar);
            lst.HalfReverse();
            int[] act = lst.ToArray();
            int actSize = lst.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
         [TestCase(new int[] { }, new int[] { })]
         [TestCase(new int[] { 10 }, new int[] { 10 })]
         [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 })]
         [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, new int[] { 0, 2, 4, 9, 10, 30, 55 })]
        public void TestSort(int[] ar, int[] exp)
        {
            lst.Init(ar);
            lst.Sort();
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(new int[] { 2 }, new int[] { }, 2, 0, TestName = "DelEndTest1")]
        [TestCase(new int[] { 2, 1 }, new int[] { 2 }, 1, 1, TestName = "DelEndTest2")]
        [TestCase(new int[] { 1, 2, 10, 3, -5, 4, 5, 6 }, new int[] { 1, 2, 10, 3, -5, 4, 5 }, 6, 7, TestName = "DelEndTestMany")]
        public void DelEndTest(int[] array, int[] res, int result, int size)
        {
            lst.Init(array);
            int t = lst.DelEnd();
            foreach (int i in lst.ToArray())
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(t);
            Assert.AreEqual(result, t);
            Assert.AreEqual(res, lst.ToArray());
            Assert.AreEqual(size, lst.Size());
        }
        [TestCase(null, TestName = "DelEndTestNull")]
        [TestCase(new int[] { }, TestName = "DelEndTest0")]
        public void DelEndTest(int[] array)
        {
            lst.Init(array);
            Assert.That(() => lst.DelEnd(), Throws.Exception);
        }
        [TestCase(new int[] { 1, 2, 10, 3, -5, 4, 5, 6 }, new int[] { 5, 6, 5, 4, -5, 3, 10, 2, 1, 5 }, 6, 10, TestName = "FirstComplexCheck")]
        [TestCase(new int[] { 9, 1, 5, 0, 2, 6, 1}, new int[] { 5, 1, 6, 2, 0, 5, 1, 9, 5 }, 7, 9, TestName = "SecondComplexCheck")]
        public void Complex(int[] array, int[] res, int result, int size)
        {
            lst.Init(array);
            lst.AddStart(5);
            lst.AddEnd(5);
            lst.Reverse();
            int act = lst.IndMax();
            int expSize = lst.Size();
            Assert.AreEqual(expSize, size);
            Assert.AreEqual(result, act);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }
        [TestCase(new int[] { 1, 2, 10, 3, -5, 4, 5, 6 }, new int[] { -5, 4, 5, 6, 1, 10 }, 3, 6, TestName = "ThirdComplexCheck")]
        [TestCase(new int[] { 9, 1, 5, 0, 2, 6, 1 }, new int[] { 2, 6, 1, 0, 9}, 5, 5, TestName = "ForthComplexCheck")]
        public void Complex2(int[] array, int[] res, int result, int size)
        {
            lst.Init(array);
            lst.HalfReverse();
            int act = lst.DelEnd();
            lst.DelPos(5);
            int expSize = lst.Size();
            Assert.AreEqual(expSize, size);
            Assert.AreEqual(result, act);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }
        [TestCase(), TestCase]
        public void Complex3()
        {
            lst.AddStart(5);
            lst.AddStart(8);
            lst.AddEnd(2);
            lst.AddStart(5);
            lst.AddStart(8);
            lst.AddEnd(2);
            lst.Reverse();
            lst.DelStart();
            int[] exp = new int[] {2, 5, 8, 5, 8 };
            Assert.AreEqual(5, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }
    }
}
