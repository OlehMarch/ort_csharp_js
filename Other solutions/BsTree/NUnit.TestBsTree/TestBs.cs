using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BsTree;

namespace NUnit.TestBsTree
{
   // [TestFixture(typeof(BsTree.BsTree))]
    [TestFixture(typeof(BsTreeAvl))]
  //  [TestFixture(typeof(BsTreeRedBlack))]

    public class TestListMetodsNUnit<TList> where TList : IBsTree, new()
    {
        IBsTree tree = new TList();
        
        #region ToArrayTest
        [TestCase(null, new int[] { }, TestName = "TestToArrayNull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "TestToArray0")]
        [TestCase(new int[] { 10 }, new int[] { 10 }, TestName = "TestToArray1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 2, 10 }, TestName = "TestToArray2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, TestName = "TestToArrayMany1")]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 }, TestName = "TestToArrayMany2")]
        [TestCase(new int[] { 5, 3, 4, 1, 2 }, new int[] { 1, 2, 3, 4, 5 }, TestName = "TestToArrayMany3")]
        [TestCase(new int[] { 50, 30, 10, 4, 2 }, new int[] { 2, 4, 10, 30, 50 }, TestName = "TestToArrayMany4")]
        public void TestToArray(int[] ar, int[] exp)
        {
            tree.Init(ar);
            int[] tmp = tree.ToArray();
            CollectionAssert.AreEqual(exp, tmp);
        }
        #endregion

        #region InitTest
        [TestCase(null, new int[] { }, TestName = "InitTestNull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "InitTest0")]
        [TestCase(new int[] { 3 }, new int[] { 3 }, TestName = "InitTest1")]
        [TestCase(new int[] { 3, 5 }, new int[] { 3, 5 }, TestName = "InitTest2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, TestName = "InitTestMany")]
        public void InitTest(int[] array, int[] result)
        {
            tree.Init(array);
            Assert.AreEqual(result, tree.ToArray());
        }
        #endregion

        #region SizeTest
        [TestCase(null, 0, TestName = "SizeTest0")]
        [TestCase(new int[] { }, 0, TestName = "SizeTest0")]
        [TestCase(new int[] { 3 }, 1, TestName = "SizeTest1")]
        [TestCase(new int[] { 3, 5 }, 2, TestName = "SizeTest0")]
        [TestCase(new int[] { -1, 0, 3, 4, 5, 7, 8 }, 7, TestName = "SizeTestMany")]
        public void SizeTest(int[] array, int result)
        {
            tree.Init(array);
            Assert.AreEqual(result, tree.Size());
        }
        #endregion

        #region Reverse
        [TestCase(new int[] { }, new int[] { }, TestName = "ReverseTest0")]
        [TestCase(new int[] { 10 }, new int[] { 10 }, TestName = "ReverseTest1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 2 }, TestName = "ReverseTest2")]
        [TestCase(new int[] { 10, 2, 3 }, new int[] { 10, 3, 2 }, TestName = "ReverseTest3")]
        [TestCase(new int[] { 10, 2, 30, 4, 50 }, new int[] { 50, 30, 10, 4, 2 }, TestName = "ReverseTest5")]
        [TestCase(new int[] { 5, 10, 2, 30, 4, 50 }, new int[] { 50, 30, 10, 5, 4, 2 }, TestName = "ReverseTest6")]
        public void TestReverse(int[] ar, int[] result)
        {
            tree.Init(ar);
            tree.Reverse();
            int[] arr = tree.ToArray();
            CollectionAssert.AreEqual(result, arr);
        }
        #endregion
        
        #region ToStringTest
        [TestCase(new int[] { }, "", TestName = "ToStringTest0")]
        [TestCase(new int[] { 10 }, "10, ", TestName = "ToStringTest1")]
        [TestCase(new int[] { 10, 2 }, "2, 10, ", TestName = "ToStringTest2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, "1, 2, 3, 4, 5, ", TestName = "ToStringTestMany")]
        public void ToStringTest(int[] ar, String exp)
        {
            tree.Init(ar);
            Assert.AreEqual(exp, tree.ToString());
        }
        #endregion

        #region LeavesTest
        [TestCase(null, 0, TestName = "LeavesTestNull")]
        [TestCase(new int[] { }, 0, TestName = "LeavesTest0")]
        [TestCase(new int[] { 10 }, 1, TestName = "LeavesTest1")]
        [TestCase(new int[] { 10, 2 }, 1, TestName = "LeavesTest2")]
        [TestCase(new int[] { 50, 25, 11, 90, 30 }, 3, TestName = "LeavesTestMany")]
        public void TestLeaves(int[] ar, int exp)
        {
            tree.Init(ar);
            int act = tree.Leaves();
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region NodesTest
        [TestCase(null, 0, TestName = "NodesTestNull")]
        [TestCase(new int[] { }, 0, TestName = "NodesTest0")]
        [TestCase(new int[] { 10 }, 0, TestName = "NodesTest1")]
        [TestCase(new int[] { 10, 2 }, 1, TestName = "NodesTest2")]
        [TestCase(new int[] { 10, 2, 30, 4, 50 }, 3, TestName = "NodesTest3")]
        public void TestNodes(int[] ar, int expNodes)
        {
            tree.Init(ar);
            int actNodes = tree.Nodes();
            Assert.AreEqual(expNodes, actNodes);
        }
        #endregion

        #region WidthTest
        [TestCase(null, 0, TestName = "WidthTestNull")]
        [TestCase(new int[] { }, 0, TestName = "WidthTest0")]
        [TestCase(new int[] { 10 }, 1, TestName = "WidthTest1")]
        [TestCase(new int[] { 10, 2 }, 1, TestName = "WidthTest2")]
        [TestCase(new int[] { 10, 2, 30, 4, 50 }, 2, TestName = "WidthTest3")]
        [TestCase(new int[] { 50, 25, 90, 4, 30, 80 }, 3, TestName = "WidthTest4")]
        [TestCase(new int[] { 50, 25, 90, 4, 30, 80, 110 }, 4, TestName = "WidthTest5")]
        public void TestWidth(int[] ar, int exp)
        {
            tree.Init(ar);
            int act = tree.Width();
            Assert.AreEqual(exp, act);
        }
        #endregion
        #region DelTest0
        [TestCase(null, new int[] { }, 0, 0, TestName = "ExceptionTestDelNull")]
        [TestCase(new int[] { }, new int[] { }, 0, 0, TestName = "ExceptionTestDel0")]
        [TestCase(new int[] { 10 }, new int[] { }, 10, 0, TestName = "DelTest1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 10 }, 2, 1, TestName = "DelTest2")]
        [TestCase(new int[] { 10, 2, 50 }, new int[] { 10, 50 }, 2, 2, TestName = "DelTest3")]
        [TestCase(new int[] { 10, 2, 30, 4 }, new int[] { 4, 10, 30 }, 2, 3, TestName = "DelTest4")]
        [TestCase(new int[] { 2, 4, 30, 50 }, new int[] { 2, 4, 50 }, 30, 3, TestName = "DelTest5")]
        [TestCase(new int[] { 2, 4, 30, 50, 60, 70, 71, 72, 73, 74, 75 }, new int[] { 2, 4, 30, 50, 60, 71, 72, 73, 74, 75 }, 70, 10, TestName = "DelTest6")]
        [TestCase(new int[] { 72, 73, 74, 75, 2, 4, 30, 50, 60, 70, 71 }, new int[] { 4, 30, 50, 60, 70, 71, 72, 73, 74, 75 }, 2, 10, TestName = "DelTest7")]
        public void TestDel(int[] ar, int[] exp, int pos, int expSize)
        {
            tree.Init(ar);
            tree.Del(pos);
            int[] act = tree.ToArray();
            int actSize = tree.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion
        #region Height
        [TestCase(new int[] { }, 0, TestName = "Height0")]
        [TestCase(new int[] { 10 }, 1, TestName = "Height1")]
        [TestCase(new int[] { 10, 2 }, 2, TestName = "Height2")]
        [TestCase(new int[] { 10, 2, 11 }, 2, TestName = "Height3")]
        [TestCase(new int[] { 50, 25, 11, 30, 90, 80, 110 }, 3, TestName = "HeightMany")]
        public void TestHeight(int[] ar, int exp)
        {
            tree.Init(ar);
            Assert.AreEqual(exp, tree.Height());
        }
        #endregion
        #region AddTest
        [TestCase(null, new int[] { 2 }, 2, TestName = "AddTestNull")]
        [TestCase(new int[] { }, new int[] { 2 }, 2, TestName = "AddTest0")]
        [TestCase(new int[] { 2 }, new int[] { 1, 2 }, 1, TestName = "AddTest1")]
        [TestCase(new int[] { 2, 3 }, new int[] { 1, 2, 3 }, 1, TestName = "AddTest2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, TestName = "AddTestMany")]
        public void AddTest(int[] array, int[] result, int val)
        {
            tree.Init(array);
            tree.Add(val);
            int[] arr = tree.ToArray();
            CollectionAssert.AreEqual(result, arr);

        }
        #endregion
    }
}
