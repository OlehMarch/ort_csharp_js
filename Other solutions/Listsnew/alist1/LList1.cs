using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
  public class LList1 : IList
    {
        class Node
        {
            public int val;
            public Node next;
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
            while (p != null)
            {
                ret++;
                p = p.next;
            }
            return ret;
        }
        public void AddStart(int val)
        {
            Node tmp = new Node(val);
            tmp.next = root;
            root = tmp;
        }
        public void AddEnd(int val)
        {
            if (root == null)
            {
                root = new Node(val);
                return;
            }
            Node tmp = root;
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            tmp.next = new Node(val);   
        }

        public void AddPos(int pos, int val)
        {
            if (Size() < pos || pos<0)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = root;
            Node p = new Node(val);
            if (root == null)
            {
                root = p;
                return;
            }
            for (int i = 1; i < pos; i++)
            {
                tmp = tmp.next;
            }
            Node prev = tmp.next;
            tmp.next = p;
            p.next = prev;
        }
        // переделать
        public int DelEnd()
        {
            int res = 0;
            Node tmp = root, 
                last = null;
            if (root.next == null)
            {
                res = tmp.val;
                root = null;
                return res;
            }
            while (root.next != null)
            {
                last = root;
                root = root.next;
            }
            res = last.next.val;
            last.next = null;
            root = tmp;
            return res;
        }

        public int DelPos(int pos)
        {
             if (Size() < pos || pos < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int res;
            Node tmp = root;
            if (root.next == null || pos == 0)
            {
                res = tmp.val;
                root = root.next;
                return res;
            }
            for (int i = 1; i < pos; i++)
            {
                root = root.next;
            }
            res = root.next.val;
            root.next = root.next.next;
            root = tmp;
            return res;
        }

        public int DelStart()
        {
            if (root ==null)
            {
                throw new NullReferenceException();
            }
            int result = root.val;
            root = root.next;
            return result;
        }
        public int[] ToArray()
        {
            int[] ret = new int[Size()];
            int i = 0;
            Node p = root;
            while (p != null)
            {
                ret[i++] = p.val;
                p = p.next;
            }
            return ret;
        }
        public int Get(int pos)
        {
            if (root == null || pos<0 || pos > Size())
            {
                throw new IndexOutOfRangeException();
            }
            int res;
            Node tmp = root;
            if (tmp.next == null || pos == 0)
            {
                res = tmp.val;
                return res;
            }
            for (int i = 1; i < pos; i++)
            {
                tmp = tmp.next;
            }
            res = tmp.next.val;
            return res;
        }
        public void Set(int pos, int val)
        {
            if (Size() < pos || pos<0)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = root;
            if (tmp.next == null)
            {
                tmp.val = val;
                return;
            }
            for (int i = 1; i < pos; i++)
            {
                tmp = tmp.next;
            }
            tmp.next.val = val;
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
            int val = root.val;
            Node tmp = root;
            for (int i = 1; i < Size(); i++)
            {
                tmp = tmp.next;
                if (val < tmp.val)
                {
                    val = tmp.val;
                }
            }
            return val;
        }

        public int Min()
        {
            int val = root.val;
            Node tmp = root;
            for (int i = 1; i < Size(); i++)
            {
                tmp = tmp.next;
                if (val > tmp.val)
                {
                    val = tmp.val;
                }
            }
            return val;
        }

        public void Reverse()
        {
            Node n = null;
            while (root != null)
            {
                Node tmp = root;
                root = root.next;
                tmp.next = n;
                n = tmp;
            }
            root = n;
        }
        public override string ToString()
        {
            string res = "";
            Node tmp = root;
            while (tmp != null)
            {
                res += tmp.val;
                if (tmp.next != null) res += " ";
                tmp = tmp.next;
            }
            return res;
        }
        public void HalfReverse()
        {
            if (root == null || root.next==null)
            {
                return;
            }
            int[] mas = new int[Size()];
            if (Size() > 1)
            {
                Node tmp = root;
                for (int i = 0; i < Size() / 2; i++)
                {
                    mas[Size() - (Size() / 2) + (i)] = tmp.val;
                    tmp = tmp.next;
                }
                if (Size() % 2 == 1)
                {
                    mas[mas.Length / 2] = tmp.val;
                    tmp = tmp.next;
                }
                int j = 0;
                while (tmp != null)
                {
                    mas[j++] = tmp.val;
                    tmp = tmp.next;
                }
                root = null;
                this.Init(mas);
            }
        }
        public void Sort()
        {

            Node list = root;
            Node node, node2;

            for (node = list; node != null; node = node.next)
                for (node2 = list; node2 != null; node2 = node2.next)
                    if (node.val < node2.val)
                    {
                        int i = node.val;
                        node.val = node2.val;
                        node2.val = i;
                    }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
