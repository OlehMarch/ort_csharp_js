using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task2_01
{
    public class AList2 : IList
    {
        private int[] _array = new int[30];
        private int _start = 15;
        private int _end = 15;

        #region Constructors
        public AList2()
        {
            _array = new int[30];
        }
        #endregion

        #region Crucial
        public int Size()
        {
            return _end - _start;
        }

        public void Clear()
        {
            _start = _array.Length / 2;
            _end = _array.Length / 2;
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

            if (_array.Length <= array.Length)
            {
                _array = new int[array.Length * 13 / 10];
                _start = _array.Length / 2 - array.Length / 2;
            }
            else
            {
                _start -= array.Length / 2;
            }

            for (int i = _start, j = 0; j < array.Length; ++i, ++j)
            {
                _array[i] = array[j];
            }
            _end = _start + array.Length;
        }

        public int[] ToArray()
        {
            if (Size() == 0)
            {
                return new int[0];
            }

            int[] tmp = new int[Size()];

            for (int i = 0; i < Size(); ++i)
            {
                tmp[i] = _array[_start + i];
            }

            return tmp;
        }

        public override string ToString()
        {
            if (Size() == 0)
            {
                return "";
            }

            string res = "";

            for (int i = 0; i < Size(); i++)
            {
                res += _array[_start + i] + " ";
            }
            res = res.TrimEnd();

            return res;
        }
        #endregion

        #region Add
        public void AddStart(int value)
        {
            Upscale(true);

            _array[--_start] = value;
        }

        public void AddEnd(int value)
        {
            Upscale(false);

            _array[_end++] = value;
        }

        public void AddPos(int pos, int value)
        {
            if (pos == 0)
            {
                AddStart(value);
                return;
            }
            if (pos > Size() - 1 || pos + _start < _end - Size())
            {
                throw new IndexOutOfRangeException();
            }

            Upscale(false);

            _end++;
            for (int i = _end - 1; i >= _start; --i)
            {
                if (i == pos + _start)
                {
                    _array[_start + pos] = value;
                    break;
                }
                _array[i] = _array[i - 1];
            }
        }
        #endregion

        #region Delete
        public int DelStart()
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[_start++];
        }

        public int DelEnd()
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[--_end];
        }

        public int DelPos(int pos)
        {
            if (pos > Size() - 1 || pos + _start < _end - Size() || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_start + pos == _start)
            {
                return DelStart();
            }
            else if (_start + pos == _end - 1)
            {
                return DelEnd();
            }

            int retrieve = _array[_start + pos];
            for (int i = pos; i + 1 < Size(); ++i)
            {
                _array[_start + i] = _array[_start + i + 1];
            }
            --_end;

            return retrieve;
        }
        #endregion

        #region Get & Set
        public void Set(int pos, int value)
        {
            if (pos > Size() - 1 || pos + _start < _end - Size() || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            _array[_start + pos] = value;
        }

        public int Get(int pos)
        {
            if (pos > Size() - 1 || pos + _start < _end - Size() || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[_start + pos];
        }
        #endregion

        #region Reverse
        public void Reverse()
        {
            if (Size() == 0 || Size() == 1)
            {
                return;
            }

            for (int i = 0, j = Size() - 1; i < Size() / 2; ++i, --j)
            {
                int temp = _array[_start + j];
                _array[_start + j] = _array[_start + i];
                _array[_start + i] = temp;
            }
        }

        public void HalfReverse()
        {
            if (Size() == 0 || Size() == 1)
            {
                return;
            }

            int halfOfArray = 0;
            if (Size() % 2 == 0)
            {
                halfOfArray = Size() / 2;
            }
            else
            {
                halfOfArray = Size() / 2 + 1;
            }

            for (int i = 0, j = halfOfArray; i < halfOfArray && j < Size(); ++i, ++j)
            {
                int temp = _array[_start + j];
                _array[_start + j] = _array[_start + i];
                _array[_start + i] = temp;
            }
        }
        #endregion

        #region Min & Max
        public int Min()
        {
            return _array[_start + IndMin()];
        }

        public int Max()
        {
            return _array[_start + IndMax()];
        }

        public int IndMin()
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Size() == 1)
            {
                return 0;
            }

            int index = _start;

            for (int i = 1; i < Size(); ++i)
            {
                if (_array[_start + i] < _array[index])
                {
                    index = _start + i;
                }
            }

            return index - _start;
        }

        public int IndMax()
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Size() == 1)
            {
                return 0;
            }

            int index = _start;

            for (int i = 1; i < Size(); ++i)
            {
                if (_array[index] < _array[_start + i])
                {
                    index = _start + i;
                }
            }

            return index - _start;
        }
        #endregion

        #region Sort
        public void Sort()
        {
            QuickSort(_array, _start, _end - 1);
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if (Size() == 1 || Size() == 0)
            {
                return;
            }

            int i = left;
            int j = right;
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
                    int tmp = arr[i];
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

        private void Upscale(bool left)
        {
            if (left) {
                if (_start - 1 < 0 && _end + 1 == _array.Length)
                {
                    Resize(true);
                }
                else if (_start - 1 < 0 && _end + 1 < _array.Length)
                {
                    Init(ToArray());
                }
            }
            else {
                if (_end + 1 >= _array.Length && _start == 1)
                {
                    Resize(false);
                }
                else if (_end + 1 >= _array.Length && _start > 1)
                {
                    Init(ToArray());
                }
            }
        }

        private void Resize(bool left)
        {
            int[] array = new int[_array.Length + (_array.Length * 3 / 10)];
            int delta = 0;
            int j = 0;

            _start = array.Length / 2 - _array.Length / 2;
            _end = _start + _array.Length;
            if (!left)
            {
                _start++;
                j = 1;
                delta = 0;
            }
            else
            {
                _end--;
                j = 0;
                delta = 1;
            }

            for (int i = _start; j < _array.Length - delta; ++i, ++j)
            {
                array[i] = _array[j];
            }

            _array = array;
        }
        #endregion

    }
}
