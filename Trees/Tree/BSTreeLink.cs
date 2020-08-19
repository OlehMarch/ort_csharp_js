using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_02
{
    public class BSTreeLink : ITree, IEnumerable
    {
        #region Enumeration
        public class TreeEnumerator : IEnumerator
        {
            private int index = -1;
            private int[] nodes;

            public TreeEnumerator(int[] nodes)
            {
                this.nodes = nodes;
            }

            public bool MoveNext()
            {
                if (index >= nodes.Length - 1)
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

            public object Current
            {
                get
                {
                    return nodes[index];
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new TreeEnumerator(ToArray());
        }

        private int NodeToEnumerator(Node node, int index)
        {
            if (node == null)
            {
                throw new NullReferenceException();
            }
            if (index == 0)
            {
                return node.Value;
            }

            int result = 0;
            int localIndex = 0;
            Node temp = node;

            while (true)
            {
                if (localIndex == index)
                {
                    result = temp.Value;
                    break;
                }
                temp.Visited = true;

                if (temp.Left.Next == null && temp.Right.Next == null)
                {
                    temp = temp.Left.Back;
                    continue;
                }
                if (temp.Left.Next != null)
                {
                    if (temp.Left.Next.Visited != true)
                    {
                        localIndex++;
                        temp = temp.Left.Next;
                        continue;
                    }
                    if (temp.Right.Next != null)
                    {
                        if (temp.Right.Next.Visited == true)
                        {
                            temp = temp.Left.Back;
                            continue;
                        }
                    }
                }
                if (temp.Right.Next != null)
                {
                    if (temp.Right.Next.Visited != true)
                    {
                        localIndex++;
                        temp = temp.Right.Next;
                        continue;
                    }
                    if (temp.Left.Next != null)
                    {
                        if (temp.Left.Next.Visited == true)
                        {
                            temp = temp.Left.Back;
                            continue;
                        }
                    }
                }

            }

            SetNodesToDefault(node);
            return result;
        }

        private void SetNodesToDefault(Node node)
        {
            if (node == null)
            {
                return;
            }

            node.Visited = false;
            SetNodesToDefault(node.Left.Next);
            SetNodesToDefault(node.Right.Next);
        }
        #endregion

        private class Link
        {
            public Node Next;
            public Node Back;

            public Link()
            {
                Next = null;
                Back = null;
            }
        }
        private class Node
        {
            public Link Left;
            public Link Right;
            public int Value;
            public bool Visited;

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
                Visited = false;
            }
        }

        private Node _root;


        #region Crucial
        public BSTreeLink()
        {
            _root = null;
        }

        public void Clear()
        {
            _root = null;
        }

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
        #endregion

        #region Add
        public void Add(int value)
        {
            if (_root == null)
            {
                _root = new Node(value);
                _root.Left = new Link();
                _root.Right = new Link();
                return;
            }
            AddNode(_root, null, value);
        }

        private void AddNode(Node node, Node prevNode, int value)
        {
            if (node.Value > value)
            {
                if (node.Left.Next == null)
                {
                    node.Left.Next = new Node(value);
                    node.Left.Back = prevNode;
                    node.Left.Next.Left = new Link();
                    node.Left.Next.Left.Back = node;
                    node.Left.Next.Right = new Link();
                    node.Left.Next.Right.Back = node;
                }
                else
                {
                    AddNode(node.Left.Next, node, value);
                }
            }
            else
            {
                if (node.Right.Next == null)
                {
                    node.Right.Next = new Node(value);
                    node.Right.Back = prevNode;
                    node.Right.Next.Left = new Link();
                    node.Right.Next.Left.Back = node;
                    node.Right.Next.Right = new Link();
                    node.Right.Next.Right.Back = node;
                }
                else
                {
                    AddNode(node.Right.Next, node, value);
                }
            }
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            string str = "";
            NodeToString(_root, ref str);
            return str.TrimEnd();
        }

        private void NodeToString(Node node, ref string strNode)
        {
            if (node == null)
            {
                return;
            }

            NodeToString(node.Left.Next, ref strNode);
            strNode += node.Value + " ";
            NodeToString(node.Right.Next, ref strNode);
        }
        #endregion

        #region ToArray
        class Iterator
        {
            public int i = 0;
        }

        public int[] ToArray()
        {
            int[] temp = new int[Size()];
            NodeToArray(_root, temp, new Iterator());
            return temp;
        }

        private void NodeToArray(Node node, int[] array, Iterator iterator)
        {
            if (node == null)
            {
                return;
            }

            NodeToArray(node.Left.Next, array, iterator);
            array[iterator.i++] = node.Value;
            NodeToArray(node.Right.Next, array, iterator);
        }
        #endregion

        #region Size
        public int Size()
        {
            if (_root == null)
            {
                return 0;
            }
            int size = 0;
            NodeToSize(_root, ref size);
            return size;
        }

        private void NodeToSize(Node node, ref int size)
        {
            if (node == null)
            {
                return;
            }
            size++;
            NodeToSize(node.Left.Next, ref size);
            NodeToSize(node.Right.Next, ref size);
        }
        #endregion

        #region Width & Height
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

            WidthNode(p.Left.Next, array, index + 1);
            array[index]++;
            WidthNode(p.Right.Next, array, index + 1);
        }

        public int Height()
        {
            return HeightNode(_root);
        }

        private int HeightNode(Node p)
        {
            if (p == null)
                return 0;

            return 1 + Math.Max(HeightNode(p.Left.Next), HeightNode(p.Right.Next));
        }
        #endregion

        #region Nodes & Leaves
        public int Nodes()
        {
            int nodes = 0;
            NodeToNodes(_root, ref nodes);
            return nodes;
        }

        private void NodeToNodes(Node node, ref int nodes)
        {
            if (node == null)
            {
                return;
            }

            NodeToNodes(node.Right.Next, ref nodes);
            if (node.Left.Next != null || node.Right.Next != null)
            {
                nodes++;
            }
            NodeToNodes(node.Left.Next, ref nodes);
        }

        public int Leaves()
        {
            int leaves = 0;
            NodeToLeaves(_root, ref leaves);
            return leaves;
        }

        private void NodeToLeaves(Node node, ref int leaves)
        {
            if (node == null)
            {
                return;
            }

            NodeToLeaves(node.Right.Next, ref leaves);
            if (node.Left.Next == null && node.Right.Next == null)
            {
                leaves++;
            }
            NodeToLeaves(node.Left.Next, ref leaves);
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

            Node temp = node.Left.Next;
            node.Left.Next = node.Right.Next;
            node.Right.Next = temp;

            if (node.Left.Next != null)
            {
                NodeToReverse(node.Left.Next);
            }
            if (node.Right.Next != null)
            {
                NodeToReverse(node.Right.Next);
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
            if (value < node.Value)
            {
                node.Left.Next = NodeToDelete(node.Left.Next, value);
            }
            else if (value > node.Value)
            {
                node.Right.Next = NodeToDelete(node.Right.Next, value);
            }
            else
            {
                if (node.Left.Next == null)
                {
                    return node.Right.Next;
                }
                else if (node.Right.Next == null)
                {
                    return node.Left.Next;
                }
                node.Value = minValue(node.Right.Next);
                node.Right.Next = NodeToDelete(node.Right.Next, node.Value);
            }
            return node;
        }

        private int minValue(Node node)
        {
            int minv = node.Value;
            while (node.Left.Next != null)
            {
                minv = node.Left.Next.Value;
                node = node.Left.Next;
            }
            return minv;
        }

        #endregion

        #region Indexer
        public int this[int index]
        {
            get
            {
                int inIndex = 0, result = 0;
                NodeToEnumerator(_root, ref inIndex, ref result, index);
                return result;
            }
        }

        private void NodeToEnumerator(Node node, ref int index, ref int result, int compareToIndex)
        {
            if (node == null)
            {
                return;
            }

            NodeToEnumerator(node.Left.Next, ref index, ref result, compareToIndex);
            if (index == compareToIndex)
            {
                index++;
                result = node.Value;
                return;
            }
            index++;
            NodeToEnumerator(node.Right.Next, ref index, ref result, compareToIndex);
        }
        #endregion

        #region Equal
        public override bool Equals(object obj)
        {
            var bst = obj as BSTreeLink;
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
