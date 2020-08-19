using System;
using Task2_01;
using NUnit;
using NUnit.Framework;
using System.Reflection;

namespace UnitTests
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(AListR))]
    [TestFixture(typeof(LList1))]
    [TestFixture(typeof(LList2))]
    [TestFixture(typeof(LListR))]
    public class NUnitComplexTest_Task_3_03<TList> where TList : IList, new()
    {
        IList list = new TList();

        [PreTest]
        private void PreTest()
        {
            list.Clear();
        }

        [Test]
        public void TestComplex1()
        {
            int[] incomeArray = new int[5] { 1, 2, 3, 4, 5 };

            list.Init(incomeArray);
            list.AddStart(10);
            list.AddStart(15);
            list.AddStart(6);
            list.AddStart(3);
            list.AddPos(5, 3);
            list.Reverse();

            int[] actual = list.ToArray();
            int[] expected = new int[10] { 5, 4, 3, 2, 3, 1, 10, 15, 6, 3 };

            ReflectionTest("5 4 3 2 3 1 10 15 6 3");

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void TestComplex2()
        {
            int[] incomeArray = new int[5] { 1, 2, 3, 4, 5 };

            list.Init(incomeArray);
            list.AddEnd(10);
            list.AddEnd(15);
            list.AddStart(6);
            list.AddStart(3);
            list.AddEnd(5);
            list.Reverse();

            int[] actual = list.ToArray();
            int[] expected = new int[10] { 5, 15, 10, 5, 4, 3, 2, 1, 6, 3 };
            
            ReflectionTest("5 15 10 5 4 3 2 1 6 3");

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void TestComplex3()
        {
            int[] incomeArray = new int[5] { 1, 2, 3, 4, 5 };

            list.Init(incomeArray);
            list.Reverse();
            list.AddStart(10);
            list.AddStart(15);
            list.AddStart(6);
            list.AddStart(3);
            list.DelEnd();
            list.DelPos(1);
            list.AddPos(5, 3);

            int[] actual = list.ToArray();
            int[] expected = new int[8] { 3, 15, 10, 5, 4, 3, 3, 2 };

            ReflectionTest("3 15 10 5 4 3 3 2");


            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void TestComplex4()
        {
            int[] incomeArray = new int[3] { 1, 2, 3 };

            list.Init(incomeArray);
            list.AddStart(10);
            list.AddEnd(15);
            list.AddStart(6);
            list.AddEnd(3);
            list.DelPos(0);
            list.DelPos(0);
            list.DelPos(0);
            list.HalfReverse();

            int[] actual = list.ToArray();
            int[] expected = new int[4] { 15, 3, 2, 3 };

            ReflectionTest("15 3 2 3");

            CollectionAssert.AreEqual(actual, expected);
        }

        private void ReflectionTest(string exp)
        {
            string backAct = "";

            if (Equals(list.GetType(), typeof(LList2)))
            {
                FieldInfo fInfo = list.GetType().GetField("_tail", BindingFlags.NonPublic | BindingFlags.Instance);
                object node = fInfo.GetValue(list);
                PropertyInfo pPrev = node.GetType().GetProperty("Previous");
                PropertyInfo pVal = node.GetType().GetProperty("Value");

                while (node != null)
                {
                    backAct = pVal.GetValue(node) + " " + backAct;
                    pPrev.SetValue(node, pPrev.GetValue(node));
                    node = pPrev.GetValue(node);
                }

                backAct = backAct.TrimEnd();
                Assert.AreEqual(exp, backAct);
            }
            else if (Equals(list.GetType(), typeof(LListR)))
            {
                FieldInfo fInfo = list.GetType().GetField("_root", BindingFlags.NonPublic | BindingFlags.Instance);
                object node = fInfo.GetValue(list);
                PropertyInfo pNext = node.GetType().GetProperty("Next");
                node = pNext.GetValue(node);
                PropertyInfo pPrev = node.GetType().GetProperty("Previous");
                node = pPrev.GetValue(node);
                PropertyInfo pVal = node.GetType().GetProperty("Value");
                
                int size = list.Size();
                for (int i = 0; i < size; i++)
                {
                    backAct = pVal.GetValue(node) + " " + backAct;
                    pPrev.SetValue(node, pPrev.GetValue(node));
                    node = pPrev.GetValue(node);
                }

                backAct = backAct.TrimEnd();
                Assert.AreEqual(exp, backAct);
            }
        }

    }
}
