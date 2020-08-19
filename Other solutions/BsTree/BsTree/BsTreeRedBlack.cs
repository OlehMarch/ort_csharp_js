using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsTree
{
    
    public enum nodeColor { BLACK, RED }
    public class BsTreeRedBlack : Node
    {
        public BsTreeRedBlack() {
            this.val = 0;
            this.left = null;
            this.right = null;
            this.parent = null;
        }
        public BsTreeRedBlack(int val)
        {
            this.val = val;
            this.left = null;
            this.right = null;
            this.parent = null;
        }
   
        private void LeftRotate(Node x)
        {
            Node y = x.right;
            x.right = y.left;

            if (y.left != null)
            {
                y.left.parent = x;
            }
            y.parent = x.parent;
            if (x.parent == null)
            {
                root = y;
            }
            else if (x == x.parent.left)
            {
                x.parent.left = y;
            }
            else
            {
                x.parent.right = y;
            }
            y.left = x;
            x.parent = y;
        }

        private void RightRotate(Node y)
        {
            Node x = y.left;
            y.left = x.right;

            if (x.right != null)
            {
                x.right.parent = y;
            }
            x.parent = y.parent;
            if (y.parent == null)
            {
                root = x;
            }
            else if (y == y.parent.right)
            {
                y.parent.right = x;
            }
            else
            {
                y.parent.left = x;
            }
            x.right = y;
            y.parent = x;
        }

        override public void Add(int val)
        {
            Node newItem = new BsTreeRedBlack(val);
            if (root == null)
            {
                root = newItem;
                root.color = nodeColor.BLACK;
                return;
            }
            Node Y = null;
            Node X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.val < X.val)
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }
            newItem.parent = Y;
            if (Y == null)
            {
                root = newItem;
            }
            else if (newItem.val < Y.val)
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }
            newItem.left = null;
            newItem.right = null;
            newItem.color = nodeColor.RED;
             InsertFixUp(newItem);
           // balance(newItem);
        }

        private void InsertFixUp(Node item)
        {
            while (item!=null && item.parent.color == nodeColor.RED)//item!=root item.parent != root && //RED
            {
                if (item.parent == item.parent.parent.left)//item.parent
                {
                    Node Y = item.parent.parent.right;
                    if (Y != null && Y.color == nodeColor.RED) //del Y
                    {
                        item.parent.color = nodeColor.BLACK;
                        Y.color = nodeColor.BLACK;
                        item.parent.parent.color = nodeColor.RED;
                        item = item.parent.parent;
                        return;
                    }
                    else
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item); //add parent 
                        }
                        item.parent.color = nodeColor.BLACK;
                        item.parent.parent.color = nodeColor.RED;
                        RightRotate(item.parent);
                    }
                }
                else
                {
                    if (item.parent == item.parent.parent.right)//add if
                    {
                        Node X = item.parent.parent.left;
                        if (X != null && X.color == nodeColor.BLACK)
                        {
                            item.parent.color = nodeColor.RED;
                            X.color = nodeColor.RED;
                            item.parent.parent.color = nodeColor.BLACK;
                            item = item.parent.parent;
                        }
                        else
                        {
                            if (item == item.parent.left)
                            {   
                                item = item.parent;
                                RightRotate(item);//add parent
                            }
                            item.parent.color = nodeColor.BLACK;
                            item.parent.parent.color = nodeColor.RED;
                            LeftRotate(item.parent.parent);
                        }
                    }
                }
                root.color = nodeColor.BLACK;
            }
        }
        
        override public void Del(int val)
        {
            if (root == null)
                return;

            root = delete(root, val);
            if (!(root == null))
                root.color = nodeColor.BLACK;
        }
        
        private Node moveRedLeft(Node h)
        {
            flipColors(h);
            if (IsRed(h.right.left))
            {
                h.right = rotateRight(h.right);
                h = rotateLeft(h);
                flipColors(h);
            }
            return h;
        }
        private Node moveRedRight(Node h)
        {
            flipColors(h);
            if (IsRed(h.left.left))
            {
                h = rotateRight(h);
                flipColors(h);
            }
            return h;
        }
        private Node delete(Node h, int val)
        {
            if (val < h.val)
            {
                if (!IsRed(h.left) && !IsRed(h.left.left))
                {
                    h = moveRedLeft(h);
                }

                h.left = delete(h.left, val);
            }
            else
            {
                if (IsRed(h.left))
                    h = rotateRight(h);
                if (val == h.val && (h.right == null))
                    return null;
                if (!IsRed(h.right) && !IsRed(h.right.left))
                    h = moveRedRight(h);
                if (val == h.val)
                {
                    Node x = MinValue(ref h.right);
                    h.val = x.val;
                    h.right = deleteMin(h.right);
                }
                else h.right = delete(h.right, val);
            }
            return balance(h);
        }
        private Node balance(Node h)
        {
            if (IsRed(h.right)) h = rotateLeft(h);
            if (IsRed(h.left) && IsRed(h.left.left)) h = rotateRight(h);
            if (IsRed(h.left) && IsRed(h.right)) flipColors(h);
            h.color = nodeColor.BLACK;
            return h;
        }
        private Node deleteMin(Node h)
        {
            if (h.left == null)
                return null;

            if (!IsRed(h.left) && !IsRed(h.left.left))
                h = moveRedLeft(h);

            h.left = deleteMin(h.left);
            return balance(h);
        }
        private Node rotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = x.right.color;
            x.right.color = nodeColor.RED;
            return x;
        }

        private Node rotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.color = x.left.color;
            x.left.color = nodeColor.RED;
            return x;
        }
        private Node DeleteMin(Node h)
        {
            if (h.left == null)
                return null;

            if (!IsRed(h.left) && !IsRed(h.left.left))
                h = moveRedLeft(h);

            h.left = DeleteMin(h.left);
            return Balance(h);
        }

        private Node Balance(Node h)
        {
            if (IsRed(h.right))
            {
                LeftRotate(h);
            }
            if (IsRed(h.left) && IsRed(h.left.left))
            {
                RightRotate(h);
            }
            if (IsRed(h.left) && IsRed(h.right))
            {
                flipColors(h);
            }
            return h;
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

        private Node MoveRedRight(Node h)
        {
            flipColors(h);
            if (IsRed(h.right.left))
            {
                h.right = rotateRight(h.right);
                h = rotateLeft(h);
                flipColors(h);
            }
            return h;
        }
  
        private bool IsRed(Node x)
        {
            return x != null && x.color == nodeColor.RED;
        }

        private void flipColors(Node h)
        {
            h.color = ~h.color;
            h.left.color = ~h.left.color;
            h.right.color = ~h.right.color;
        }
    }
}
