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

        private Node Add(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            if (n.val < current.val)
            {
                current.left = Add(current.left, n);
            }
            else
            {
                current.right = Add(current.right, n);
            }
            return BalanceTree(current);
        }
        #region Balance
        
        private Node BalanceTree(Node current)
        {

            int BFactor = BalancFactor(current);
            if (BFactor == 2)
            {
                if (BalancFactor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (BFactor == -2)
            {
                if (BalancFactor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        private int BalancFactor(Node p)
        {
            int l = getHeight(p.left);
            int r = getHeight(p.right);
            int b_factor = l - r;
            return b_factor;
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
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }
        #endregion

        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = l > r ? l : r;
                height = m + 1;
            }
            return height;
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
                Node l = p.left;
                Node r = p.right;

                if (r == null)
                    return l;
    

                Node min = FindMin(r);
                min.right = RemoveMin(r);
                min.left = l;
                return BalanceTree(min);
            }
            return BalanceTree(p);
        }
        /*   if (p == null) return null;
            if (val < p.val)
                p.left = Remove(p.left, val);
            else if (val > p.val)
                p.right = Remove(p.right, val);
            else //  val == p.val 
            {
                Node l = p.left;
                Node r = p.right;

                if (r == null)
                    return l;

                Node min = findMin(r);
                min.right = RemoveMin(r);
                min.left = l;
                return Balance(min);

            }
            return Balance(p);*/
        private Node RemoveMin(Node p)
        {
            if (p.left == null)
                return p.right;
            p.left = RemoveMin(p.left);
            return BalanceTree(p);
        }
        
        private Node FindMin(Node node)
        { 
            return node.left != null ? FindMin(node.left) : node;
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