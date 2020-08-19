using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{

    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(LList2))]
    public class TestListMetodsNUnit<TList> where TList : IList, new()
    {
        IList lst = new TList();

        [SetUp]
        public void Clear_al()
        {
            lst.Clear();
        }
         [TestCase(new int[] { })]
         [TestCase(new int[] { 10 })]
         [TestCase(new int[] { 9, 2 })]
         [TestCase(new int[] { 5, 15, 4, 0, 0, -3, -10 })]
        public void TestMethod(int[] ar)
        {
            lst.Init(ar);
            int[] act = new int[lst.Size()];
            int i = 0;
            foreach(int a in lst)
            {
                act[i++] = a;
            }
            CollectionAssert.AreEqual(act, lst.ToArray());
        }
    }
}
