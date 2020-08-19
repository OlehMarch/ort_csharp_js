using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class AList1 : IList
    {
        int index = 0;
        int[] ar = new int[10];
        public void Resize()
        {
            if (index + 1 < ar.Length)
                return;
            int[] arr = new int[index] ;
            for (int i = 0; i < index; i++)
            {
                arr[i] = ar[i];
            }
            ar = new int[(int)(arr.Length * 1.3)];
            Init(arr);
        }
        public int Size()
        {
            return index;
        }
        public void Clear()
        {
            index = 0;
        }
        public void AddStart(int val)
        {
            Resize();
            for (int i = index; i > 0; i--)
            {
                ar[i] = ar[i - 1];
            }
            ar[0] = val;
            ++index;
        }
        public void Print()
        {
            for (int i = 0; i < index; i++)
            {
                Console.Write(ar[i] + " ");
            }
            Console.WriteLine();
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < index; i++)
            {
                str += ar[i];
                if (i != index - 1)
                    str += ' ';
            }
            return str;
        }
        public void Init(int[] ini)
        {
            if (ini == null || ini.Length == 0)
                return;
            
            index = ar.Length;

            if (ar.Length <= ini.Length)
                ar = new int[ar.Length + ar.Length / 2];

            for (int i = 0; i < ini.Length; i++)
            {
                ar[i] = ini[i];
            }
            index = ini.Length;
        }
        public int[] ToArray()
        {
            int[] result = new int[index];
            for (int i = 0; i < index; i++)
            {
                result[i] = ar[i];
            }
            return result;
        }
        public void AddEnd(int val)
        {
            Resize();
            ar[index] = val;
            ++index;
        }
       
        public void AddPos(int pos, int val)
        {
            Resize();
            if (pos > index)
            {
                throw new IndexOutOfRangeException();
            }
            ++index;
            for (int i = index - 1; i > pos; i--)
            {
                ar[i] = ar[i - 1];
            }
            ar[pos] = val;
        }

        public int DelStart()
        {
            if (index == 0)
            {
                throw new NullReferenceException();
            }
            int del;
            del = ar[0];
            for (int i = 1; i < index; i++)
            {
                ar[i - 1] = ar[i];
            }
            --index;
            return del;
        }
        public int DelEnd()
        {
            if (index == 0)
            {
                throw new NullReferenceException();
            }
            int del;
            del = ar[index - 1];
            --index;
            return del;
        }
        public int DelPos(int pos)
        {
            if (index < pos || index==0)
            {
                throw new IndexOutOfRangeException();
            }
            int del;          
            del = ar[pos];
            for (int i = pos ; i < index; i++)
            {
                ar[i] = ar[i+1];
            }
            --index;
            return del;
        }
        public void Set(int pos, int val)
        {
            if (pos > index)
            {
                throw new IndexOutOfRangeException();
            }
            ar[pos] = val;
        }
        public int Get(int pos)
        {
            if (index == -1)
            {
                throw new NullReferenceException();
            }
            return ar[pos];
        }
        public void Reverse()
        {
            for (int i = 0; i < (index) / 2; i++)
            {
                int tmp = ar[i];
                ar[i] = ar[index  - i - 1];
                ar[index - i - 1] = tmp;
            }
        }
        public void HalfReverse()
        {
            int z = (index) / 2 + (index ) % 2;
            for (int i = 0; i < (index ) / 2; i++)
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
            for (int i = 0; i <index; i++)
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
            for (int i = 0; i <index; i++)
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
            for (int i = 0; i <index; i++)
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
