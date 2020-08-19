using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task2_01
{
    public class LList1 : IList, IEnumerator
    {
        class Node
        {
            public int value;
            public Node next;
            public Node(int val)
            {
                this.value = val;
            }
        }

        Node _root = null;
        private int _iterator = -1;


        #region Enumeration
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_iterator >= Size() - 1)
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
                Node tmp = _root;
                for (int i = 0; i < _iterator; i++)
                {
                    tmp = tmp.next;
                }
                return tmp.value;
            }
        }
        #endregion

        #region Crucial
        public int Size()
        {
            int ret = 0;
            Node p = _root;
            while (p != null)
            {
                ret++;
                p = p.next;
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

            for (int i = ini.Length - 1; i >= 0; i--)
            {
                AddStart(ini[i]);
            }
        }

        public int[] ToArray()
        {
            int[] ret = new int[Size()];
            int i = 0;
            Node p = _root;
            while (p != null)
            {
                ret[i++] = p.value;
                p = p.next;
            }
            return ret;
        }

        public override string ToString()
        {
            string ret = "";
            Node p = _root;
            while (p != null)
            {
                ret += p.value + " ";
                p = p.next;
            }
            ret = ret.TrimEnd();
            return ret;
        }
        #endregion

        #region Add
        public void AddStart(int value)
        {
            Node tmp = new Node(value);
            tmp.next = _root;
            _root = tmp;
        }

        public void AddEnd(int value)
        {
            if (_root == null)
            {
                AddStart(value);
                return;
            }

            Node p = _root;
            while (p.next != null)
            {
                p = p.next;
            }
            p.next = new Node(value);
        }

        public void AddPos(int pos, int value)
        {
            if (pos == 0)
            {
                AddStart(value);
                return;
            }
            if (pos < 0 || pos >= Size())
            {
                throw new IndexOutOfRangeException();
            }

            Node newNode = new Node(value);
            Node p = _root;
            int i = 0;
            while (p != null)
            {
                if (i + 1 == pos)
                {
                    newNode.next = p.next;
                    p.next = newNode;
                    break;
                }
                p = p.next;
                i++;
            }
        }
        #endregion

        #region Del
        public int DelStart()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            int receive = _root.value;
            Node p = _root.next;
            _root = p;
            return receive;
        }

        public int DelEnd()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            int receive = 0;
            if (Size() == 1)
            {
                receive = _root.value;
                _root = null;
            }
            else if (Size() == 2)
            {
                receive = _root.next.value;
                _root.next = null;
            }
            else
            {
                Node p = _root;
                while (p.next.next != null)
                {
                    p = p.next;
                }
                receive = p.next.value;
                p.next = null;
            }

            return receive;
        }

        public int DelPos(int pos)
        {
            if (_root == null || pos < 0 || pos > Size() - 1)
            {
                throw new IndexOutOfRangeException();
            }
            if (pos == 0)
            {
                return DelStart();
            }

            int receive = 0;
            if (Size() == 1)
            {
                receive = _root.value;
                _root = null;
            }
            else
            {
                Node p = _root;
                int i = 0;
                while (i + 1 != pos)
                {
                    p = p.next;
                    i++;
                }
                receive = p.next.value;
                p.next = p.next.next;
            }

            return receive;
        }
        #endregion

        #region Get & Set
        public int Get(int pos)
        {
            if (Size() == 0 || pos > Size() - 1 || pos < 0)
            {
                throw new IndexOutOfRangeException();
            }

            int i = 0;
            Node p = _root;
            while (p != null)
            {
                if (i == pos)
                {
                    break;
                }
                p = p.next;
                i++;
            }
            return p.value;
        }

        public void Set(int pos, int value)
        {
            if (Size() == 0 || pos > Size() - 1 || pos < 0)
            {
                throw new IndexOutOfRangeException();
            }

            int i = 0;
            Node p = _root;
            while (p != null)
            {
                if (i == pos)
                {
                    p.value = value;
                    break;
                }
                p = p.next;
                i++;
            }
        }
        #endregion

        #region Reverse
        public void Reverse()
        {
            if (_root == null || Size() == 1)
            {
                return;
            }

            Node p = _root;
            Clear();
            while (p != null)
            {
                AddStart(p.value);
                p = p.next;
            }
        }

        public void HalfReverse()
        {
            if (_root == null || Size() == 1)
            {
                return;
            }

            Node p = _root;
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
                    AddEnd(p.value);
                }

                p = p.next;
                i++;
            }
            p = start;

            if (delta == 1)
            {
                for (int j = 0; j < halfSize; ++j)
                {
                    p = p.next;
                }
                AddEnd(p.value);
                p = start;
            }

            for (int j = 0; j < halfSize && p != null; ++j)
            {
                AddEnd(p.value);
                p = p.next;
            }
        }
        #endregion

        #region Min & Max
        public int Min()
        {
            Node p = _root;
            for (int i = 0; i < IndMin(); ++i)
            {
                p = p.next;
            }

            return p.value;
        }

        public int Max()
        {
            Node p = _root;
            for (int i = 0; i < IndMax(); ++i)
            {
                p = p.next;
            }

            return p.value;
        }

        public int IndMin()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Size() == 1)
            {
                return 0;
            }

            int i = 1;
            int index = 0;
            int min = _root.value;
            Node p = _root.next;
            while (p != null)
            {
                if (min > p.value)
                {
                    index = i;
                }
                p = p.next;
                i++;
            }

            return index;
        }

        public int IndMax()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Size() == 1)
            {
                return 0;
            }

            int i = 1;
            int index = 0;
            int max = _root.value;
            Node p = _root.next;
            while (p != null)
            {
                if (max < p.value)
                {
                    index = i;
                }
                p = p.next;
                i++;
            }

            return index;
        }
        #endregion

        #region Sort
        public void Sort()
        {
            if (_root == null || Size() == 1)
            {
                return;
            }

            Node p = new Node(DelPos(IndMin()));
            Node start = p;

            while (_root != null)
            {
                p.next = new Node(DelPos(IndMin()));
                p = p.next;
            }
            _root = start;
        }
        #endregion

    }
}
