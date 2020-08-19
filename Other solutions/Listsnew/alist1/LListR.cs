using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class LListR : IList
    {
        class Node
        {
            public int val;
            public Node next;
            public Node prev;
            public Node(int val)
            {
                this.val = val;
            }
        }
        Node root = null;
        public void Init(int[] arr)
        {
            Clear();
            if (arr == null || arr.Length == 0)
                return;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                AddStart(arr[i]);
            }
        }
        public void Clear()
        {
            root = null;
        }
        public int Size()
        {
            int ret = 0;
            Node p = root;
            if (p == null)
            {
                return ret;
            }
            do
            {
                ret++;
                p = p.next;
            }
            while (p != root);
            return ret;
        }
        public void AddStart(int val)
        {
            Node tmp = new Node(val);
            if (root == null)
            {
                tmp.next = tmp;
                tmp.prev = tmp;
                root = tmp;
            }
            else
            {
                tmp.prev = root.prev;
                tmp.next = root;
                root.prev.next = tmp;
                root.prev = tmp;
                root = tmp;
            }
        }
        public void AddEnd(int val)
        {
            Node tmp = new Node(val);
            if (root == null)
            {
                tmp.next = tmp;
                tmp.prev = tmp;
                root = tmp;
            }
            else
            {
                tmp.next = root;
                tmp.prev = root.prev;
                root.prev.next = tmp;
                root.prev = tmp;

            }
        }
        public void AddPos(int pos, int val)
        {
            if (pos > Size() || 0 > pos)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = root;
            Node p = new Node(val);
            if (root == null)
            {
                p.next = p;
                p.prev = p;
                root = p;
                return;
            }
            for (int i = 0; i < pos; i++)
            {
                tmp = tmp.next;
            }
            p.next = tmp;
            p.prev = tmp.prev;
            tmp.prev.next = p;
            tmp.prev = p;

        }
        public int DelEnd()
        {
            int res = root.prev.val;
            if (root == root.next)
            {
                root = null;
            }
            else
            {
                root.prev = root.prev.prev;
                root.prev.next = root;
            }
            return res;
        }
        public int DelPos(int pos)
        {
            if (pos > Size() || pos < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int res;
            if (root == root.next)
            {
                res = root.val;
                root = null;
            }
            else
            {
                Node tmp = root;
                for (int i = 0; i < pos; i++)
                {
                    tmp = tmp.next;
                }
                res = tmp.val;
                tmp.prev.next = tmp.next;
                tmp.next.prev = tmp.prev;
            }
            return res;
        }
        public int DelStart()
        {
            int res = root.val;
            if (root == root.next)
            {
                root = null;
            }
            else
            {
                root.next.prev = root.prev;
                root.prev.next = root.next;
                root = root.next;
            }
            return res;
        }
        public int Get(int pos)
        {
            if (root == null || pos < 0 || pos > Size())
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = root;
            for (int i = 0; i < pos; i++)
            {
                tmp = tmp.next;
            }
            return tmp.val;
        }
        public void Set(int pos, int val)
        {
            if (root == null || pos < 0 || pos > Size())
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = root;
            for (int i = 0; i < pos; i++)
            {
                tmp = tmp.next;
            }
            tmp.val = val;
        }
        public override string ToString()
        {
            string res = "";
            if (root == null)
            {
            }
            else
            {
                Node tmp = root;
                while (tmp != root.prev)
                {
                    res += tmp.val + " ";
                    tmp = tmp.next;
                }
                res += tmp.val;
            }
            return res;
        }
        public int IndMax()
        {
            int ind = 0;
            int val = root.val;
            Node tmp = root;

            for (int i = 1; i < Size(); i++)
            {
                tmp = tmp.next;
                if (val < tmp.val)
                {
                    val = tmp.val;
                    ind = i;
                }
            }
            return ind;
        }

        public int IndMin()
        {
            int ind = 0;
            int val = root.val;
            Node tmp = root;

            for (int i = 1; i < Size(); i++)
            {
                tmp = tmp.next;
                if (val > tmp.val)
                {
                    val = tmp.val;
                    ind = i;
                }
            }
            return ind;
        }
        public int Max()
        {
            return Get(IndMax());
        }
        public int Min()
        {
            return Get(IndMin());
        }
        public int[] ToArray()
        {
            int[] ret = new int[Size()];
            if (root == null)
            {
                return ret;
            }
            int i = 0;
            Node p = root;
            while (p != root.prev)
            {
                ret[i++] = p.val;
                p = p.next;
            }
            ret[i] = p.val;
            return ret;
        }
        public void Sort()
        {
            if (root == null)
            {
                throw new ArgumentException();
            }
            int length = Size();
            if (length == 1)
            {
                return;
            }

            Node p = new Node(DelPos(IndMin()));
            Node start = p;

            while (root != null)
            {
                p.next = new Node(DelPos(IndMin()));
                p = p.next;
            }

            Node tempBegin = start;
            while (tempBegin.next != null)
            {
                tempBegin.next.prev = tempBegin;
                tempBegin = tempBegin.next;
            }
            tempBegin.next = start;
            start.prev = tempBegin;

            root = new Node(0);
            root.next = start;
        }

        public void Reverse()
        {
            if (root == null || root.next == root)
                return;
            Node next = null;
            Node end = root;
            do
            {
                Node temp = root; 
                root = root.next;
                temp.next = next;
                temp.prev = root;
                next = temp;
            }
            while (root != end);
            root = next;
            end.next = root;
            root.prev = end;
        }
        public void HalfReverse()
        {
            if (root == null)
            {
                throw new ArgumentException();
            }

            int[] arr = ToArray();

            int dx = arr.Length % 2 == 0 ? 0 : 1;

            for (int i = 0; i < arr.Length / 2; ++i)
            {
                var temp = arr[i];
                arr[i] = arr[arr.Length / 2 + i + dx];
                arr[arr.Length / 2 + i + dx] = temp;
            }

            Clear();
            Init(arr);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
