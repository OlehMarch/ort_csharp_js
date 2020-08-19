//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace List
//{
//    public static class SecretFind_AList2
//    {
//        public static int[] GetSecretUsingFieldInfo(this AList2 keeper)
//        {
//            FieldInfo fieldInfo = typeof(AList2).GetField("ar", BindingFlags.Instance | BindingFlags.NonPublic);
//            int[] result = (int[])fieldInfo.GetValue(keeper);
//            return result;
//        }
//    }
//    [TestFixture]
//    public class WhiteBoxList2
//    {
//        AList2 al;
//        [SetUp]
//        public void setup()
//        {
//            al = new AList2();
//        }
//        [Test]
//        public void ResizeNO()
//        {
//            int[] exp = new int[] { 1, 2, 3, 5 };
//            al.Init(exp);
//            int[] ar = al.GetSecretUsingFieldInfo();
//            Assert.AreEqual(30, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());

//        }
//        [Test]
//        public void ResizeAddStart()
//        {
//            int[] arr = new int[] { 1, 2, 3, 5, 1, 9, 7, 3, 6, 1, 9, 6, 2, 3, 1, 6, 5, 3, 7, 9, 8, 7, 6, 5, 4, 2, 1, 7, 8, 9 };
//            al.Init(arr);
//            al.AddStart(5);
//            int[] ar = al.GetSecretUsingFieldInfo();
//            int[] exp = new int[] { 5, 1, 2, 3, 5, 1, 9, 7, 3, 6, 1, 9, 6, 2, 3, 1, 6, 5, 3, 7, 9, 8, 7, 6, 5, 4, 2, 1, 7, 8, 9 };
//            Assert.AreEqual(39, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [Test]
//        public void ResizeAddPos()
//        {
//            int[] arr = new int[] { 1, 2, 3, 5, 1, 9, 7, 3, 6, 1, 9, 6, 2, 3, 1, 6, 5, 3, 7, 9, 8, 7, 6, 5, 4, 2, 1, 7 };
//            al.Init(arr);
//            al.AddPos(1, 8);
//            int[] ar = al.GetSecretUsingFieldInfo();
//            int[] exp = new int[] { 1,8, 2, 3, 5, 1, 9, 7, 3, 6, 1, 9, 6, 2, 3, 1, 6, 5, 3, 7, 9, 8, 7, 6, 5, 4, 2, 1, 7};
//            Assert.AreEqual(39, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [Test]
//        public void TestMethod_2()
//        {
//            int[] arr = new int[] { 1, 2, 3, 5, 1, 9, 7, 3, 6, 1, 9, 6, 2, 3, 1, 6, 5, 3, 7, 9, 8, 7, 6, 5, 4, 2, 1, 7 };
//            al.Init(arr);
//            al.AddEnd(8);
//            int[] ar = al.GetSecretUsingFieldInfo();
//            int[] exp = new int[] { 1, 2, 3, 5, 1, 9, 7, 3, 6, 1, 9, 6, 2, 3, 1, 6, 5, 3, 7, 9, 8, 7, 6, 5, 4, 2, 1, 7, 8 };
//            Assert.AreEqual(39, ar.Length);
//            CollectionAssert.AreEqual(exp, al.ToArray());
//        }
//        [TearDown]
//        public void teardown()
//        {
//            al = null;
//        }
//    }
//}
