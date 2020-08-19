using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task2_01
{
    public class AList0 : IList
    {
        private int[] _array = { };

        #region Constructors
        public AList0()
        {
            _array = new int[] { };
        }
        #endregion

        #region Crucial
        public int Size()
        {
            return _array.Length;
        }

        public void Clear()
        {
            _array = new int[0];
        }

        public void Init(int[] array)
        {
            Clear();

            if (array == null)
            {
                throw new NullReferenceException();
            }
            if (array.Length == 0)
            {
                return;
            }

            _array = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
        }

        public int[] ToArray()
        {
            if (_array.Length == 0)
            {
                return new int[0];
            }

            int[] tmp = new int[_array.Length];

            for (int i = 0; i < _array.Length; ++i)
            {
                tmp[i] = _array[i];
            }

            return tmp;
        }

        public override string ToString()
        {
            if (_array.Length == 0)
            {
                return "";
            }

            string res = "";

            for (int i = 0; i < _array.Length; i++)
            {
                res += _array[i] + " ";
            }
            res = res.TrimEnd();

            return res;
        }
        #endregion

        #region Add
        public void AddStart(int value)
        {
            int[] temp = new int[_array.Length + 1];
            for (int i = 0; i < _array.Length; i++)
            {
                temp[i + 1] = _array[i];
            }
            temp[0] = value;
            _array = temp;
        }

        public void AddEnd(int value)
        {
            int[] temp = new int[_array.Length + 1];
            for (int i = 0; i < _array.Length; i++)
            {
                temp[i] = _array[i];
            }
            temp[_array.Length] = value;
            _array = temp;
        }

        public void AddPos(int pos, int value)
        {
            if (pos == 0)
            {
                AddStart(value);
                return;
            }
            if (pos > _array.Length - 1 || pos < 0 || _array.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int[] temp = new int[_array.Length + 1];
            for (int i = 0, j = 0; j < _array.Length; ++i, ++j)
            {
                if (i == pos)
                {
                    temp[i] = value;
                    j--;
                    continue;
                }
                temp[i] = _array[j];
            }
            _array = temp;
        }
        #endregion

        #region Delete
        public int DelStart()
        {
            if (_array.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int[] temp = new int[_array.Length - 1];
            int retrieve = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = _array[i + 1];
            }
            retrieve = _array[0];
            _array = temp;

            return retrieve;
        }

        public int DelEnd()
        {
            if (_array.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int[] temp = new int[_array.Length - 1];
            int retrieve = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = _array[i];
            }
            retrieve = _array[temp.Length];
            _array = temp;

            return retrieve;
        }

        public int DelPos(int pos)
        {
            if (pos > _array.Length - 1 || pos < 0 || _array.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int retrieve = 0;
            retrieve = _array[pos];

            int[] temp = new int[_array.Length - 1];
            for (int i = 0, j = 0; j < _array.Length; ++i, ++j)
            {
                if (j == pos)
                {
                    i--;
                    continue;
                }
                temp[i] = _array[j];
            }
            _array = temp;

            return retrieve;
        }
        #endregion

        #region Get & Set
        public void Set(int pos, int value)
        {
            if (_array.Length == 0 || pos > _array.Length - 1 || pos < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _array[pos] = value;
        }

        public int Get(int pos)
        {
            if (_array.Length == 0 || pos > _array.Length - 1 || pos < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[pos];
        }
        #endregion

        #region Sort & Reverse
        public void Reverse()
        {
            if (_array.Length == 0 || _array.Length == 1)
            {
                return;
            }

            int temp = 0;

            for (int i = 0, j = _array.Length - 1; i < _array.Length / 2; ++i, --j)
            {
                temp = _array[j];
                _array[j] = _array[i];
                _array[i] = temp;
            }
        }

        public void HalfReverse()
        {
            if (_array.Length == 0 || _array.Length == 1)
            {
                return;
            }

            int temp = 0;
            int halfOfArray = 0;
            if (_array.Length % 2 == 0)
            {
                halfOfArray = _array.Length / 2;
            }
            else
            {
                halfOfArray = _array.Length / 2 + 1;
            }

            for (int i = 0, j = halfOfArray; i < halfOfArray && j < _array.Length; ++i, ++j)
            {
                temp = _array[j];
                _array[j] = _array[i];
                _array[i] = temp;
            }
        }
        #endregion

        #region Min & Max
        public int Min()
        {
            return _array[IndMin()];
        }

        public int Max()
        {
            return _array[IndMax()];
        }

        public int IndMin()
        {
            if (_array.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (_array.Length == 1)
            {
                return 0;
            }

            int index = 0;

            for (int i = 1; i < _array.Length; ++i)
            {
                if (_array[i] < _array[i - 1])
                {
                    index = i;
                }
            }

            return index;
        }

        public int IndMax()
        {
            if (_array.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (_array.Length == 1)
            {
                return 0;
            }

            int index = 0;

            for (int i = 1; i < _array.Length; ++i)
            {
                if (_array[i] > _array[i - 1])
                {
                    index = i;
                }
            }

            return index;
        }
        #endregion

        #region Sort
        public void Sort()
        {
            QuickSort(_array, 0, _array.Length - 1);
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if (arr.Length == 1 || arr.Length == 0)
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
                QuickSort(arr, left, j);
            }
            if (i < right)
            {
                QuickSort(arr, i, right);
            }
        }
        #endregion

        #region Other
        public void PrintMethodNames()
        {
            Type type = this.GetType();
            MethodInfo[] methodInfo = type.GetMethods();

            foreach (MethodInfo item in methodInfo)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Overall quantity of methods: " + methodInfo.Length + "\n");
        }
        #endregion

    }
}
