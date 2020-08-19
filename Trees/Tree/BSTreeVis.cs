using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_02
{
    public class BSTreeVis : ITree
    {
        class Node
        {
            public int value;
            public Node left;
            public Node right;
            public Node(int val)
            {
                this.value = val;
            }
        }

        public BSTreeVis()
        {
            _root = null;
        }

        Node _root = null;

        #region Visitor
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

        private class VSize : Visitor
        {
            public int size = 0;
            public void Action(Node p)
            {
                size++;
            }
        }
        private class VNodes : Visitor
        {
            public int nodes = 0;
            public void Action(Node p)
            {
                if (p.left != null || p.right != null)
                {
                    nodes++;
                }
            }
        }
        private class VLeaves : Visitor
        {
            public int leaves = 0;
            public void Action(Node p)
            {
                if (p.left == null && p.right == null)
                {
                    leaves++;
                }
            }
        }
        private class VString : Visitor
        {
            public string data = "";
            public void Action(Node p)
            {
                data += p.value + " ";
            }
        }
        private class VArray : Visitor
        {
            public int[] array = null;
            private int i = 0;
            public VArray(int size)
            {
                array = new int[size];
            }
            public void Action(Node p)
            {
                array[i++] = p.value;
            }
        }

        public int Size()
        {
            VSize visitor = new VSize();
            Visit(_root, visitor);
            return visitor.size;
        }

        public int Nodes()
        {
            VNodes visitor = new VNodes();
            Visit(_root, visitor);
            return visitor.nodes;
        }

        public int Leaves()
        {
            VLeaves visitor = new VLeaves();
            Visit(_root, visitor);
            return visitor.leaves;
        }

        public override string ToString()
        {
            VString visitor = new VString();
            Visit(_root, visitor);
            return visitor.data.TrimEnd();
        }

        public int[] ToArray()
        {
            VArray visitor = new VArray(Size());
            Visit(_root, visitor);
            return visitor.array;
        }
        #endregion

        #region Crucial
        public void Init(int[] ini)
        {
            _root = null;

            if (ini == null)
            {
                throw new NullReferenceException();
            }

            for (int i = 0; i < ini.Length; i++)
            {
                Add(ini[i]);
            }
        }

        public void Clear()
        {
            _root = null;
        }
        #endregion

        #region Add
        public void Add(int value)
        {
            if (_root == null)
            {
                _root = new Node(value);
                return;
            }
            AddNode(_root, value);
        }

        private void AddNode(Node node, int value)
        {
            if (node.value > value)
            {
                if (node.left == null)
                {
                    node.left = new Node(value);
                }
                else
                {
                    AddNode(node.left, value);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new Node(value);
                }
                else
                {
                    AddNode(node.right, value);
                }
            }
        }
        #endregion

        #region Delete
        public void Delete(int value)
        {
            _root = NodeToDelete(_root, value);
            var temp = _root;
        }

        private Node NodeToDelete(Node node, int value)
        {
            if (node == null)
            {
                return node;
            }
            if (value < node.value)
            {
                node.left = NodeToDelete(node.left, value);
            }
            else if (value > node.value)
            {
                node.right = NodeToDelete(node.right, value);
            }
            else
            {
                if (node.left == null)
                {
                    return node.right;
                }
                else if (node.right == null)
                {
                    return node.left;
                }
                node.value = minValue(node.right);
                node.right = NodeToDelete(node.right, node.value);
            }
            return node;
        }

        private int minValue(Node node)
        {
            int minv = node.value;
            while (node.left != null)
            {
                minv = node.left.value;
                node = node.left;
            }
            return minv;
        }
        #endregion

        #region Reverse
        public void Reverse()
        {
            NodeToReverse(_root);
        }

        private void NodeToReverse(Node node)
        {
            if (node == null)
            {
                return;
            }

            Node temp = node.left;
            node.left = node.right;
            node.right = temp;

            if (node.left != null)
            {
                NodeToReverse(node.left);
            }
            if (node.right != null)
            {
                NodeToReverse(node.right);
            }
        }
        #endregion

        #region Height
        public int Height()
        {
            return HeightNode(_root);
        }

        private int HeightNode(Node p)
        {
            if (p == null)
                return 0;

            return 1 + Math.Max(HeightNode(p.left), HeightNode(p.right));
        }
        #endregion

        #region Width
        public int Width()
        {
            int[] array = new int[Height()];
            if (array.Length == 0)
            {
                return 0;
            }
            WidthNode(_root, array, 0);
            return array.Max();
        }

        private void WidthNode(Node p, int[] array, int index)
        {
            if (p == null)
                return;

            WidthNode(p.left, array, index + 1);
            array[index]++;
            WidthNode(p.right, array, index + 1);
        }
        #endregion

        #region Indexer
        public int this[int index]
        {
            get
            {
                int result = 0;
                int inIndex = 0;
                NodeToEnumerator(_root, ref result, ref inIndex, index);
                return result;
            }
        }

        private void NodeToEnumerator(Node node, ref int result, ref int index, int compareToIndex)
        {
            if (node == null)
            {
                return;
            }

            NodeToEnumerator(node.left, ref result, ref index, compareToIndex);
            if (index == compareToIndex)
            {
                index++;
                result = node.value;
                return;
            }
            index++;
            NodeToEnumerator(node.right, ref result, ref index, compareToIndex);
        }
        #endregion

        #region Equal
        public override bool Equals(object obj)
        {
            var bst = obj as BSTreeVis;
            var size = this.Size();
            if (size != bst.Size() || this.Width() != bst.Width() || this.Height() != bst.Height())
            {
                return false;
            }
            for (int i = 0; i < size; i++)
            {
                if (this[i] != bst[i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

    }
}
