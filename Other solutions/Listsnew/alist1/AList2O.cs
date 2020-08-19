using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class AList2O
    {
        object[] ar = new object[30];
        Type type = null;
        int start = 15;
        int end = 15;

        public void Resize()
        {
            if (start == 0 || end == ar.Length - 1)
            {
                if (Size() < ar.Length - 3)
                    Init(ToArray());
                else
                {
                    object[] arr = ToArray();
                    ar = new object[(int)(ar.Length * 1.3)];
                    Init(arr);
                }
            }
        }
        public void AddEnd(object val)
        {
            if (type == null)
            { 
                type = val.GetType();
            }
            if (val.GetType() != type)
            {
                throw new InvalidOperationException();
            }
            Resize();
            ar[end++] = val;
        }

        public void AddPos(int pos, object val)
        {
            if (val.GetType() != type)
            {
                throw new InvalidOperationException();
            }
            if (pos > Size() || pos < 0)
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
            ar[start + pos] = val;

        }

        public void AddStart(object val)
        {
            if (type == null)
            {
                type = val.GetType();
            }
            if (val.GetType() != type)
            {
                throw new InvalidOperationException();
            }
            Resize();
            ar[--start] = val;
        }

        public void Clear()
        {
            start = end = ar.Length / 2;
        }

        public object DelEnd()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            return ar[--end];
        }

        public object DelPos(int pos)
        {
            if (Size() < pos || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }
            object del = ar[pos + start];

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
                for (int i = pos; i > 0; i--)
                {
                    ar[i + start] = ar[i + start - 1];
                }
                ++start;
            }
            return del;
        }

        public object DelStart()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            return ar[start++];
        }

        public object Get(int pos)
        {
            if (pos > Size() || pos < 0)
                throw new Exception();
            return ar[start + pos];
        }

        public void HalfReverse()
        {
            int k = Size() / 2 + Size() % 2;
            for (int i = 0; i < Size() / 2; i++)
            {
                object tmp = ar[i + start];
                ar[i + start] = ar[k + i + start];
                ar[k + i + start] = tmp;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < Size(); i++)
            {
                for (int j = 0; j < Size() - i - 1; j++)
                {
                    if (!Compar(ar[j + start],ar[j + 1 + start]))
                    {
                        object temp = ar[j + start];
                        ar[j + start] = ar[j + 1 + start];
                        ar[j + 1 + start] = temp;
                    }
                }
            }
        }

        public int IndMax()
        {
            if (Size() == 0)
            {
                throw new NullReferenceException();
            }
            int index = 0;
            for (int i = 1; i < Size(); i++)
            {
                if (Compar(ar[index + start],ar[i + start]))
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
            for (int i = 1; i < Size(); i++)
            {
                if (!Compar(ar[index + start], ar[i + start]))
                {
                    index = i;
                }
            }
            return index;
        }

        public void Init(object obj)
        {
            Clear();
            Array o = null;
            if (obj.GetType() == typeof(int[]))
            {
                type = typeof(int);
                o = obj as int[];
            }
            if (obj.GetType() == typeof(string[]))
            {
                type = typeof(string);
                o = obj as string[];
            }
            start = start - o.GetLength(0) / 2;
            for (int i = 0; i < o.Length; i++)
            {
                ar[start + i] = o.GetValue(i);
            }
            end = start + o.Length;
        }

        public object Max()
        {
            return ar[IndMax() + start];
        }
        public object Min()
        {
            return ar[IndMin() + start];
        }

        public void Print()
        {
            for (int i = 0; i < Size(); i++)
            {
                Console.WriteLine(ar[i + start] + " ");
            }
            Console.WriteLine();
        }

        public void Reverse()
        {
            for (int i = 0; i < Size() / 2; i++)
            {
                object tmp = ar[i + start];
                ar[i + start] = ar[Size() - i + start - 1];
                ar[Size() - i + start - 1] = tmp;
            }
        }

        public void Set(int pos, object val)
        {
            if (pos > Size() || pos < 0)
            {
                throw new IndexOutOfRangeException();
            }
            ar[start + pos] = val;
        }

        public int Size()
        {
            return end - start;
        }

        public object[] ToArray()
        {
            object[] res = new object[Size()];
            for (int i = 0; i < Size(); i++)
            {
                res[i] = ar[i + start];
            }
            return res;
        }
        public override string ToString()
        {
            string res = "";
            for (int i = start; i < end; i++)
            {
                res += ar[i];
                if (i != end - 1)
                {
                    res += ' ';
                }
            }
            return res;
        }

        private bool Compar(object i, object j)
        {
            bool res=false;
            if(type == typeof(int))
            {
                if ( (int)i > (int)j )
                    res = false;
                else
                    res = true;
            }
            if(type == typeof(string))
            {
                if ((i as string).CompareTo((j as string)) == 1)
                    res = false;
                else if ((i as string).CompareTo((j as string)) == -1)
                    res = true;
                else
                    res = false;
            }
            return res;
        }
    }
}
