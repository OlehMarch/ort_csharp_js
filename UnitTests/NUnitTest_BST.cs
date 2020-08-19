using System;
using NUnit;
using NUnit.Framework;
using Task4_02;


namespace UnitTests
{
    [TestFixture(typeof(BSTree))]
    [TestFixture(typeof(BSTreeVis))]
    public class NUnitTest_BST<TTree> where TTree : ITree, new()
    {
        ITree tree = new TTree();
        
        [PreTest]
        private void SetUp()
        {
            tree.Clear();
        }

        #region Equal
        [TestCase(new int[0] { }, new int[0] { }, true, TestName = "Equal 0")]
        [TestCase(new int[1] { 2 }, new int[1] { 5 }, false, TestName = "Equal 1")]
        [TestCase(new int[2] { 2, 5 }, new int[2] { 2, 5 }, true, TestName = "Equal 2")]
        [TestCase(new int[8] { 5, 4, 3, 1, 7, 6, 8, 9 }, new int[8] { 5, 4, 2, 1, 7, 6, 8, 9 }, false, TestName = "Equal Many False")]
        [TestCase(new int[8] { 5, 4, 3, 1, 7, 6, 8, 9 }, new int[8] { 5, 4, 3, 1, 7, 6, 8, 9 }, true, TestName = "Equal Many True")]
        public void TestEquals(int[] ini, int[] compare, bool expected)
        {
            tree.Init(ini);
            TTree tree1 = new TTree();
            tree1.Init(compare);
            bool actual = tree.Equals(tree1);

            Assert.AreEqual(actual, expected);
        }
        #endregion

        #region Enumerator tests
        [TestCase(new int[] { }, new int[] { }, TestName = "Enumerator 0")]
        [TestCase(new int[] { 0 }, new int[] { 0 }, TestName = "Enumerator 1")]
        [TestCase(new int[] { 0, 1 }, new int[] { 0, 1 }, TestName = "Enumerator 2")]
        [TestCase(new int[] { 0, 1, 4, 3, 2, 5, 6, 7, 8 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, TestName = "Enumerator Many")]
        public void TestEnumerator(int[] ini, int[] expected)
        {
            BSTree tree = new BSTree();
            tree.Init(ini);
            int[] actual = new int[ini.Length];
            int iterator = 0;
            foreach (var item in tree)
            {
                actual[iterator++] = (int)item;
            }
            CollectionAssert.AreEqual(actual, expected);
        }
        #endregion

        #region Init
        [TestCase(null, TestName = "Init NullRef Exc")]
        public void NU_Init_ArrayNull_Exc(int[] ini)
        {
            Assert.That(() => tree.Init(ini), Throws.TypeOf<NullReferenceException>());
        }

        [TestCase(new int[] { }, new int[] { }, TestName = "Init 0")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "Init 1")]
        [TestCase(new int[] { 50, 25 }, new int[] { 25, 50 }, TestName = "Init 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, new int[] { 7, 11, 25, 30, 50, 80, 85, 90 }, TestName = "Init Many")]
        public void NU_Init(int[] ini, int[] exp)
        {
            tree.Init(ini);
            int[] act = tree.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region ToArray
        [TestCase(new int[] { }, new int[] { }, TestName = "ToArray 0")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "ToArray 1")]
        [TestCase(new int[] { 50, 25 }, new int[] { 25, 50 }, TestName = "ToArray 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, new int[] { 7, 11, 25, 30, 50, 80, 85, 90 }, TestName = "ToArray Many")]
        public void NU_ToArray(int[] ini, int[] exp)
        {
            tree.Init(ini);
            int[] act = tree.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region ToString
        [TestCase(new int[] { }, "", TestName = "ToString 0")]
        [TestCase(new int[] { 1 }, "1", TestName = "ToString 1")]
        [TestCase(new int[] { 50, 25 }, "25 50", TestName = "ToString 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, "7 11 25 30 50 80 85 90", TestName = "ToString Many")]
        public void NU_ToString(int[] ini, string exp)
        {
            tree.Init(ini);
            string act = tree.ToString();
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Size
        [TestCase(new int[] { }, 0, TestName = "Size 0")]
        [TestCase(new int[] { 1 }, 1, TestName = "Size 1")]
        [TestCase(new int[] { 50, 25 }, 2, TestName = "Size 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 8, TestName = "Size Many")]
        public void NU_Size(int[] ini, int exp)
        {
            tree.Init(ini);
            int act = tree.Size();
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Add
        [TestCase(new int[] { }, 1, "1", TestName = "Add 0")]
        [TestCase(new int[] { 1 }, -1, "-1 1", TestName = "Add 1")]
        [TestCase(new int[] { 50, 25 }, 90, "25 50 90", TestName = "Add 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 40, "7 11 25 30 40 50 80 85 90", TestName = "Add Many")]
        public void NU_Add(int[] ini, int value, string exp)
        {
            tree.Init(ini);
            tree.Add(value);
            string act = tree.ToString();
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Delete
        [TestCase(new int[] { }, 1, "", TestName = "Delete 0")]
        [TestCase(new int[] { 1 }, 1, "", TestName = "Delete 1")]
        [TestCase(new int[] { 50, 25 }, 50, "25", TestName = "Delete 2 Root")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 25, "7 11 30 50 80 85 90", TestName = "Delete Many Left Node")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 90, "7 11 25 30 50 80 85", TestName = "Delete Many Right Node")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 30, "7 11 25 50 80 85 90", TestName = "Delete Many Left Leaf")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 85, "7 11 25 30 50 80 90", TestName = "Delete Many Right Leaf")]
        public void NU_Delete(int[] ini, int value, string exp)
        {
            tree.Init(ini);
            tree.Delete(value);
            string act = tree.ToString();
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Reverse
        [TestCase(new int[] { }, "", TestName = "Reverse 0")]
        [TestCase(new int[] { 1 }, "1", TestName = "Reverse 1")]
        [TestCase(new int[] { 50, 25 }, "50 25", TestName = "Reverse 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, "90 85 80 50 30 25 11 7", TestName = "Reverse Many")]
        public void NU_Reverse(int[] ini, string exp)
        {
            tree.Init(ini);
            tree.Reverse();
            string act = tree.ToString();
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Width
        [TestCase(new int[] { }, 0, TestName = "Width 0")]
        [TestCase(new int[] { 1 }, 1, TestName = "Width 1")]
        [TestCase(new int[] { 50, 25 }, 1, TestName = "Width 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 3, TestName = "Width Many")]
        public void NU_Width(int[] ini, int exp)
        {
            tree.Init(ini);
            int act = tree.Width();
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Height
        [TestCase(new int[] { }, 0, TestName = "Height 0")]
        [TestCase(new int[] { 1 }, 1, TestName = "Height 1")]
        [TestCase(new int[] { 50, 25 }, 2, TestName = "Height 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 4, TestName = "Height Many")]
        public void NU_Height(int[] ini, int exp)
        {
            tree.Init(ini);
            int act = tree.Height();
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Leaves
        [TestCase(new int[] { }, 0, TestName = "Leaves 0")]
        [TestCase(new int[] { 1 }, 1, TestName = "Leaves 1")]
        [TestCase(new int[] { 50, 25 }, 1, TestName = "Leaves 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 3, TestName = "Leaves Many")]
        public void NU_Leaves(int[] ini, int exp)
        {
            tree.Init(ini);
            int act = tree.Leaves();
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Nodes
        [TestCase(new int[] { }, 0, TestName = "Nodes 0")]
        [TestCase(new int[] { 1 }, 0, TestName = "Nodes 1")]
        [TestCase(new int[] { 50, 25 }, 1, TestName = "Nodes 2")]
        [TestCase(new int[] { 50, 25, 90, 80, 11, 7, 85, 30 }, 5, TestName = "Nodes Many")]
        public void NU_Nodes(int[] ini, int exp)
        {
            tree.Init(ini);
            int act = tree.Nodes();
            Assert.AreEqual(exp, act);
        }
        #endregion

    }
}
