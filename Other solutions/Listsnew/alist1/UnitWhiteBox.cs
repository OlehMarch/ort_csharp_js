//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace List
//{
//    public static class SecretFind
//    {
//        public static int[] GetSecretUsingFieldInfo(this AList1 keeper)
//        {
//            FieldInfo fieldInfo = typeof(AList1).GetField("ar", BindingFlags.Instance | BindingFlags.NonPublic);
//            int [] result = (int[])fieldInfo.GetValue(keeper);
//            return result;
//        }
//    }
//    [TestFixture]
//    public class UnitWhiteBox
//    {
//        AList1 al;
//        [SetUp]
//      public  void setup()
//        {
//            al = new AList1();
//        }
//        [Test]
//        public void ResizeNO()
//        {
//            int[] exp = new int[] { 1, 2, 3, 5 };
//            al.Init(exp);
//            int[] ar = al.GetSecretUsingFieldInfo();
//            Assert.AreEqual(10, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [Test]
//        public void ResizeInInit()
//        {
//            int[] exp = new int[] { 1, 2, 3, 5,1,9,7,3,6,1,9,6 };
//            al.Init(exp);
//            int[] ar = al.GetSecretUsingFieldInfo();
//            Assert.AreEqual(15, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [Test]
//        public void ResizeAddEnd()
//        {
//            int[] arr = new int[] { 1, 2, 3, 5, 1, 9, 7, 3, 9 };
//            al.Init(arr);
//            al.AddEnd(2);
//            al.AddEnd(2);
//            int[] exp = new int[] { 1, 2, 3, 5, 1, 9, 7, 3, 9, 2,2 };
//            int[] ar = al.GetSecretUsingFieldInfo();
//            Assert.AreEqual(13, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [Test]
//        public void ResizeAddPos()
//        {
//            int[] arr = new int[] { 1, 2, 3, 5, 1, 9, 7, 3, 9 };
//            al.Init(arr);
//            al.AddPos(0, 9);
//            al.AddPos(8, 2);
//            int[] exp = new int[] { 9, 1, 2, 3, 5, 1, 9, 7,2, 3, 9 };
//            int[] ar = al.GetSecretUsingFieldInfo();
//            Assert.AreEqual(13, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [Test]
//        public void ResizeAddStart()
//        {
//            int[] arr = new int[] { 1, 2, 3, 5, 1, 9, 7, 3, 9 };
//            al.Init(arr);
//            al.AddStart(9);
//            al.AddStart(2);
//            int[] exp = new int[] { 2, 9, 1, 2, 3, 5, 1, 9,7, 3, 9 };
//            int[] ar = al.GetSecretUsingFieldInfo();
//            Assert.AreEqual(13, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [Test]
//        public void ResizeNOAddStart()
//        {
//            int[] arr = new int[] { 1, 2, 3, 5, 1, 9};
//            al.Init(arr);
//            al.AddStart(9);
//            al.AddStart(2);
//            int[] exp = new int[] { 2,9, 1, 2, 3, 5, 1, 9 };
//            int[] ar = al.GetSecretUsingFieldInfo();
//            Assert.AreEqual(10, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TearDown]
//        public void teardown()
//        {
//            al = null;
//        }
//    }
//}
