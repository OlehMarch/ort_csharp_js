using List;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List 
{
    public class LList2 : IList, IEnumerable, IEnumerator
    {
        int index = -1;
        public object Current
        {
            get
            {
                return this[index];
            }
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (index >= Size() - 1)
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
        private int this[int index]
        {
            get
            {
                int ind = 0;
                Node tmp = root;
                while(tmp.next != null)
                {
                    if(ind == index)
                    {
                        ind++;
                        return tmp.val;
                    }
                    tmp = tmp.next;
                    ind++;
                }
                return tmp.val;
            }
        }
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
        Node last = null;
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
            last = null;
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
            if (root == null)
            {
                root = tmp;
                last = tmp;
            }
            else
            {
                tmp.next = root;
                root.prev = tmp;
                root = tmp;
            }
        }
        public void AddEnd(int val)
        {
            Node tmp = new Node(val);
            if (root == null)
            {
                root = tmp;
                last = root;
            }
            else
            {
                tmp.prev = last;
                last.next = tmp;
                last = tmp;
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
                root = p;
                last = root;
                return;
            }
            if (pos == Size())
            {
                AddEnd(val);
            }
            else
            {
                for (int i = 1; i < pos; i++)
                {
                    tmp = tmp.next;
                }
                p.next = tmp.next;
                p.prev = tmp;
                tmp.next.prev = p;
                tmp.next = p;
            }
        }
        public int DelEnd()
        {

            int res = last.val;
            if (root.next == null)
            {
                last = root = null;
            }
            else
            {
                last.prev.next = null;
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
            if (root == null || 0 > pos || pos > Size())
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
            if (pos > Size() || pos < 0)
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
            Node current = root;
            Node temp = null;
            while (current != null)
            {
                temp = current.prev;
                current.prev = current.next;
                current.next = temp;
                current = current.prev;
            }
            if (temp != null)
                root = temp.prev;
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
            if (root == null || root.next == null)
            {
                return;
            }
            int size = Size();
            if (size <= 2)
            {
                Reverse();
                return;
            }
            Node tmp = root;
            Node mid = null;
            Node oddMid = null;
            int i = 0;
            while (tmp.next != null)
            {
                if (i == size / 2)
                {
                    if (size % 2 == 0)
                    {
                        mid = tmp;
                        last = mid.prev;
                        mid.prev.next = null;
                        mid.prev = null;
                    }
                    else
                    {
                        oddMid = tmp;
                        mid = tmp.next;
                        last = oddMid.prev;
                        last.next = null;
                        mid.prev = null;
                        oddMid.next = root;
                        oddMid.prev = null;
                        root.prev = oddMid;
                        root = oddMid;
                    }
                    tmp = mid;
                }
                tmp = tmp.next;
                i++;
            }
            tmp.next = root;
            root.prev = tmp;
            root = mid;
        }
        public void Sort()
        {
            if (root == null)
            {
                return;
            }
            Node sorter = root;
            Clear();
            while (sorter != null)
            {
                int maxValue = sorter.val;
                Node maxValNode = sorter;
                Node p = sorter;
                while (p != null)
                {
                    if (p.val > maxValue)
                    {
                        maxValue = p.val;
                        maxValNode = p;
                    }
                    p = p.next;
                }
                if (maxValNode.prev != null)
                {
                    maxValNode.prev.next = maxValNode.next;
                }
                else
                {
                    sorter = maxValNode.next;
                }
                if (maxValNode.next != null)
                {
                    maxValNode.next.prev = maxValNode.prev;
                }
                maxValNode.prev = null;
                maxValNode.next = root;
                root = maxValNode;
            }
            sorter = root;
            while (sorter.next != null)
            {
                sorter = sorter.next;
            }
            last = sorter;
        }


    }
}
