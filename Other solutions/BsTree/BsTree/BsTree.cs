using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsTree
{
    public class BsTree : Node
    {
        public BsTree() { }
        public BsTree(int val)
        {
            this.val = val;
        }
     
        override public void Add(int val)
        {
            if (root == null)
            {
                root = new BsTree(val);
                return;
            }
            AddNode(root, val);
        }

        private void AddNode(Node p, int val)
        {
            if (val < p.val)
            {
                if (p.left == null)
                    p.left = new BsTree(val);
                else
                    AddNode(p.left, val);
            }
            else
            {
                if (p.right == null)
                    p.right = new BsTree(val);
                else
                    AddNode(p.right, val);
            }
        }

        override public void Del(int val)
        {
            if (root == null)
                return;

            Console.WriteLine(root.val);
            root = Del(root, val);
        }
        private Node Del(Node r, int v)
        {
            if (r == null)
                return r;

            if (v < r.val)
            {
                r.left = Del(r.left, v);
            }
            else if (v > r.val)
            {
                r.right = Del(r.right, v);
            }
            else
            {
                if (r.left == null && r.right == null)
                {
                    r = null;
                }
                else if (r.left == null)
                {
                    Node tmp = r;
                    r = r.right;
                    tmp = null;
                }
                else if (r.right == null)
                {
                    Node tmp = r;
                    r = r.left;
                    tmp = null;
                }
                else
                {
                    Node tmp = MinValue(ref r.right);
                    r.val = tmp.val;
                    r.right = Del(r.right, tmp.val);
                }
            }
            return r;
        }
        private Node MinValue(ref Node p)
        {
            if (p.left != null)
            {
                return MinValue(ref p.left);
            }
            else
            {
                return p;
            }
        }
    }
}
