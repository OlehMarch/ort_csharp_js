using System;
using Task1_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_Task1_3
    {
        //Arrays must be tested with next data:
        // array == null, Length == 0/1/2/Many(more then 5)

        #region Task1
        [TestMethod]
        public void TestMethod_Task1_OneNode()
        {
            int res = 0;

            res = Program.Task1(new int[] { 1 });

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task1_TwoNodes()
        {
            int res = 0;

            res = Program.Task1(new int[] { 1, -1 });

            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void TestMethod_Task1_ManyNodes()
        {
            int res = 0;

            res = Program.Task1(new int[] { 1, 10, 5, 55, 7, -1 });

            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task1_ArrNull_Exc()
        {
            Program.Task1(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task1_ArrEmpty_Exc()
        {
            Program.Task1(new int[] { });
        }
        #endregion

        #region Task2
        [TestMethod]
        public void TestMethod_Task2_OneNode()
        {
            int res = 0;

            res = Program.Task2(new int[] { 1 });

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task2_TwoNodes()
        {
            int res = 0;

            res = Program.Task2(new int[] { -1, 1 });

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task2_ManyNodes()
        {
            int res = 0;

            res = Program.Task2(new int[] { 1, 10, 5, 55, 7, -1 });

            Assert.AreEqual(res, 55);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task2_ArrNull_Exc()
        {
            Program.Task2(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task2_ArrEmpty_Exc()
        {
            Program.Task2(new int[] { });
        }
        #endregion

        #region Task3
        [TestMethod]
        public void TestMethod_Task3_OneNode()
        {
            int res = 0;

            res = Program.Task3(new int[] { 1 });

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void TestMethod_Task3_TwoNodes()
        {
            int res = 0;

            res = Program.Task3(new int[] { 1, -1 });

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task3_ManyNodes()
        {
            int res = 0;

            res = Program.Task3(new int[] { 1, 10, 5, 55, 7, -1 });

            Assert.AreEqual(res, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task3_ArrNull_Exc()
        {
            Program.Task3(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task3_ArrEmpty_Exc()
        {
            Program.Task3(new int[] { });
        }
        #endregion

        #region Task4
        [TestMethod]
        public void TestMethod_Task4_OneNode()
        {
            int res = 0;

            res = Program.Task4(new int[] { 1 });

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void TestMethod_Task4_TwoNodes()
        {
            int res = 0;

            res = Program.Task4(new int[] { -1, 1 });

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task4_ManyNodes()
        {
            int res = 0;

            res = Program.Task4(new int[] { 1, 10, 5, 55, 7, -1 });

            Assert.AreEqual(res, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task4_ArrNull_Exc()
        {
            Program.Task4(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task4_ArrEmpty_Exc()
        {
            Program.Task4(new int[] { });
        }
        #endregion

        #region Task5
        [TestMethod]
        public void TestMethod_Task5_OneNode()
        {
            int res = 0;

            res = Program.Task5(new int[] { 1 });

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task5_TwoNodes()
        {
            int res = 0;

            res = Program.Task5(new int[] { 2, 4 });

            Assert.AreEqual(res, 2);
        }

        [TestMethod]
        public void TestMethod_Task5_ManyNodes()
        {
            int res = 0;

            res = Program.Task5(new int[] { 1, 10, 5, 55, 7, -1 });

            Assert.AreEqual(res, 13);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task5_ArrNull_Exc()
        {
            Program.Task5(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task5_ArrEmpty_Exc()
        {
            Program.Task5(new int[] { });
        }
        #endregion

        #region Task6
        [TestMethod]
        public void TestMethod_Task6_ReverseOfOneNode()
        {
            int[] arrA = null;
            int[] arrB = new int[] { 10 };
            bool result = false;

            arrA = Program.Task6(new int[] { 10 });
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task6_ReverseOfTwoNodes()
        {
            int[] arrA = null;
            int[] arrB = new int[] { 10, 1 };
            bool result = false;

            arrA = Program.Task6(new int[] { 1, 10 });
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task6_ReverseOfManyNodes()
        {
            int[] arrA = null;
            int[] arrB = new int[] { -1, 55, 8, 5, 2, 1 };
            bool result = false;

            arrA = Program.Task6(new int[] { 1, 2, 5, 8, 55, -1 });
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task6_ArrNull_Exc()
        {
            Program.Task6(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task6_ArrEmpty_Exc()
        {
            Program.Task6(new int[] { });
        }
        #endregion

        #region Task7
        [TestMethod]
        public void TestMethod_Task7_QuantityOfOddNodes_OneNode()
        {
            int res = 0;

            res = Program.Task7(new int[] { 1 });

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task7_QuantityOfOddNodes_TwoNodes()
        {
            int res = 0;

            res = Program.Task7(new int[] { 10, 8 });

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void TestMethod_Task7_QuantityOfOddNodes_ManyEven()
        {
            int res = 0;

            res = Program.Task7(new int[] { 1, 2, 5, 8, 55, -1 });

            Assert.AreEqual(res, 3);
        }

        [TestMethod]
        public void TestMethod_Task7_QuantityOfOddNodes_ManyOdd()
        {
            int res = 0;

            res = Program.Task7(new int[] { 1, 2, 5, 8, 55, -1, 7 });

            Assert.AreEqual(res, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task7_ArrNull_Exc()
        {
            Program.Task7(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task7_ArrEmpty_Exc()
        {
            Program.Task7(new int[] { });
        }
        #endregion

        #region Task8
        [TestMethod]
        public void TestMethod_Task8_OneNode()
        {
            int[] arrA = null;
            int[] arrB = new int[] { 1 };
            bool result = false;

            arrA = Program.Task8(new int[] { 1 });
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task8_TwoNodes()
        {
            int[] arrA = null;
            int[] arrB = new int[] { 1, 2 };
            bool result = false;

            arrA = Program.Task8(new int[] { 2, 1 });
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task8_ManyEven()
        {
            int[] arrA = null;
            int[] arrB = new int[] { 1, 2, 3, 4, 5, 6 };
            bool result = false;

            arrA = Program.Task8(new int[] { 4, 5, 6, 1, 2, 3 });
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task8_ManyOdd()
        {
            int[] arrA = null;
            int[] arrB = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            bool result = false;

            arrA = Program.Task8(new int[] { 5, 6, 7, 1, 2, 3, 4 });
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task8_ArrNull_Exc()
        {
            Program.Task8(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task8_ArrEmpty_Exc()
        {
            Program.Task8(new int[] { });
        }
        #endregion

        #region Task9
        #region Exceptions
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task9_BubbleSort_ArrNull_Exc()
        {
            Program.Task9_BubbleSort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task9_SelectionSort_ArrNull_Exc()
        {
            Program.Task9_SelectionSort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task9_InsertionSort_ArrNull_Exc()
        {
            Program.Task9_InsertionSort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task9_BubbleSort_ArrEmpty_Exc()
        {
            Program.Task9_BubbleSort(new int[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task9_SelectionSort_ArrEmpty_Exc()
        {
            Program.Task9_SelectionSort(new int[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task9_InsertionSort_ArrEmpty_Exc()
        {
            Program.Task9_InsertionSort(new int[] { });
        }
        #endregion
        #region Bubble sort
        [TestMethod]
        public void TestMethod_Task9_BubbleSort_OneNode()
        {
            int[] arrA = new int[] { 1 };
            int[] arrB = new int[] { 1 };
            bool result = false;

            Program.Task9_BubbleSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task9_BubbleSort_TwoNodes()
        {
            int[] arrA = new int[] { 4, 2 };
            int[] arrB = new int[] { 2, 4 };
            bool result = false;

            Program.Task9_BubbleSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task9_BubbleSort_ManyNodes()
        {
            int[] arrA = new int[] { 4, 5, 6, 1, 2, 3 };
            int[] arrB = new int[] { 1, 2, 3, 4, 5, 6 };
            bool result = false;

            Program.Task9_BubbleSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }
        #endregion
        #region Selection sort
        [TestMethod]
        public void TestMethod_Task9_SelectionSort_OneNode()
        {
            int[] arrA = new int[] { 1 };
            int[] arrB = new int[] { 1 };
            bool result = false;

            Program.Task9_SelectionSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task9_SelectionSort_TwoNodes()
        {
            int[] arrA = new int[] { 6, 4 };
            int[] arrB = new int[] { 4, 6 };
            bool result = false;

            Program.Task9_SelectionSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task9_SelectionSort_ManyNodes()
        {
            int[] arrA = new int[] { 5, 6, 7, 1, 2, 3, 4 };
            int[] arrB = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            bool result = false;

            Program.Task9_SelectionSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }
        #endregion
        #region Insertion sort
        [TestMethod]
        public void TestMethod_Task9_InsertionSort_OneNode()
        {
            int[] arrA = new int[] { 5, 6, 7, 1, 2, 3, 4 };
            int[] arrB = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            bool result = false;

            Program.Task9_InsertionSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task9_InsertionSort_TwoNodes()
        {
            int[] arrA = new int[] { 5, 1 };
            int[] arrB = new int[] { 1, 5 };
            bool result = false;

            Program.Task9_InsertionSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task9_InsertionSort_ManyNodes()
        {
            int[] arrA = new int[] { 5, 6, 7, 1, 2, 3, 4 };
            int[] arrB = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            bool result = false;

            Program.Task9_InsertionSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }
        #endregion
        #endregion

        #region Task10
        #region Quick sort
        [TestMethod]
        public void TestMethod_Task10_QuickSort_OneNode()
        {
            int[] arrA = new int[] { 1 };
            int[] arrB = new int[] { 1 };
            bool result = false;

            Program.Task10_QuickSort(arrA, 0, arrA.Length - 1);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task10_QuickSort_TwoNodes()
        {
            int[] arrA = new int[] { 6, 1 };
            int[] arrB = new int[] { 1, 6 };
            bool result = false;

            Program.Task10_QuickSort(arrA, 0, arrA.Length - 1);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task10_QuickSort_ManyNodes()
        {
            int[] arrA = new int[] { 4, 5, 6, 1, 2, 3 };
            int[] arrB = new int[] { 1, 2, 3, 4, 5, 6 };
            bool result = false;

            Program.Task10_QuickSort(arrA, 0, arrA.Length - 1);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }
        #endregion
        #region Merge sort
        [TestMethod]
        public void TestMethod_Task10_MergeSort_OneNode()
        {
            int[] arrA = new int[] { 1 };
            int[] arrB = new int[] { 1 };
            bool result = false;

            Program.Task10_MergeSort(arrA, 0, arrA.Length - 1);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task10_MergeSort_TwoNodes()
        {
            int[] arrA = new int[] { 7, 1 };
            int[] arrB = new int[] { 1, 7 };
            bool result = false;

            Program.Task10_MergeSort(arrA, 0, arrA.Length - 1);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task10_MergeSort_ManyNodes()
        {
            int[] arrA = new int[] { 5, 6, 7, 1, 2, 3, 4 };
            int[] arrB = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            bool result = false;

            Program.Task10_MergeSort(arrA, 0, arrA.Length - 1);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }
        #endregion
        #region Quick sort
        [TestMethod]
        public void TestMethod_Task10_ShellSort_OneNode()
        {
            int[] arrA = new int[] { 7 };
            int[] arrB = new int[] { 7 };
            bool result = false;

            Program.Task10_ShellSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task10_ShellSort_TwoNodes()
        {
            int[] arrA = new int[] { 1, 7 };
            int[] arrB = new int[] { 7, 1 };
            bool result = false;

            Program.Task10_ShellSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task10_ShellSort_ManyNodes()
        {
            int[] arrA = new int[] { 5, 6, 7, 1, 2, 3, 4 };
            int[] arrB = new int[] { 7, 6, 5, 4, 3, 2, 1 };
            bool result = false;

            Program.Task10_ShellSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }
        #endregion
        #region Quick sort
        [TestMethod]
        public void TestMethod_Task10_HeapSort_OneNode()
        {
            int[] arrA = new int[] { 7 };
            int[] arrB = new int[] { 7 };
            bool result = false;

            Program.Task10_HeapSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task10_HeapSort_TwoNodes()
        {
            int[] arrA = new int[] { 1, 7 };
            int[] arrB = new int[] { 7, 1 };
            bool result = false;

            Program.Task10_HeapSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod_Task10_HeapSort_ManyNodes()
        {
            int[] arrA = new int[] { 5, 6, 7, 1, 2, 3, 4 };
            int[] arrB = new int[] { 7, 6, 5, 4, 3, 2, 1 };
            bool result = false;

            Program.Task10_HeapSort(arrA);
            result = arrA.SequenceEqual(arrB);

            Assert.AreEqual(result, true);
        }
        #endregion

        #region Exceptions
        #region Quick sort
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task10_QuickSort_ArrNull_Exc()
        {
            Program.Task10_QuickSort(null, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_QuickSort_ArrEmpty_Exc()
        {
            Program.Task10_QuickSort(new int[] { }, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_QuickSort_BeneathLeft_Exc()
        {
            Program.Task10_QuickSort(new int[] { 1, 2 }, -1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_QuickSort_LeftAboveRight_Exc()
        {
            Program.Task10_QuickSort(new int[] { 1, 2 }, 2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_QuickSort_AboveRight_Exc()
        {
            Program.Task10_QuickSort(new int[] { 1, 2 }, 0, 10);
        }
        #endregion
        #region Merge sort
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task10_MergeSort_ArrNull_Exc()
        {
            Program.Task10_MergeSort(null, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_MergeSort_ArrEmpty_Exc()
        {
            Program.Task10_MergeSort(new int[] { }, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_MergeSort_BeneathLeft_Exc()
        {
            Program.Task10_MergeSort(new int[] { 1, 2 }, -1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_MergeSort_LeftAboveRight_Exc()
        {
            Program.Task10_MergeSort(new int[] { 1, 2 }, 2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_MergeSort_AboveRight_Exc()
        {
            Program.Task10_MergeSort(new int[] { 1, 2 }, 0, 10);
        }
        #endregion
        #region Shell & Heap sort
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task10_ShellSort_ArrNull_Exc()
        {
            Program.Task10_ShellSort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod_Task10_HeapSort_ArrNull_Exc()
        {
            Program.Task10_HeapSort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_ShellSort_ArrEmpty_Exc()
        {
            Program.Task10_ShellSort(new int[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Task10_HeapSort_ArrEmpty_Exc()
        {
            Program.Task10_HeapSort(new int[] { });
        }
        #endregion
        #endregion
        #endregion

    }
}
