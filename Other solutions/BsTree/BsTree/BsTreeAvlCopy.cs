using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsTree
{
    public class BsTreeAvlCopy: Node 
    {
        public BsTreeAvlCopy() { }
        public BsTreeAvlCopy(int val)
        {
            this.val = val;
        }
        
        override public void Add(int val)
        {
            if (root == null)
            {
                root = new BsTreeAvlCopy(val);
                return;
            }
            Insert(root, val);
        }
        private Node Insert(Node p, int val)
        {
            if (p == null)
            {
                Node q = new BsTreeAvlCopy(val);
                q.height = 1;
                return q;
            }
            if (val < p.val)
                p.left = Insert(p.left, val);
            else
                p.right = Insert(p.right, val);
            return Balance(p);
        }

        int balanceFactor(Node p)
        {
            if (p == null)
            {
                return 0;
            }
            int r = p.right != null ? p.right.height : 0;
            int l = p.left != null ? p.left.height : 0;
            return r - l;
        }

        void fixHeigth(Node p)
        {
            if (p == null)
            {
                return;
            }
            if (p.right == null)
            {
                if (p.left == null)
                {
                    p.height = 1;
                }
                else
                {
                    p.height = (byte)(p.left.height + 1);
                }
            }
            else if (p.left == null)
            {
                p.height = (byte)(p.right.height + 1);
            }
            else
            {
                p.height = (byte)(Math.Max(p.left.height, p.right.height) + 1);
            }
        }

        Node rotateRight(Node p)
        {
            Node q = p.left;
            p.left = q.right;
            q.right = p;
            fixHeigth(p);
            fixHeigth(q);
            return q;
        }

        Node rotateLeft(Node p)
        {
            Node q = p.right;
            p.right = q.left;
            q.left = p;
            fixHeigth(p);
            fixHeigth(q);
            return q;
        }

        Node Balance(Node p)
        {
            fixHeigth(p);
            if (balanceFactor(p) == 2)
            {
                if (balanceFactor(p.right) < 0)
                    p.right = rotateRight(p.right);
                return rotateLeft(p);
            }
            if (balanceFactor(p) == -2)
            {
                if (balanceFactor(p.left) > 0)
                    p.left = rotateLeft(p.left);
                return rotateRight(p);
            }
            return p;
        }

       private Node RemoveMin(Node p)
        {
            if (p.left == null)
                return p.right;
            p.left = RemoveMin(p.left);
            return Balance(p);
        }

        Node findMin(Node p)
        {
            if (p.left == null)
                return p;
            else
            {
                p.left = findMin(p.left);
                return Balance(p);
            }
        }

        public override void Del(int val)
        {
            if (root == null)
                return;
            
            root = Remove(root, val);
        }
        public Node Remove(Node p, int val)
        {
            if (p == null) return null;
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
            return Balance(p);
        }
        private Node FindMin(Node node)
        {
            return node.left != null ? FindMin(node.left) : node;
        }
    }
}
