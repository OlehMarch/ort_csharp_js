using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsTree
{
    public class BsTreeAvl : Node
    {
        public BsTreeAvl() { }
        public BsTreeAvl(int val)
        {
            this.val = val;
        }

        override public void Add(int val)
        {
            Node newItem = new BsTreeAvl(val);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = Add(root, newItem);
            }
        }

        private Node Add(Node p, Node n)
        {
            if (p == null)
            {
                p = n;
                return p;
            }
            if (n.val < p.val)
            {
                p.left = Add(p.left, n);
            }
            else
            {
                p.right = Add(p.right, n);
            }
            return BalanceTree(p);
        }
      
        private Node BalanceTree(Node p)
        {
            int BFactor = BalancFactor(p);
            if (BFactor == 2)
            {
                if (BalancFactor(p.left) > 0)
                {
                    p = RotateLL(p);
                }
                else
                {
                    p = RotateLR(p);
                }
            }
            else if (BFactor == -2)
            {
                if (BalancFactor(p.right) > 0)
                {
                    p = RotateRL(p);
                }
                else
                {
                    p = RotateRR(p);
                }
            }
            return p;
        }

        private int BalancFactor(Node p)
        {
            return HeightNode(p.left) - HeightNode(p.right);
        }

        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }

        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }

        private Node RotateLR(Node parent)
        {
            parent.left = RotateRR(parent.left);
            return RotateLL(parent);
        }

        private Node RotateRL(Node parent)
        {
            parent.right = RotateLL(parent.right);
            return RotateRR(parent);
        }

        override public void Del(int val)
        {
            if (root == null)
                return;

            root = Del(root, val);
        }

        private Node Del(Node p, int val)
        {
            if (val < p.val)
            {
                p.left = Del(p.left, val);
            }
            else if (val > p.val)
            {
                p.right = Del(p.right, val);
            }
            else if( val == p.val )
            {
                if (p.right == null)
                    return p.left;

                Node tmp = FindMin(p.left);
                p.val = tmp.val;
                p.left = Del(p.left, tmp.val);
            }
            return BalanceTree(p);
        }
     
        private Node FindMin(Node node)
        {
            return node.right != null ? FindMin(node.right) : node;
        }
       
    }
}