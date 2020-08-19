using System;


namespace BsTree
{
    public class BsTreeVisitor
    {
        public interface Visitor
        {
            void Action(Node p);
        }
        public class VReverse : Visitor
        {
            public void Action(Node p)
            {
                Node temp = p.left;
                p.left = p.right;
                p.right = temp;
            }
        }
        public class VSize : Visitor
        {
            public int size = 0;
            public void Action(Node p)
            {
                size++;
            }
        }
        public class VNodes : Visitor
        {
            public int size = 0;
            public void Action(Node p)
            {
                if (p.left != null || p.right != null)
                    size++;
            }
        }
        public class VArray : Visitor
        {
            public int[] dat = null;
            int i = 0;
            public VArray(int size)
            {
                dat = new int[size];
            }
            public void Action(Node p)
            {
                dat[i++] = p.val;
            }
        }

        public class VString : Visitor
        {
            public String str = "";
            public void Action(Node p)
            {
                str += p.val + ", ";
            }
        }
        public class VLeaves : Visitor
        {
            public int size = 0;
            public void Action(Node p)
            {
                if (p.left == null && p.right == null)
                    size++;
            }
        }
       
    }
}
