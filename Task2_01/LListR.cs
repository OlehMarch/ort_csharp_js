using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_01
{
    public class LListR : IList
    {
        private sealed class Node
        {
            public int Value { set; get; }
            public Node Next { set; get; }
            public Node Previous { set; get; }

            public Node(int value)
            {
                Value = value;
                Next = Previous = null;
            }
        }

        private Node _root;


        public LListR()
        {
            _root = null;
        }


        #region Crucial
        public int Size()
        {
            int ret = 0;
            if (_root != null)
            {
                ret = 1;
                Node p = _root.Next;
                while (p.Next != _root.Next)
                {
                    ret++;
                    p = p.Next;
                }
            }
            return ret;
        }

        public void Clear()
        {
            _root = null;
        }

        public void Init(int[] ini)
        {
            Clear();

            if (ini == null)
            {
                throw new NullReferenceException();
            }
            if (ini.Length == 0)
            {
                return;
            }

            for (int i = 0; i < ini.Length; i++)
            {
                AddEnd(ini[i]);
            }
        }

        public int[] ToArray()
        {
            int size = Size();
            if (size == 0)
            {
                return new int[0];
            }

            int[] temp = new int[size];
            Node tempStart = _root.Next;
            for (int i = 0; i < size; i++, tempStart = tempStart.Next)
            {
                temp[i] = tempStart.Value;
            }

            return temp;
        }

        public override string ToString()
        {
            if (_root == null)
            {
                return "";
            }

            Node tempL = _root.Next;
            string result = tempL.Value + " ";
            while(tempL.Next != _root.Next)
            {
                tempL = tempL.Next;
                result += tempL.Value + " ";
            }

            return result.TrimEnd();
        }
        #endregion

        #region Add
        public void AddStart(int value)
        {
            if (_root == null)
            {
                _root = new Node(0);
                _root.Next = new Node(value);
                _root.Next.Next = _root.Next;
                _root.Next.Previous = _root.Next;
            }
            else
            {
                Node tempLast = _root.Next;
                while (tempLast.Next != _root.Next)
                {
                    tempLast = tempLast.Next;
                }

                Node tempFirst = _root.Next;
                _root.Next = new Node(value);
                _root.Next.Next = tempFirst;
                tempFirst.Previous = _root.Next;
                _root.Next.Previous = tempLast;
                tempLast.Next = _root.Next;
            }
        }

        public void AddEnd(int value)
        {
            if (_root == null)
            {
                _root = new Node(0);
                _root.Next = new Node(value);
                _root.Next.Next = _root.Next;
                _root.Next.Previous = _root.Next;
            }
            else
            {
                Node temp = _root.Next;
                while (temp.Next != _root.Next)
                {
                    temp = temp.Next;
                }

                temp.Next = new Node(value);
                temp.Next.Next = _root.Next;
                temp.Next.Previous = temp;
                _root.Next.Previous = temp.Next;
            }
        }

        public void AddPos(int pos, int value)
        {
            if (pos < 0 || pos > Size())
            {
                throw new IndexOutOfRangeException();
            }
            if (pos == 0)
            {
                AddStart(value);
                return;
            }

            Node temp = _root.Next;
            for (int i = 0; i + 1 != pos; i++)
            {
                temp = temp.Next;
            }

            Node tempNext = temp.Next;
            temp.Next = new Node(value);
            temp.Next.Previous = temp;
            temp.Next.Next = tempNext;
            tempNext.Previous = temp.Next;
        }
        #endregion

        #region Delete
        public int DelStart()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            int retrieve = 0;
            if (_root.Next.Next == _root.Next)
            {
                retrieve = _root.Next.Value;
                Clear();
            }
            else
            {
                Node tempLast = _root.Next;
                Node tempFirst = _root.Next;
                while (tempLast.Next != _root.Next)
                {
                    tempLast = tempLast.Next;
                }

                retrieve = _root.Next.Value;
                _root.Next = _root.Next.Next;
                _root.Next.Previous = tempLast;
                _root.Next.Next = tempFirst.Next.Next;
                tempLast.Next = _root.Next;
                tempFirst.Next.Next.Previous = _root.Next;
                tempLast = null;
            }

            return retrieve;
        }

        public int DelEnd()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            int retrieve = 0;
            if (_root.Next.Next == _root.Next)
            {
                retrieve = _root.Next.Value;
                _root.Next = null;
                Clear();
            }
            else
            {
                Node tempLast = _root.Next;
                while (tempLast.Next != _root.Next)
                {
                    tempLast = tempLast.Next;
                }

                retrieve = tempLast.Value;
                tempLast.Previous.Next = _root.Next;
                _root.Next.Previous = tempLast.Previous;
                tempLast = null;
            }

            return retrieve;
        }

        public int DelPos(int pos)
        {
            int size = Size();
            if (_root == null || pos < 0 || pos >= size)
            {
                throw new IndexOutOfRangeException();
            }

            int retrieve = 0;
            if (pos == 0)
            {
                retrieve = DelStart();
            }
            else if (pos == size - 1)
            {
                retrieve = DelEnd();
            }
            else
            {
                Node temp = _root.Next;
                for (int i = 0; i + 1 != pos; i++)
                {
                    temp = temp.Next;
                }
                retrieve = temp.Next.Value;
                temp.Next.Next.Previous = temp;
                temp.Next = temp.Next.Next;
            }

            return retrieve;
        }
        #endregion

        #region Get & Set
        public void Set(int pos, int value)
        {
            if (_root == null || pos < 0 || pos >= Size())
            {
                throw new IndexOutOfRangeException();
            }

            Node temp = _root.Next;
            for (int i = 0; i < pos; ++i)
            {
                temp = temp.Next;
            }
            temp.Value = value;
        }

        public int Get(int pos)
        {
            if (_root == null || pos < 0 || pos >= Size())
            {
                throw new IndexOutOfRangeException();
            }

            Node temp = _root.Next;
            for (int i = 0; i < pos; i++)
            {
                temp = temp.Next;
            }
            return temp.Value;
        }
        #endregion

        #region Reverse
        public void Reverse()
        {
            int size = Size();
            if (_root == null || size == 1)
            {
                return;
            }

            Node temp = _root.Next;
            for (int i = 0; i < size; i++)
            {
                AddStart(DelPos(i));
            }
        }

        public void HalfReverse()
        {
            int size = Size();
            if (_root == null || size == 1)
            {
                return;
            }

            Node p = _root.Next;
            Node start = p;
            int halfSize = Size();
            int delta = 0;
            if (halfSize % 2 == 0)
            {
                halfSize /= 2;
                delta = 0;
            }
            else
            {
                halfSize /= 2;
                delta = 1;
            }

            Clear();
            int i = 0;
            do
            {
                if (i >= halfSize + delta)
                {
                    AddEnd(p.Value);
                }

                p = p.Next;
                i++;
            }
            while (p != start);
            p = start;

            if (delta == 1)
            {
                for (int j = 0; j < halfSize; ++j)
                {
                    p = p.Next;
                }
                AddEnd(p.Value);
                p = start;
            }

            i = 0;
            do
            {
                if (i < halfSize)
                {
                    AddEnd(p.Value);
                }

                p = p.Next;
                i++;
            }
            while (p != start);
        }
        #endregion

        #region Min & Max
        public int IndMin()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            int size = Size();
            int index = 0;
            Node temp = _root.Next;
            for (int i = 0, min = temp.Value; i < size - 1; i++)
            {
                if (min > temp.Next.Value)
                {
                    index = i + 1;
                    min = temp.Next.Value;
                }
                temp = temp.Next;
            }
            return index;
        }

        public int IndMax()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            int size = Size();
            int index = 0;
            Node temp = _root.Next;
            for (int i = 0, max = temp.Value; i < size - 1; i++)
            {
                if (max < temp.Next.Value)
                {
                    index = i + 1;
                    max = temp.Next.Value;
                }
                temp = temp.Next;
            }
            return index;
        }

        public int Min()
        {
            return Get(IndMin());
        }

        public int Max()
        {
            return Get(IndMax());
        }
        #endregion

        #region Sort
        public void Sort()
        {
            int size = Size();
            if (_root == null || size == 1)
            {
                return;
            }

            Node p = new Node(DelPos(IndMin()));
            Node start = p;

            while (_root != null)
            {
                p.Next = new Node(DelPos(IndMin()));
                p = p.Next;
            }

            Node tempBegin = start;
            while (tempBegin.Next != null)
            {
                tempBegin.Next.Previous = tempBegin;
                tempBegin = tempBegin.Next;
            }
            tempBegin.Next = start;
            start.Previous = tempBegin;

            _root = new Node(0);
            _root.Next = start;
        }
        #endregion

    }
}
