using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Task2_01
{
    public class AList1 : IList, IEnumerator
    {
        private int[] _array = new int[10];
        private int _index = 0;
        private int _iterator = -1;


        #region Enumerator
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_iterator == _index - 1)
            {
                Reset();
                return false;
            }

            _iterator++;
            return true;
        }

        public void Reset()
        {
            _iterator = -1;
        }

        public object Current
        {
            get
            {
                return _array[_iterator];
            }
        }
        #endregion

        #region Constructors
        public AList1()
        {
            _array = new int[10];
        }
        #endregion

        #region Crucial
        public int Size()
        {
            return _index;
        }

        public void Clear()
        {
            _index = 0;
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
                Upscale(true);
            }
            _index = array.Length;

            for (int i = 0; i < _index; ++i)
            {
                _array[i] = array[i];
            }
        }

        public int[] ToArray()
        {
            if (_index == 0)
            {
                return new int[0];
            }

            int[] tmp = new int[_index];

            for (int i = 0; i < _index; ++i)
            {
                tmp[i] = _array[i];
            }

            return tmp;
        }

        public override string ToString()
        {
            if (_index == 0)
            {
                return "";
            }

            string res = "";

            for (int i = 0; i < _index; i++)
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
            Upscale();
            _index++;
            
            for (int i = 1; i < _index; i++)
            {
                _array[_index - i] = _array[_index - 1 - i];
            }
            _array[0] = value;
        }

        public void AddEnd(int value)
        {
            Upscale();

            _array[_index++] = value;
        }

        public void AddPos(int pos, int value)
        {
            if (pos == 0)
            {
                AddStart(value);
                return;
            }
            if (pos > _index - 1 || pos < 0 || _index == 0)
            {
                throw new IndexOutOfRangeException();
            }

            Upscale();
            _index++;

            for (int i = 1; i < _index; ++i)
            {
                if (_index - i == pos)
                {
                    _array[_index - i] = value;
                    break;
                }
                _array[_index - i] = _array[_index - 1 - i];
            }
        }
        #endregion

        #region Delete
        public int DelStart()
        {
            if (_index == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int retrieve = _array[0];
            for (int i = 1; i < _index; i++)
            {
                _array[i - 1] = _array[i];
            }
            --_index;

            return retrieve;
        }

        public int DelEnd()
        {
            if (_index == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int retrieve = _array[--_index];

            return retrieve;
        }

        public int DelPos(int pos)
        {
            if (pos > _index - 1 || pos < 0 || _index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (pos == 0)
            {
                return DelStart();
            }
            else if (pos == _index - 1)
            {
                return DelEnd();
            }

            int retrieve = _array[pos];
            for (int i = pos; i + 1 < _index; ++i)
            {
                _array[i] = _array[i + 1];
            }
            --_index;

            return retrieve;
        }
        #endregion

        #region Get & Set
        public void Set(int pos, int value)
        {
            if (_index == 0 || pos > _index - 1 || pos < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _array[pos] = value;
        }

        public int Get(int pos)
        {
            if (_index == 0 || pos > _index - 1 || pos < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[pos];
        }
        #endregion

        #region Reverse
        public void Reverse()
        {
            if (_index == 0 || _index == 1)
            {
                return;
            }

            for (int i = 0, j = _index - 1; i < _index / 2; ++i, --j)
            {
                int temp = _array[j];
                _array[j] = _array[i];
                _array[i] = temp;
            }
        }

        public void HalfReverse()
        {
            if (_index == 0 || _index == 1)
            {
                return;
            }

            int temp = 0;
            int halfOfArray = 0;
            if (_index % 2 == 0)
            {
                halfOfArray = _index / 2;
            }
            else
            {
                halfOfArray = _index / 2 + 1;
            }

            for (int i = 0, j = halfOfArray; i < halfOfArray && j < _index; ++i, ++j)
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
            if (_index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (_index == 1)
            {
                return 0;
            }

            int index = 0;

            for (int i = 1; i < _index; ++i)
            {
                if (_array[i] < _array[index])
                {
                    index = i;
                }
            }

            return index;
        }

        public int IndMax()
        {
            if (_index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (_index == 1)
            {
                return 0;
            }

            int index = 0;

            for (int i = 1; i < _index; ++i)
            {
                if (_array[index] < _array[i])
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
            QuickSort(_array, 0, _index - 1);
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if (_index == 1 || _index == 0)
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

        private void Upscale(bool init = false)
        {
            if (init)
            {
                Resize();
                return;
            }

            if (_index + 1 >= _array.Length)
            {
                Resize();
            }
        }

        private void Resize()
        {
            int length = _array.Length + (_array.Length * 3 / 10);

            int[] array = new int[length];
            for (int i = 0; i < _array.Length; ++i)
            {
                array[i] = _array[i];
            }

            _array = array;
        }
        #endregion

    }
}
