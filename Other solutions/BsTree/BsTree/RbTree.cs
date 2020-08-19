using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsTree
{

    public class RbTree : Node
    {

        public int count;
        public RbTree() { }
        public RbTree(int val)
        {
            this.val = val;
            this.left = null;
            this.right = null;
            this.parent = null;
            this.count = 1;
        }
        public RbTree(int val, Node parent) : this(val)
        {
            this.parent = parent;
        }

        public override void Add(int val)
        {
            if (root == null)
            {
                root = new RbTree(val,root);
            
                //  return;
            }
            else
            {
                root = Add(root, val);
            }
            this.case1(ref root);
        }
        private Node Add(Node to, int val)
        {


            if (val < root.val)
            {
                if (to.left != null)
                {
                    return Add(to.left, val);
                }
                return to.left = new RbTree(val, to);
            }
            else
            {
                if (to.right != null)
                {
                    return this.Add(to.right, val);
                }
                return to.right = new RbTree(val, to);
            }
        }

        public override void Del(int val)
        {
            throw new NotImplementedException();
        }


        protected void case1(ref Node n)
        {
            if (n.parent == null)
            {
                n.isRed = false;
                return;
            }
            this.case2(ref n);
        }
        protected void case2(ref Node n)
        {
            if (n.parent.isRed == false)
            {
                n.isRed = true;
                return;
            }
            else
            {
                this.case3(ref n);
            }

        }
        protected void case3(ref Node n)
        {
            Node u = this.uncle(n);
            Node g = this.grandparent(n);
            if ((u != null) && (u.isRed == true))
            {
                n.parent.isRed = false;
                u.isRed = false;
                g.isRed = true;
                this.case1(ref g);
            }
            else
            {
                this.case4(ref n);
            }
        }
        protected void case4(ref Node n)
        {
            Node g = this.grandparent(n);
            if (g == null)
                return;
            if ((n == n.parent.right) && (n.parent == g.left))
            {
                this.rotate_left(ref n);
                //n = n.left;
            }
            else if ((n == n.parent.left) && (n.parent == g.right))
            {
                rotate_right(ref n);
                //n = n.right;
            }

            n.parent.isRed = false;
            g.isRed = true;

            if ((n == n.parent.left) && (n.parent == g.left))
            {
                this.rotate_right(ref g);
            }
            else
            {
                this.rotate_left(ref g);
            }
        }

        protected void rotate_right(ref Node n)
        {
            if (n.parent == null)
                return;

            if (n.left != null)
            {
                n.parent.left = n.right;
                n.parent.left.parent = n.parent;
            }
            else
            {
                n.parent.left = null;
            }

            n.right = n.parent;
            n.parent = n.parent.parent;

            n.right.parent = n;

            if (n.parent != null)
            {
                if (n.parent.left == n.left)
                    n.parent.left = n;
                if (n.parent.right == n.left)
                    n.parent.right = n;
            }
            else
            {
                this.root = n;
            }
        }

        protected void rotate_left(ref Node n)
        {
            if (n.parent == null)
                return;

            if (n.left != null)
            {
                n.parent.right = n.left;
                n.parent.right.parent = n.parent;
            }
            else
            {
                n.parent.right = null;
            }

            n.left = n.parent;
            n.parent = n.parent.parent;

            n.left.parent = n;

            if (n.parent != null)
            {
                if (n.parent.left == n.left)
                    n.parent.left = n;
                if (n.parent.right == n.left)
                    n.parent.right = n;
            }
            else
            {
                this.root = n;
            }
        }

        protected Node grandparent(Node n)
        {
            if ((n != null) && (n.parent != null))
                return n.parent.parent;
            else
                return null;
        }

        protected Node uncle(Node n)
        {
            Node g = grandparent(n);
            if (g == null)
                return null;

            if (n.parent == g.left)
            {
                return g.right;
            }
            else
            {
                return g.left;
            }
        }
    }
}
