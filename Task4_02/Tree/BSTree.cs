using ControlFlowGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4_02
{
    public class BSTree : ITree, IEnumerator
    {
        public BSTree()
        {
            _root = null;
        }

        private class Node
        {
            public Node Left { set; get; }
            public Node Right { set; get; }
            public int Value { set; get; }

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }


        private Node _root;
        private int _iterator = -1;


        #region Enumeration
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_iterator >= Size() - 1)
            {
                Reset();
                return false;
            }

            _iterator++;
            return true;
        }

        public void Reset()
        {
            _iterator = -1;
        }

        public object Current
        {
            get
            {
                return this[_iterator];
            }
        }
        #endregion

        #region Indexer
        private int this[int index]
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

            NodeToEnumerator(node.Left, ref result, ref index, compareToIndex);
            if (index == compareToIndex)
            {
                index++;
                result = node.Value;
                return;
            }
            index++;
            NodeToEnumerator(node.Right, ref result, ref index, compareToIndex);
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
            if (ini.Length == 0)
            {
                return;
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
            NodeToSize(node.Left, ref size);
            NodeToSize(node.Right, ref size);
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
            if (node.Value > value)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                }
                else
                {
                    AddNode(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                }
                else
                {
                    AddNode(node.Right, value);
                }
            }
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            StringBuilder str = new StringBuilder(20);
            NodeToString(_root, str);
            return str.ToString().TrimEnd();
        }

        private void NodeToString(Node node, StringBuilder strNode)
        {
            if (node == null)
            {
                return;
            }

            NodeToString(node.Left, strNode);
            strNode.Append(node.Value + " ");
            NodeToString(node.Right, strNode);
        }
        #endregion

        #region ToArray
        /*
        private classs XContainer
        {
            public int i = 0;
        }
        */

        public int[] ToArray()
        {
            List<int> tempValueList = new List<int>();
            NodeToList(_root, tempValueList);
            return tempValueList.ToArray<int>();
        }

        private void NodeToList(Node node, List<int> tvl)
        {
            if (node == null)
            {
                return;
            }

            NodeToList(node.Left, tvl);
            tvl.Add(node.Value);
            NodeToList(node.Right, tvl);
        }
        #endregion

        #region Width & Height
        public int Width()
        {
            if (_root == null)
            {
                return 0;
            }

            List<int> widthList = new List<int>();
            int depthLvl = 0;
            NodeToWAndH(_root, widthList, ref depthLvl);
            return widthList.Max();
        }

        public int Height()
        {
            if (_root == null)
            {
                return 0;
            }

            List<int> widthList = new List<int>();
            int depthLvl = 0;
            NodeToWAndH(_root, widthList, ref depthLvl);
            return widthList.Count();
        }

        private void NodeToWAndH(Node node, List<int> widthList, ref int depthLvl)
        {
            if (node == null)
            {
                depthLvl--;
                return;
            }
            if (widthList.Count <= depthLvl)
            {
                widthList.Add(0);
            }
            widthList[depthLvl]++;

            depthLvl++;
            NodeToWAndH(node.Left, widthList, ref depthLvl);
            depthLvl++;
            NodeToWAndH(node.Right, widthList, ref depthLvl);

            depthLvl--;
        }
        #endregion

        #region Nodes
        public int Nodes()
        {
            int nodes = 0;
            NodeToNodes(_root, ref nodes);
            return nodes;
        }

        private void NodeToNodes(Node node, ref int nodes)
        {
            if (node == null || (node.Left == null && node.Right == null))
            {
                return;
            }

            if (node.Left == null && node.Right != null)
            {
                nodes++;
                NodeToNodes(node.Right, ref nodes);
            }
            if (node.Right == null && node.Left != null)
            {
                nodes++;
                NodeToNodes(node.Left, ref nodes);
            }
            if (node.Right != null && node.Left != null)
            {
                nodes++;
                NodeToNodes(node.Left, ref nodes);
                NodeToNodes(node.Right, ref nodes);
            }
        }
        #endregion

        #region Leaves
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
            if (node.Left == null && node.Right == null)
            {
                leaves++;
            }


            if (node.Right != null)
            {
                NodeToLeaves(node.Right, ref leaves);
            }
            if (node.Left != null)
            {
                NodeToLeaves(node.Left, ref leaves);
            }
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

            Node temp = node.Left;
            node.Left = node.Right;
            node.Right = temp;

            if (node.Left != null)
            {
                NodeToReverse(node.Left);
            }
            if (node.Right != null)
            {
                NodeToReverse(node.Right);
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
                node.Left = NodeToDelete(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = NodeToDelete(node.Right, value);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }
                node.Value = minValue(node.Right);
                node.Right = NodeToDelete(node.Right, node.Value);
            }
            return node;
        }

        private int minValue(Node node)
        {
            int minv = node.Value;
            while (node.Left != null)
            {
                minv = node.Left.Value;
                node = node.Left;
            }
            return minv;
        }
        #endregion

        #region Display
        private sealed class TreeParameters
        {
            public const int OFFSET = 60;

            public CFGraph graphRenderer;
            public string nodeName;

            public TreeParameters(CFGraph graphRenderer)
            {
                this.graphRenderer = graphRenderer;
                nodeName = null;
            }
        }

        public void Display(PictureBox pb)
        {
            CFGraph graphR = new CFGraph(pb, 1, 10, 19);
            TreeParameters tParams = new TreeParameters(graphR);
            NodeToDisplay(_root, tParams, 0, pb.Width, 0);
            tParams.graphRenderer.EndOfDraw();
        }

        private void NodeToDisplay(Node node, TreeParameters p, int left, int right, int lvl)
        {
            if (node == null)
            {
                return;
            }

            var x = (left + right) / 2;
            var y = (++lvl * TreeParameters.OFFSET);

            p.graphRenderer.AddNode(node.Value.ToString(),
                new PointF(x, y));

            if (p.nodeName != null)
            {
                p.graphRenderer.AddConnectionLine(p.nodeName, node.Value.ToString());
            }

            p.nodeName = node.Value.ToString();
            NodeToDisplay(node.Left, p, left, x, lvl);
            p.nodeName = node.Value.ToString();
            NodeToDisplay(node.Right, p, x, right, lvl);
        }
        #endregion

        #region Equal
        public override bool Equals(object obj)
        {
            var bst = obj as BSTree;
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
