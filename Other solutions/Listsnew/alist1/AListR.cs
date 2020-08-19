using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class AListR : IList
    {

        int[] ar = new int[10];
        int start = 5;
        int end = 5 / 2;
        bool crossed = false;
        public void Resize()
        {
            if (start == 0 || end == ar.Length - 1)
            {
                if (Size() < ar.Length - 3)
                    Init(ToArray());
                else
                {
                    int[] arr = ToArray();
                    ar = new int[(int)(ar.Length * 1.3)];
                    Init(arr);
                }
            }
        }
        public int Size()
        {
            if (crossed)
            {
                return ar.Length - start + end;
            }
            else
            {
                return end - start;
            }
        }

        public void Clear()
        {
            start = ar.Length / 2;
            end = ar.Length / 2;
            crossed = false;
        }

        public void Init(int[] arToInit)
        {
            Clear();

            if (arToInit == null || arToInit.Length==0)
                return;

            start = start - (arToInit.Length / 2);

            for (int i = 0; i < arToInit.Length; i++)
            {
                ar[start + i] = arToInit[i];
            }

            end = start + arToInit.Length;
        }

        public int[] ToArray()
        {
            int[] result = new int[Size()];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = ar[start + i - ((start + i) / ar.Length) * ar.Length];
            }

            return result;
        }

        public void AddStart(int element)
        {
            if (start > 0)
            {
                ar[--start] = element;
            }
            else
            {
                crossed = true;
                start = ar.Length - 1;
                ar[start] = element;
            }
        }

        public void AddEnd(int element)
        {
            if (end < ar.Length)
            {
                ar[end] = element;
                end++;
            }
            else
            {
                crossed = true;
                end = 1;
                ar[end - 1] = element;
            }
        }

        public void AddPos(int position, int element)
        {
            if (position > Size())
            {
                throw new IndexOutOfRangeException();
            }

            if (crossed)
            {
                if (end > ar.Length - start)
                {
                    for (int i = end + ar.Length; i > start + position; i--)
                    {
                        ar[i - ((i / ar.Length) * ar.Length)] = ar[i - 1 - (((i - 1) / ar.Length) * ar.Length)];
                    }

                    end++;
                    ar[start + position - ((start + position) / ar.Length) * ar.Length] = element;
                }
                else
                {
                    for (int i = start; i < start + position; i++)
                    {
                        ar[i - 1 - (((i - 1) / ar.Length) * ar.Length)] = ar[i - ((i / ar.Length) * ar.Length)];
                    }

                    start--;
                    ar[start + position - ((start + position) / ar.Length) * ar.Length] = element;
                }
            }
            else
            {
                if (start >= ar.Length - end)
                {
                    for (int i = start; i < start + position; i++)
                    {
                        ar[i - 1] = ar[i];
                    }

                    start--;
                    ar[start + position] = element;
                }
                else
                {
                    for (int i = end; i > start + position; i--)
                    {
                        ar[i] = ar[i - 1];
                    }

                    end++;
                    ar[start + position] = element;
                }
            }
        }

        public int DelStart()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            int deleted = ar[start];

            if (start < ar.Length - 1)
            {
                ar[start++] = 0;
            }
            else
            {
                ar[start] = 0;
                start = 0;
                crossed = false;
            }

            return deleted;
        }

        public int DelEnd()
        {
            if(Size() == 0)
            {
                throw new NullReferenceException();
            }
            int deleted = ar[end - 1];

            if (end > 1)
            {
                ar[--end] = 0;
            }
            else
            {
                ar[end - 1] = 0;
                end = ar.Length;
                crossed = false;
            }

            return deleted;
        }

        public int DelPos(int position)
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (position > Size() - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            int deleted = ar[start + position - ((start + position) / ar.Length) * ar.Length];

            if (crossed)
            {
                if (end > ar.Length - start)
                {
                    for (int i = start + position; i > start; i--)
                    {
                        ar[i - ((i / ar.Length) * ar.Length)] = ar[i - 1 - (((i - 1) / ar.Length) * ar.Length)];
                    }

                    ar[start] = 0;

                    if (start < ar.Length - 1)
                    {
                        start++;
                    }
                    else
                    {
                        start = 0;
                        crossed = false;
                    }
                }
                else
                {
                    for (int i = start + position; i < end + ar.Length - 1; i++)
                    {
                        ar[i - ((i / ar.Length) * ar.Length)] = ar[i + 1 - (((i + 1) / ar.Length) * ar.Length)];
                    }

                    ar[end - 1] = 0;

                    if (end > 1)
                    {
                        end--;
                    }
                    else
                    {
                        end = ar.Length;
                        crossed = false;
                    }
                }
            }
            else
            {
                if (start >= ar.Length - end)
                {
                    for (int i = position; i < Size() - 1; i++)
                    {
                        ar[start + i] = ar[start + i + 1];
                    }

                    ar[--end] = 0;
                }
                else
                {
                    for (int i = position; i > 0; i--)
                    {
                        ar[start + i] = ar[start + i - 1];
                    }

                    ar[start++] = 0;
                }
            }

            return deleted;
        }

        public void Set(int position, int element)
        {
            if (position > Size() - 1)
            {
                throw new IndexOutOfRangeException();
            }

            ar[start + position] = element;
        }

        public int Get(int position)
        {
            if (position > Size() - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return ar[start + position - ((start + position) / ar.Length) * ar.Length];
        }

        public void Reverse()
        {
            for (int i = 0; i < Size() / 2; i++)
            {
                int temporary = ar[start + i - ((start + i) / ar.Length) * ar.Length];
                ar[start + i - ((start + i) / ar.Length) * ar.Length] = ar[end - i - 1 - ((end - i - 1) / ar.Length) * ar.Length];
                ar[end - i - 1 - ((end - i - 1) / ar.Length) * ar.Length] = temporary;
            }
        }

        public void HalfReverse()
        {
            int step = Size() / 2 + Size() % 2;

            for (int i = 0; i < Size() / 2; i++)
            {
                int temporary = ar[start + i - ((start + i) / ar.Length) * ar.Length];
                ar[start + i - ((start + i) / ar.Length) * ar.Length] = ar[start + step + i - ((start + step + i) / ar.Length) * ar.Length];
                ar[start + step + i - ((start + step + i) / ar.Length) * ar.Length] = temporary;
            }
        }

        public int Max()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }

            int max = ar[start];

            for (int i = 0; i < Size(); i++)
            {
                if (ar[start + i - ((start + i) / ar.Length) * ar.Length] > max)
                {
                    max = ar[start + i - ((start + i) / ar.Length) * ar.Length];
                }
            }

            return max;
        }

        public int Min()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }

            int min = ar[start];

            for (int i = 0; i < Size(); i++)
            {
                if (ar[start + i - ((start + i) / ar.Length) * ar.Length] < min)
                {
                    min = ar[start + i - ((start + i) / ar.Length) * ar.Length];
                }
            }

            return min;
        }

        public int IndMax()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }

            int indMax = start;

            for (int i = 0; i < Size(); i++)
            {
                if (ar[start + i - ((start + i) / ar.Length) * ar.Length] > ar[indMax])
                {
                    indMax = start + i - ((start + i) / ar.Length) * ar.Length;
                }
            }

            return start > indMax ? indMax + ar.Length - start : indMax - start;
        }

        public int IndMin()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }

            int indMin = start;

            for (int i = 0; i < Size(); i++)
            {
                if (ar[start + i - ((start + i) / ar.Length) * ar.Length] < ar[indMin])
                {
                    indMin = start + i - ((start + i) / ar.Length) * ar.Length;
                }
            }

            return start > indMin ? indMin + ar.Length - start : indMin - start;
        }

        public void Sort()
        {
            for (int i = 0; i < Size(); i++)
            {
                for (int j = i + 1; j < Size(); j++)
                {
                    if (ar[start + i - ((start + i) / ar.Length) * ar.Length] > ar[start + j - ((start + j) / ar.Length) * ar.Length])
                    {
                        int temporary = ar[start + i - ((start + i) / ar.Length) * ar.Length];
                        ar[start + i - ((start + i) / ar.Length) * ar.Length] = ar[start + j - ((start + j) / ar.Length) * ar.Length];
                        ar[start + j - ((start + j) / ar.Length) * ar.Length] = temporary;
                    }
                }
            }
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < Size(); i++)
            {
                str += ar[start + i - ((start + i) / ar.Length) * ar.Length];
                if (i < Size() - 1) str += " ";
            }

            return str;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
