using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task2_01
{
    public class AListR : IList
    {
        private int[] _array = new int[10];
        private int _start = 5;
        private int _end = 5;
        private bool _overlapped = false;

        #region Constructors
        public AListR()
        {
            _array = new int[10];
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

            if (array.Length >= _array.Length)
            {
                _array = new int[array.Length * 13 / 10];
                Init(array);
                return;
            }

            if (array.Length > _array.Length / 2)
            {
                _overlapped = true;
            }
            else
            {
                _overlapped = false;
            }

            for (int i = _start, j = 0; j < array.Length; ++i, ++j)
            {
                int delta = 0;
                if (i >= _array.Length)
                {
                    delta = _array.Length;
                }
                _array[i - delta] = array[j];
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

            if (_overlapped && _start < 0)
            {
                for (int i = 0, j = _start; i < Size(); ++i, ++j)
                {
                    int delta = 0;
                    if (j < 0)
                    {
                        delta = _array.Length;
                    }
                    tmp[i] = _array[j + delta];
                }
            }
            else if (_overlapped && _end > _array.Length)
            {
                for (int i = 0, j = _start; i < Size(); ++i, ++j)
                {
                    int delta = 0;
                    if (j >= _array.Length)
                    {
                        delta = _array.Length;
                    }
                    tmp[i] = _array[j - delta];
                }
            }
            else
            {
                for (int i = 0; i < Size(); ++i)
                {
                    tmp[i] = _array[_start + i];
                }
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

            if (_overlapped && _start < 0)
            {
                for (int i = 0, j = _start; i < Size(); ++i, ++j)
                {
                    int delta = 0;
                    if (j < 0)
                    {
                        delta = _array.Length;
                    }
                    res += _array[j + delta] + " ";
                }
            }
            else if (_overlapped && _end > _array.Length)
            {
                for (int i = 0, j = _start; i < Size(); ++i, ++j)
                {
                    int delta = 0;
                    if (j >= _array.Length)
                    {
                        delta = _array.Length;
                    }
                    res += _array[j - delta] + " ";
                }
            }
            else
            {
                for (int i = 0; i < Size(); ++i)
                {
                    res += _array[_start + i] + " ";
                }
            }
            res = res.TrimEnd();

            return res;
        }
        #endregion

        #region Add
        public void AddStart(int value)
        {
            Upscale();

            if (_start - 1 < 0 || _end > _array.Length)
            {
                _overlapped = true;
            }
            else
            {
                _overlapped = false;
            }

            if (!_overlapped || _start - 1 >= 0)
            {
                _array[--_start] = value;
            }
            else
            {
                _array[--_start + _array.Length] = value;
            }
        }

        public void AddEnd(int value)
        {
            Upscale();

            if (_start - 1 < 0 || _end >= _array.Length)
            {
                _overlapped = true;
            }
            else
            {
                _overlapped = false;
            }

            if (!_overlapped)
            {
                _array[_end++] = value;
            }
            else
            {
                _array[_end++ - _array.Length] = value;
            }
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

            Upscale();

            if (_start - 1 < 0 || _end > _array.Length)
            {
                _overlapped = true;
            }
            else
            {
                _overlapped = false;
            }

            if (!_overlapped)
            {
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
            else
            {
                _end++;
                for (int i = _end - 1; i >= _start; --i)
                {
                    int delta = 0;
                    if (i >= _array.Length)
                    {
                        delta = _array.Length;
                    }

                    if (i - delta == pos + _start)
                    {
                        int ind = _start + pos - delta;
                        if (ind + 1 == _array.Length)
                        {
                            _array[ind + 1 - _array.Length] = _array[ind];
                        }
                        else
                        {
                            _array[ind + 1] = _array[ind];
                        }
                        _array[ind] = value;
                        break;
                    }

                    if (i + 1 - delta == _array.Length)
                    {
                        _array[0] = _array[i - delta];
                    }
                    else
                    {
                        _array[i + 1 - delta] = _array[i - delta];
                    }
                }
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

            int delta = 0;
            if (_start >= _array.Length)
            {
                delta = _array.Length;
            }

            return _array[_start++ - delta];
        }

        public int DelEnd()
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int delta = 0;
            if (_end - 1 >= _array.Length)
            {
                delta = _array.Length;
            }

            return _array[--_end - delta];
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

            int retrieve = 0;
            if (!_overlapped)
            {
                retrieve = _array[_start + pos];
                for (int i = pos; i + 1 < Size(); ++i)
                {
                    _array[_start + i] = _array[_start + i + 1];
                }
                _array[--_end] = 0;
            }
            else
            {
                int i = 0;
                if (_start + pos >= _array.Length)
                {
                    i = _start + pos - _array.Length;
                    retrieve = _array[i];

                    for (; _start + pos + i < _end; ++i)
                    {
                        int ind = i + 1;
                        if (ind == _array.Length)
                        {
                            _array[ind - 1] = _array[ind - _array.Length];
                        }
                        else
                        {
                            _array[ind - 1] = _array[ind];
                        }
                    }
                }
                else
                {
                    i = _start + pos;
                    retrieve = _array[_start + pos];

                    for (; i + 1 < _end; ++i)
                    {
                        int ind = i + 1;
                        if (ind == _array.Length)
                        {
                            _array[ind - 1] = _array[ind - _array.Length];
                        }
                        else if (ind < _array.Length)
                        {
                            _array[ind - 1] = _array[ind];
                        }
                        else
                        {
                            _array[ind - 1 - _array.Length] = _array[ind - _array.Length];
                        }
                    }
                }

                if (_end - 1 >= _array.Length)
                {
                    _array[--_end - _array.Length] = 0;
                }
                else
                {
                    _array[--_end] = 0;
                }
            }

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

            int delta = 0;
            if (pos >= _array.Length / 2)
            {
                delta = _array.Length;
            }

            _array[_start + pos - delta] = value;
        }

        public int Get(int pos)
        {
            if (pos > Size() - 1 || pos + _start < _end - Size() || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int delta = 0;
            if (pos >= _array.Length / 2)
            {
                delta = _array.Length;
            }

            return _array[_start + pos - delta];
        }
        #endregion

        #region Reverse
        public void Reverse()
        {
            if (Size() == 0 || Size() == 1)
            {
                return;
            }

            int[] array = ToArray();

            for (int i = 0, j = Size() - 1; i < Size() / 2; ++i, --j)
            {
                int temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }

            Init(array);
        }

        public void HalfReverse()
        {
            if (Size() == 0 || Size() == 1)
            {
                return;
            }

            int[] array = ToArray();
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
                int temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }

            Init(array);
        }
        #endregion

        #region Min & Max
        public int Min()
        {
            int ind = 0;
            if (IndMin() >= _array.Length / 2)
            {
                ind = IndMin() - _array.Length;
            }
            else
            {
                ind = IndMin();
            }
            return _array[_start + ind];
        }

        public int Max()
        {
            int ind = 0;
            if (IndMax() >= _array.Length / 2)
            {
                ind = IndMax() - _array.Length;
            }
            else
            {
                ind = IndMax();
            }
            return _array[_start + ind];
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

            int index = 0;
            int[] arr = ToArray();

            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] < arr[index])
                {
                    index = i;
                }
            }

            return index;
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

            int index = 0;
            int[] arr = ToArray();

            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] > arr[index])
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
            int[] array = ToArray();
            QuickSort(array, 0, Size() - 1);
            Init(array);
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if (Size() == 1 || Size() == 0)
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

        private void Upscale()
        {
            if (_start + _array.Length == _end + 1)
            {
                int[] array = ToArray();
                _array = new int[_array.Length * 13 / 10];
                Init(array);
            }
        }
        #endregion

    }
}
