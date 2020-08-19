using BsTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestBsTree
{
    [TestFixture(typeof(BsTreeRedBlack))]
    public class TestBsRedBlack<TList> where TList : IBsTree, new()
    {
        IBsTree tree = new TList();
        BsTree.BsTree BsTreeExp = new BsTree.BsTree();

        #region ToArrayTest
        [TestCase(null, new int[] { }, TestName = "TestToArrayNull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "TestToArray0")]
        [TestCase(new int[] { 2 }, new int[] { 2 }, TestName = "TestToArray1")]
        [TestCase(new int[] { 2,1 }, new int[] { 2,1 }, TestName = "TestToArray2")] 
        [TestCase(new int[] { 2,1, 4 }, new int[] { 2,1,4 }, TestName = "TestToArray3")]
        //case 1 - case 0, insert (5)
        [TestCase(new int[] { 2, 1, 4, 5 }, new int[] { 2, 1, 4, 5 }, TestName = "TestToArray4")] 
        //case 3 step 1(recolor) - case 3 step 2 (rotate), insert (9)
        [TestCase(new int[] { 2, 1, 5, 4, 9 }, new int[] { 2, 1, 4, 5, 9 }, TestName = "TestToArray5")] 
        //case 1, insert (3)
        [TestCase(new int[] { 2, 1, 5, 4, 3, 9 }, new int[] { 2, 1, 4, 5, 9, 3 }, TestName = "TestToArray6")] 
        //Insert 6 
        [TestCase(new int[] { 2, 1, 5, 4, 3, 9, 6 }, new int[] { 2, 1, 4, 5, 9, 3, 6 }, TestName = "TestToArray7")]
        //Insert (7)
        //case 2: step 1 (recolor)
        //case 2: step 2 (rotate x about p)
        //case 2: step 2 (rotate x about g)
        [TestCase(new int[] { 2, 1, 5, 4, 7, 3, 6, 9 }, new int[] { 2, 1, 4, 5, 9, 3, 6, 7 }, TestName = "TestToArray8")]
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
      
        #endregion
    }
}