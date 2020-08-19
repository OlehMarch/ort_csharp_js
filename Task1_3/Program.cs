using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_3
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int Task1(int[] arr)
        {
            return arr[Task3(arr)];
        }

        public static int Task2(int[] arr)
        {
            return arr[Task4(arr)];
        }

        public static int Task3(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            else if (arr.Length == 1)
            {
                return 0;
            }

            int index = 0;

            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] < arr[i - 1])
                {
                    index = i;
                }
            }

            return index;
        }

        public static int Task4(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            else if (arr.Length == 1)
            {
                return 0;
            }

            int index = 0;

            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] > arr[i - 1])
                {
                    index = i;
                }
            }

            return index;
        }

        public static int Task5(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            else if ((arr.Length == 1) || (arr.Length == 2))
            {
                return arr[0];
            }

            int sum = 0;

            for (int i = 0; i < arr.Length; i += 2)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static int[] Task6(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            else if (arr.Length == 1)
            {
                return arr;
            }

            int[] newArr = new int[arr.Length];

            for (int i = 0, j = arr.Length - 1; i < newArr.Length; ++i, --j)
            {
                newArr[i] = arr[j];
            }

            return newArr;
        }

        public static int Task7(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            else if ((arr.Length == 1) || (arr.Length == 2))
            {
                return 1;
            }

            int quantity = 1;

            for (int i = 2; i < arr.Length; i += 2)
            {
                quantity++;
            }

            return quantity;
        }

        public static int[] Task8(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            else if (arr.Length == 1)
            {
                return arr;
            }

            int[] newArr = new int[arr.Length];
            int halfOfArray = arr.Length / 2;

            for (int i = halfOfArray, j = 0; i < arr.Length; ++i, ++j)
            {
                newArr[j] = arr[i];
            }
            for (int i = 0, j = arr.Length - halfOfArray; i < halfOfArray; ++i, ++j)
            {
                newArr[j] = arr[i];
            }

            return newArr;
        }

        public static void Task9_InsertionSort(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            if (arr.Length == 1)
            {
                return;
            }

            int temp = 0;
            int j = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                temp = arr[i];
                j = i - 1;

                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp;
            }
        }

        public static void Task9_SelectionSort(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            if (arr.Length == 1)
            {
                return;
            }

            int min = 0;
            int temp = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        public static void Task9_BubbleSort(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            if (arr.Length == 1)
            {
                return;
            }

            int length = arr.Length;
            int temp = 0;
            bool swapped = false;

            for (int i = 0; i < length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }

        public static void Task10_QuickSort(int[] arr, int left, int right)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if ((arr.Length == 0) || (left < 0) || (left > right) || (right > arr.Length - 1))
            {
                throw new ArgumentException();
            }
            if (arr.Length == 1)
            {
                return;
            }

            int i = left;
            int j = right;
            int tmp = 0;
            int pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Task10_QuickSort(arr, left, j);
            }
            if (i < right)
            {
                Task10_QuickSort(arr, i, right);
            }
        }

        public static void Task10_MergeSort(int[] arr, int left, int right)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if ((arr.Length == 0) || (left < 0) || (left > right) || (right > arr.Length - 1))
            {
                throw new ArgumentException();
            }
            if (arr.Length == 1)
            {
                return;
            }

            if (left < right)
            {
                int middle = (left / 2) + (right / 2);

                Task10_MergeSort(arr, left, middle);
                Task10_MergeSort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }
        }

        public static void Task10_ShellSort(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            if (arr.Length == 1)
            {
                return;
            }

            int j = 0;
            int tmp = 0;
            int gap = 0;

            gap = arr.Length / 2;

            while (gap > 0)
            {
                for (int i = 0; i < arr.Length - gap; i++) //modified insertion sort
                {
                    j = i + gap;
                    tmp = arr[j];
                    while (j >= gap && tmp > arr[j - gap])
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = tmp;
                }
                if (gap == 2) //change the gap size
                {
                    gap = 1;
                }
                else
                {
                    gap = (int)(gap / 2.2);
                }
            }
        }

        public static void Task10_HeapSort(int[] arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
            if (arr.Length == 1)
            {
                return;
            }

            int tmp = 0;

            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                RepairTop(arr, arr.Length - 1, i);
            }
            for (int i = arr.Length - 1; i > 0; i--)
            {
                tmp = arr[i];
                arr[i] = arr[0];
                arr[0] = tmp;
                RepairTop(arr, i - 1, 0);
            }
        }

        private static void Merge(int[] input, int low, int middle, int high)
        {

            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }

        }

        private static void RepairTop(int[] array, int bottom, int topIndex)
        {
            int tmp = array[topIndex];
            int success = topIndex * 2 + 1;
            if (success < bottom && array[success] > array[success + 1]) success++;

            while (success <= bottom && tmp > array[success])
            {
                array[topIndex] = array[success];
                topIndex = success;
                success = success * 2 + 1;
                if (success < bottom && array[success] > array[success + 1])
                {
                    success++;
                }
            }

            array[topIndex] = tmp;
        }
    }
}
