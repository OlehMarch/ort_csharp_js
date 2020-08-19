using ControlFlowGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task4_02
{
    internal sealed class TreeParameters
    {
        public TreeParameters(int xStart, int yStart, CFGraph graphRenderer)
        {
            this.xStart = xStart;
            this.yStart = yStart;
            this.graphRenderer = graphRenderer;
            depthLvl = 0;
            widthLvl = 0;
            nodeName = null;
            parentNodeName = null;
        }


        public readonly int xStart;
        public readonly int yStart;

        public CFGraph graphRenderer;
        public string nodeName;
        public string parentNodeName;
        public int depthLvl;
        public int widthLvl;


        public void DiveLeft(string currentNodeName)
        {
            if (parentNodeName == currentNodeName)
            {
                widthLvl -= 3;
            }
            else
            {
                widthLvl--;
            }
            depthLvl++;
            nodeName = currentNodeName;
        }

        public void DiveRight(string currentNodeName)
        {
            if (parentNodeName == currentNodeName)
            {
                widthLvl += 3;
            }
            else
            {
                widthLvl++;
            }

            depthLvl++;
            nodeName = currentNodeName;
        }
    }

}
