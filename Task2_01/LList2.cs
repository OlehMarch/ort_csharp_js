using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_01
{
    public class LList2 : IList
    {
        private class Node
        {
            public Node Next { set; get; }
            public Node Previous { set; get; }
            public int Value { set; get; }
            public Node(int value)
            {
                Next = Previous = null;
                Value = value;
            }
        }

        public LList2()
        {
            _head = null;
            _tail = null;
        }


        private Node _head;
        private Node _tail;


        #region Crucial
        public int Size()
        {
            int length = 0;
            Node temp = _head;
            while (temp != null)
            {
                temp = temp.Next;
                length++;
            }

            return length;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
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

            for (int i = ini.Length - 1; i >= 0; i--)
            {
                AddStart(ini[i]);
            }
        }

        public int[] ToArray()
        {
            int[] temp = new int[Size()];
            Node tempL = _head;
            int i = 0;
            while (i < temp.Length)
            {
                temp[i++] = tempL.Value;
                tempL = tempL.Next;
            }
            return temp;
        }

        public override string ToString()
        {
            int size = Size();
            if (size == 0)
            {
                return "";
            }

            string str = "";
            Node tempL = _head;
            while (tempL != null)
            {
                str += tempL.Value.ToString() + " ";
                tempL = tempL.Next;
            }

            return str.TrimEnd();
        }
        #endregion

        #region Add
        public void AddStart(int value)
        {
            if (_head == null)
            {
                _head = new Node(value);
                _tail = _head;
            }
            else
            {
                Node temp = new Node(value);
                temp.Next = _head;
                _head.Previous = temp;
                _head = temp;
            }
        }

        public void AddEnd(int value)
        {
            if (_head == null)
            {
                _head = new Node(value);
                _tail = _head;
            }
            else
            {
                _tail.Next = new Node(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
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

            Node temp = _head;
            for (int i = 0; i < pos; i++)
            {
                temp = temp.Next;
            }

            Node newNode = new Node(value);
            newNode.Previous = temp.Previous;
            newNode.Next = temp;
            temp.Previous.Next = newNode;
            temp.Previous = newNode;
        }
        #endregion

        #region Del
        public int DelStart()
        {
            if (_head == null)
            {
                throw new IndexOutOfRangeException();
            }

            int retrieve = _head.Value;
            if (_head.Next == null)
            {
                _head = _tail = null;
            }
            else
            {
                _head = _head.Next;
                _head.Previous = null;
                if (_head == _tail)
                {
                    _tail.Previous = null;
                }
            }

            return retrieve;
        }

        public int DelEnd()
        {
            if (_head == null)
            {
                throw new IndexOutOfRangeException();
            }

            int retrieve = _tail.Value;
            if (_tail.Previous == null)
            {
                _head = _tail = null;
            }
            else
            {
                _tail = _tail.Previous;
                _tail.Next = null;
                if (_tail == _head)
                {
                    _head.Next = null;
                }
            }
            
            return retrieve;
        }

        public int DelPos(int pos)
        {
            int size = Size();
            if (_head == null || pos < 0 || pos >= size)
            {
                throw new IndexOutOfRangeException();
            }
            if (pos == 0)
            {
                return DelStart();
            }
            else if (pos == size - 1)
            {
                return DelEnd();
            }

            Node temp = _head;
            for (int i = 0; i < pos; i++)
            {
                temp = temp.Next;
            }
            int retrieve = temp.Value;
            temp.Next.Previous = temp.Previous;
            temp.Previous.Next = temp.Next;

            return retrieve;
        }
        #endregion

        #region Get & Set
        public void Set(int pos, int value)
        {
            if (_head == null || pos < 0 || pos >= Size())
            {
                throw new IndexOutOfRangeException();
            }

            Node temp = _head;
            for (int i = 0; i < pos; i++)
            {
                temp = temp.Next;
            }

            temp.Value = value;
        }

        public int Get(int pos)
        {
            if (_head == null || pos < 0 || pos >= Size())
            {
                throw new IndexOutOfRangeException();
            }

            Node temp = _head;
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
            if (_head == null || Size() == 1)
            {
                return;
            }

            Node p = _head;
            Clear();
            while (p != null)
            {
                AddStart(p.Value);
                p = p.Next;
            }
        }

        public void HalfReverse()
        {
            if (_head == null || Size() == 1)
            {
                return;
            }

            Node p = _head;
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
            while (p != null)
            {
                if (i >= halfSize + delta)
                {
                    AddEnd(p.Value);
                }

                p = p.Next;
                i++;
            }
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

            for (int j = 0; j < halfSize && p != null; ++j)
            {
                AddEnd(p.Value);
                p = p.Next;
            }
        }
        #endregion

        #region Min & Max
        public int IndMin()
        {
            int size = Size();
            if (size == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (size == 1)
            {
                return 0;
            }

            int index = 0;
            int min = _head.Value;
            Node temp = _head.Next;
            for (int i = 1; i < size; i++)
            {
                if (min > temp.Value)
                {
                    index = i;
                    min = temp.Value;
                }

                temp = temp.Next;
            }

            return index;
        }

        public int IndMax()
        {
            int size = Size();
            if (size == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (size == 1)
            {
                return 0;
            }

            int index = 0;
            int max = _head.Value;
            Node temp = _head.Next;
            for (int i = 1; i < size; i++)
            {
                if (max < temp.Value)
                {
                    index = i;
                    max = temp.Value;
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
            if (_head == null || Size() == 1)
            {
                return;
            }

            Node p = new Node(DelPos(IndMin()));
            Node start = p;

            while (_head != null)
            {
                p.Next = new Node(DelPos(IndMin()));
                p = p.Next;
            }
            _head = start;
        }
        #endregion

    }
}
