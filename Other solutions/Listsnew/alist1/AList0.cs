using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class AList0 : IList
    {
        int[] ar = { };
        public int Size()
        {
            return ar.Length;
        }
        public void Clear()
        {
            ar = new int[0];
        }
        public void AddStart(int val)
        {
            int[] tt = new int[ar.Length + 1];
            for (int i = 0; i < ar.Length; i++)
            {
                tt[i + 1] = ar[i];
            }
            tt[0] = val;
            ar = tt;
        }
        public void Print()
        {
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write(ar[i] + " ");
            }
            Console.WriteLine();
        }
        override public string ToString()
        {
            string str = "";
            for (int i = 0; i < ar.Length; i++)
            {
                str += ar[i];
                if (i != ar.Length - 1)
                    str += ' ';
            }
            return str;
        }
        public void Init(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;
            Clear();
            ar = new int[arr.Length];
            for(int i=0; i< arr.Length; i++)
            {
                ar[i] = arr[i];
            }
        }
        public int[] ToArray()
        {
            int[] tmp = new int[ar.Length];
            for(int i=0; i<ar.Length; i++)
            {
                tmp[i] = ar[i];
            }
            return tmp;
        }
        public void AddEnd(int val)
        {
            int[] tt = new int[ar.Length + 1];
            for (int i = 0; i < ar.Length; i++)
            {
                tt[i] = ar[i];
            }
            tt[ar.Length] = val;
            ar = tt;
        }
        public void AddPos(int pos, int val)
        {
            if (Size() < pos)
            {
                throw new IndexOutOfRangeException();
            }
            int[] tt = new int[ar.Length + 1];
            for (int i = 0, j = 0; i < ar.Length; j++, i++)
            {
                 if (j == pos)
                 {
                    tt[i] = val;
                    j++;
                 }
                 tt[j] = ar[i];
            }
            if (ar.Length == pos)
                tt[pos] = val;

            ar = tt;
        }

        public int DelStart()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            int del;
            int[] tt = new int[ar.Length - 1];
            del = ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                tt[i-1] = ar[i];
            }
            ar = tt;
            return del;
        }
        public int DelEnd()
        {    
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            int del= ar[ar.Length - 1];
            int[] tt = new int[ar.Length - 1];
         
            for (int i = 0; i < ar.Length - 1; i++)
            {
                tt[i] = ar[i];
            }
            ar = tt;
            return del;
        }
        public int DelPos(int pos)
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int del;
            int[] tt = new int[ar.Length - 1];
            del = ar[pos];
            for (int i = 0, j = 0; i < tt.Length; j++, i++)
            {
                if (j == pos)
                    j++;
                tt[i] = ar[j];
            }
            ar = tt;
            return del;
        }
        public void Set(int pos, int val)
        {
            ar[pos] = val;
        }
        public int Get(int pos)
        {
            return ar[pos];
        }
        public void Reverse()
        {
            for (int i = 0; i < ar.Length / 2; i++)
            {
                int tmp = ar[i];
                ar[i] = ar[ar.Length - i - 1];
                ar[ar.Length - i - 1] = tmp;
            }
        }
        public void HalfReverse()
        {
            int z = ar.Length / 2 + ar.Length % 2;
            for (int i = 0; i < ar.Length / 2; i++)
            {
                int tmp = ar[i];
                ar[i] = ar[z + i];
                ar[z + i] = tmp;
            }
        }
        public int IndMin()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            int res = 0;
            for (int i = 1; i < ar.Length; i++)
            {
                if (ar[i] < ar[res])
                {
                    res = i;
                }
            }
            return res;
        }
        public int IndMax()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            int res = 0;
            for (int i = 1; i < ar.Length; i++)
            {
                if (ar[i] > ar[res])
                {
                    res = i;
                }
            }
            return res;
        }
        public int Min()
        {
            return ar[IndMin()];
        }
        public int Max()
        {
            return ar[IndMax()];
        }

        public void Sort()
        {
            for (int i = 1; i < ar.Length; i++)
                for (int j = i; j > 0 && ar[j - 1] > ar[j]; j--)
                {
                    int temp = ar[j - 1];
                    ar[j - 1] = ar[j];
                    ar[j] = temp;
                }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
