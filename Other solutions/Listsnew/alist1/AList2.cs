using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
   public class AList2 : IList, IEnumerable, IEnumerator
    {
        int[] ar = new int[30];
        int start = 15;
        int end = 15;
        int index = -1;
        public object Current
        {
            get
            {
                return ar[start + index];
            }
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (index == Size() - 1)
            {
                Reset();
                return false;
            }
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

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
        public void AddEnd(int val)
        {
                Resize();
            ar[end++] = val;
        }

        public void AddPos(int pos, int val)
        {
            if (pos > Size())
            {
                throw new IndexOutOfRangeException();
            }
            Resize();
            if (14 - start > end - 14)
            {
                ++end;
                for (int i = Size() - 1; i > pos; i--)
                {
                    ar[start + i] = ar[start + i - 1];
                }
            }
            else
            {
                for (int i = 0; i < pos; i++)
                {
                    ar[start + i - 1] = ar[start + i];
                }
                --start;
            }
            ar[start+pos] = val;
            
        }

        public void AddStart(int val)
        {
                Resize();
            ar[--start] = val;
        }

        public void Clear()
        {
            start = end = ar.Length / 2;
        }

        public int DelEnd()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            return ar[--end];
        }

        public int DelPos(int pos)
        {
            if (Size() < pos || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int del = ar[pos + start];

            if (14 - start < end - 14)
            {
                for (int i = pos; i < Size(); i++)
                {
                    ar[i + start] = ar[i + start + 1];
                }
                --end;
            }
            else
            {
                for( int i = pos; i > 0; i--)
                {
                    ar[i + start] = ar[i + start - 1];
                }
                ++start;
            }
            return del;
            }

        public int DelStart()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            return ar[start++];
        }

        public int Get(int pos)
        {
            return ar[start + pos];
        }

        public void HalfReverse()
        {
            int k = Size() /2 + Size() % 2;
            for(int i = 0; i<Size() / 2; i++)
            {
                int tmp = ar[i + start];
                ar[i + start] = ar[k + i + start];
                ar[k + i + start] = tmp;
            }
        }

        public int IndMax()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            int index = 0;
            for(int i=1; i < Size(); i++)
            {
                if(ar[index + start] < ar[i + start])
                {
                    index = i;
                }
            }
            return index;
        }

        public int IndMin()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            int index = 0;
            for(int i=1; i < Size(); i++)
            {
                if(ar[index + start] > ar[i + start])
                {
                    index = i;
                }
             }
            return index;
        }

        public void Init(int[] arr)
        {
            Clear();
            if (arr == null || arr.Length == 0 || arr.Length>ar.Length)
                return;

            start = start - arr.Length/2;
            for(int i=0; i< arr.Length; i++)
            {
                ar[start + i] = arr[i];
            }
            end = start + arr.Length;
        }

        public int Max()
        {
            return ar[IndMax()+ start];
        }

        public int Min()
        {
            return ar[IndMin() + start];
        }

        public void Print()
        {
             for(int i=0; i<Size(); i++)
            {
                Console.WriteLine(ar[i + start] + " ");
            }
            Console.WriteLine();
        }

        public void Reverse()
        {
            for(int i = 0; i<Size() / 2; i++)
            {
                int tmp = ar[i + start];
                ar[i + start] = ar[Size() - i + start - 1];
                ar[Size() - i + start - 1] = tmp;
            }
        }

        public void Set(int pos, int val)
        {
            if (pos > Size())
            {
                throw new IndexOutOfRangeException();
            }
            ar[start + pos] = val;
        }

        public int Size()
        {
            return end - start;
        }

        public void Sort()
        {
            for (int i = 0; i < Size(); i++)
            {
                for (int j = 0; j < Size() - i - 1; j++)
                {
                    if (ar[j+start] > ar[j + 1+start])
                    {
                        int temp = ar [j + start];
                        ar[j+start] = ar[j + 1 + start];
                        ar[j + 1 + start] = temp;
                    }
                }
            }
        }

        public int[] ToArray()
        {
            int[] res = new int[Size()];
            for(int i=0; i<Size(); i++)
            {
                res[i] = ar[i + start];
            }
            return res;
        }
        public override string ToString()
        {
            string res="";
            for(int i = start; i<end; i++)
            {
                res += ar[i];
                if(i != end - 1)
                {
                    res += ' ';
                }
            }
            return res;
        }
    }
}
