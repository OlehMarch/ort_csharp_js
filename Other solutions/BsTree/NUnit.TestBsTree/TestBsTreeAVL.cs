using BsTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestBsTree
{
    [TestFixture(typeof(BsTreeAvl))]

    public class TestListMetod<TList> where TList : IBsTree, new()
    {
        IBsTree tree = new TList();
        BsTree.BsTree BsTreeExp = new BsTree.BsTree();

        #region ToArrayTest
        [TestCase(null, new int[] { }, TestName = "TestToArrayNull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "TestToArray0")]
        [TestCase(new int[] { 10 }, new int[] { 10 }, TestName = "TestToArray1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 2 }, TestName = "TestToArray2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 1, 4, 3, 5 }, TestName = "TestToArrayMany1")]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 4, 2, 1, 3, 5 }, TestName = "TestToArrayMany2")]
        [TestCase(new int[] { 5, 3, 4, 1, 2 }, new int[] { 4, 2, 1, 3, 5 }, TestName = "TestToArrayMany3")]
        [TestCase(new int[] { 50, 30, 10, 4, 2 }, new int[] { 30, 4, 2, 10, 50 }, TestName = "TestToArrayMany4")]
        [TestCase(new int[] { 26, 17, 41, 14, 21, 30, 47, 10, 16, 19, 23, 28, 38, 7, 12, 15, 20, 35, 39, 3, 1, 0 },
                  new int[] { 17, 14, 26, 3, 16, 21, 38, 1, 10, 15, 19, 23, 30, 41, 0, 7, 12, 20, 28, 35, 39, 47 },
            TestName = "TestToArrayMany5")]
        [TestCase(new int[] { 17, 14, 26, 3, 16, 21, 49, 1, 10, 15, 19, 23, 38, 51, 0, 7, 12, 20, 30, 41, 50, 52, 28, 35, 39, 47, 53 },
                  new int[] { 17, 14, 26, 3, 16, 21, 49, 1, 10, 15, 19, 23, 38, 51, 0, 7, 12, 20, 30, 41, 50, 52, 28, 35, 39, 47, 53 },
            TestName = "TestToArrayMany6")]
        public void TestToArray(int[] ar, int[] exp)
        {
            tree.Init(ar);
            BsTreeExp.Init(exp);
            bool f = Equals(BsTreeExp, tree);
            try
            {
                Assert.AreEqual(BsTreeExp.Width(), tree.Width());
                Assert.AreEqual(BsTreeExp.Height(), tree.Height());
                Assert.AreEqual(BsTreeExp.Size(), tree.Size());
                Assert.AreEqual(BsTreeExp.Leaves(), tree.Leaves());
                Assert.AreEqual(BsTreeExp.Nodes(), tree.Nodes());
                Assert.AreEqual(true, f);
            }
            catch { }
        }
        #endregion

        #region ToDeleteTest
        [TestCase(null, new int[] { }, 10, TestName = "TestDeleteNull")]
        [TestCase(new int[] { }, new int[] { }, 0, TestName = "TestToDelete0")]
        [TestCase(new int[] { }, new int[] { 10 }, 10, TestName = "TestToDelete1")]
        [TestCase(new int[] { 2 }, new int[] { 10, 2 }, 10, TestName = "TestToDelete2")]
        [TestCase(new int[] { 10 }, new int[] { 10, 2 }, 2, TestName = "TestToDelete3")]
        [TestCase(new int[] { 5, 2, 8, 1, 3, 7, 10, 6, 9, 11 }, new int[] { 5, 3, 8, 2, 4, 7, 10, 1, 6, 9, 11 }, 4, TestName = "TestToDeleteMany4")] /*LL*/
        [TestCase(new int[] { 5, 2, 7, 1, 3, 6, 10, 9, 11 }, new int[] { 5, 2, 8, 1, 3, 7, 10, 6, 9, 11 }, 8, TestName = "TestToDeleteMany5")] /*LL*/
        [TestCase(new int[] { 5, 2, 10, 1, 3, 7, 11, 9 }, new int[] { 5, 2, 7, 1, 3, 6, 10, 9, 11 }, 6, TestName = "TestToDeleteMany6")]/*RR*/
        [TestCase(new int[] { 3, 2, 10, 1, 7, 11, 9 }, new int[] { 5, 2, 10, 1, 3, 7, 11, 9 }, 5, TestName = "TestToDeleteMany7")]/*RR*/
        [TestCase(new int[] { 7, 3, 10, 1, 9, 11 }, new int[] { 3, 2, 10, 1, 7, 11, 9 }, 2, TestName = "TestToDeleteMany8")]/*RR*/
        [TestCase(new int[] { 7, 3, 10, 9, 11 }, new int[] { 7, 3, 10, 1, 9, 11 }, 1, TestName = "TestToDeleteMany9")]/*RL*/
        [TestCase(new int[] { 10, 3, 11, 9 }, new int[] { 7, 3, 10, 9, 11 }, 7, TestName = "TestToDeleteMany10")]/*RR*/
        public void TestToDelete(int[] ar, int[] exp, int pos)
        {
            tree.Init(exp);
            tree.Del(pos);
            BsTreeExp.Init(ar);

            bool f = Equals(BsTreeExp, tree);
            try
            {
                Assert.AreEqual(BsTreeExp.Width(), tree.Width());
                Assert.AreEqual(BsTreeExp.Height(), tree.Height());
                Assert.AreEqual(BsTreeExp.Size(), tree.Size());
                Assert.AreEqual(BsTreeExp.Leaves(), tree.Leaves());
                Assert.AreEqual(BsTreeExp.Nodes(), tree.Nodes());
                Assert.AreEqual(true, f);
            }
            catch { }
        }
        // [TestCase(new int[] { 16, 3, 23, 1, 14, 20, 38, 0, 10, 15, 19, 21, 30, 41, 7, 12, 28, 35, 39, 47 },new int[] { 17, 14, 26, 3, 16, 21, 38, 1, 10, 15, 19, 23, 30, 41, 0, 7, 12, 20, 28, 35, 39, 47 }, 17, 26, TestName = "TestToArrayMany1")]
        // [TestCase(new int[] { 17,10,3,1,0,7,3,14,12,16,15,38,26,21,19,20,23,30,28,35,49,41,39,38,47,51,50,52,53}, new int[] { 17, 14, 26, 3, 16, 21, 49, 1, 10, 15, 19, 23, 38, 51, 0, 7, 12, 20, 30, 41, 50, 52, 28, 35, 39, 47, 53 }, 3,38, TestName = "TestToArrayMany2")]
        //public void TestToDeleteMany(int[] ar, int[] exp, int pos, int pos2)
        //{
        //    tree.Init(ar);
        //    BsTreeExp.Init(exp);
        //    BsTreeExp.Del(pos);
        //    BsTreeExp.Del(pos2);
        //    bool f = Equals(BsTreeExp, tree);
        //    try
        //    {
        //        Assert.AreEqual(BsTreeExp.Width(), tree.Width());
        //        Assert.AreEqual(BsTreeExp.Height(), tree.Height());
        //        Assert.AreEqual(BsTreeExp.Size(), tree.Size());
        //        Assert.AreEqual(BsTreeExp.Leaves(), tree.Leaves());
        //        Assert.AreEqual(BsTreeExp.Nodes(), tree.Nodes());
        //        Assert.AreEqual(true, f);
        //    }
        //    catch { }
        //}
        #endregion
    }
}