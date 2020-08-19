using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsTree
{
    class MyIterator : BsTree, IEnumerator 
    {

        private interface Visitor
        {
            void Action(Node p);
        }
        private void Visit(Node p, Visitor v)
        {
            if (p == null)
                return;

            Visit(p.left, v);
            v.Action(p);
            Visit(p.right, v);
        }
        BsTree tree;
        int index = -1;
        public MyIterator(BsTree tr)
        {
            tree = tr;
        }
        public object Current
        {
            get
            {
                return this[index];
            }
        }

        public bool MoveNext()
        {
            if (index == tree.Size() - 1)
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
                EnumeratorVisitor ev = new EnumeratorVisitor(0, index, 0);
                Visit(tree.root, ev);
                return ev.result;
            }
        }
        private class EnumeratorVisitor : Visitor
        {
            int index;
            int compareToIndex;
            public int result;
            public EnumeratorVisitor(int index, int compareToIndex, int result)
            {
                this.index = index;
                this.compareToIndex = compareToIndex;
                this.result = result;
            }
            public void Action(Node p)
            {
                if (index == compareToIndex)
                {
                    index++;
                    result = p.val;
                    return;
                }
                index++;
            }
        }
    }
   /* public IEnumerator GetEnumerator()
    {
        return new MyIterator(this);
    }*/

}
