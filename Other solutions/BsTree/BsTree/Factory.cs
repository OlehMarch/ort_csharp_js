using System;
using System.Collections;

using static BsTree.BsTreeVisitor;

namespace BsTree
{
    public abstract class Node : IBsTree
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
        public nodeColor color;
        public int height;
        public Node() { }
       
        override public bool Equals(Object p)
        {
            return Equals(this.root, ((BsTreeAvl)p).root);
        }

        private bool Equals(Node r, Node p)
        {
            if ((r == null && p != null) || (r != null && p == null))
                return false;

            if (r == null && p == null)
                return true;

            if (r.val != p.val)
                return false;

            return Equals(r.left, p.left) && Equals(r.right, p.right);
        }


        public bool isRed = true;

        public Node root = null;
    
        public abstract void Add(int val);

        public abstract void Del(int val);

     /*   #region Enumeration
        private int index = -1;
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
            this.index = -1;
        }

        public object Current
        {
            get
            {
                return this[index];
            }
        }

        private int this[int index]
        {
            get
            {
                int result = 0;
                int inIndex = 0;
                NodeToEnumerator(root, ref result, ref inIndex, index);
                return result;
            }
        }
        private void NodeToEnumerator(Node node, ref int result, ref int index, int compareToIndex)
        {
            if (node == null)
                return;

            NodeToEnumerator(node.left, ref result, ref index, compareToIndex);
            if (index == compareToIndex)
            {
                index++;
                result = node.val;
                return;
            }
            index++;
            NodeToEnumerator(node.right, ref result, ref index, compareToIndex);
        }
        #endregion*/

        public void Clear()
        {
            root = null;
        }

        private void LVR(Node p, Visitor v)
        {
            if (p == null)
                return;

            LVR(p.left, v);
            v.Action(p);
            LVR(p.right, v);
        }

        private void VLR(Node p, Visitor v)
        {
            if (p == null)
                return;

            v.Action(p);
            VLR(p.left, v);
            VLR(p.right, v);
        }
        
        public void Init(int[] ini)
        {
            root = null;
            if (ini == null || ini.Length == 0)
                return;

            for (int i = 0; i < ini.Length; i++)
            {
                Add(ini[i]);
            }
        }
        
        public int Size()
        {
            VSize vv = new VSize();
            LVR(root, vv);
            return vv.size;
        }
        
        public int Nodes()
        {
            VNodes vv = new VNodes();
            LVR(root, vv);
            return vv.size;
        }

        public int Height()
        {
            return HeightNode(root);
        }
        private int HeightNode(Node p)
        {
            if (p == null)
                return 0;
            return 1 + Math.Max(HeightNode(p.left), HeightNode(p.right));
        }
        
        public int[] ToArray()
        {
            VArray vv = new VArray(Size());
            LVR(root, vv);
            return vv.dat;
        }
        
        override public String ToString()
        {
            VString v = new VString();
            LVR(root, v);
            return v.str;
        }
        
        public int Leaves()
        {
            VLeaves v = new VLeaves();
            VLR(root, v);
            return v.size;
        }

        private void Width(Node p, int[] vv, int i)
        {
            if (p == null)
                return;

            Width(p.left, vv, i + 1);
            vv[i]++;
            Width(p.right, vv, i + 1);
        }

        public int Width()
        {
            int[] vv = new int[Height()];
            Width(root, vv, 0);
            return Max(vv);
        }

        private int Max(int[] ar)
        {
            if (ar.Length == 0)
                return 0;

            int max = ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                if (ar[i] > max)
                    max = ar[i];
            }
            return max;
        }

        public void Reverse()
        {
            VReverse v = new VReverse();
            VLR(root, v);
        }
    }
}
