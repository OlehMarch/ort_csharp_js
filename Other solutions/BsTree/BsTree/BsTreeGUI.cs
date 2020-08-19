using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BsTree
{
   public class BsTreeGUI : BsTreeAvl// RbTree// BsTreeRedBlack//
    {
      
        public void Show(Panel p)
        {
            //RbTree tree = new RbTree();
            BsTree tree = new BsTree();
            tree.Init(new int[] { 5, 2, 8, 1, 3, 7, 10, 6, 9, 11 });
            //  tree.Init(new int[] { 13,1,2,3,4});
            //   tree.Init(new int[] { 41,38,31,12,19,8});
            //  RbTree tree = new RbTree();
            //   tree.Init(new int[] { 13,8,17,1,11,15,25,6,22,27 });
            //tree.Init(new int[] { 10,6,45,4,8,0,5,-3});
            //  tree.Init(new int[] { 17, 14, 26, 3, 16, 21, 49, 1, 10, 15, 19, 23, 38, 51, 0, 7, 12, 20, 30, 41, 50, 52, 28, 35, 39, 47, 53 });
            //    tree.Init(new int[] { 17, 14, 26, 3, 16, 21, 49, 1, 10, 15, 19, 23, 38, 51, 0, 7, 12, 20, 30, 41, 50, 52, 28, 35, 39, 47, 53 });
            //  tree.Del(3);
            //tree.Del(38);

           // tree.Init(new int[] { 17, 10, 3, 1, 0, 7, 3, 14, 12, 16, 15, 38, 26, 21, 19, 20, 23, 30, 28, 35, 49, 41, 39, 38, 47, 51, 50, 52, 53 });

            //tree.Init(new int[] { 26, 17, 41, 14, 21, 30, 47, 10, 16, 19, 23, 28, 38, 7, 12, 15, 20, 35, 39, 3,1,0 });
            //  tree.Init(new int[] { 26, 17, 41, 14, 21, 30, 47, 10, 16, 19, 23, 28, 38, 7, 12, 15,20,35,39 });
            //  tree.Init(new int[] {11,2,14,1,7,15,5,8,4 }); //Случай 1
            //tree.Init(new int[] { 11, 7, 14, 2, 8, 15, 1, 5, 4 }); //Случай 2
            //  tree.Init(new int[] { 7, 2, 11, 1, 5 ,8, 14, 4, 15}); //Случай 3
            ShowNode(tree.root, p.CreateGraphics(), 0, p.Width, 0, p.Width / 2);
        }
    
        private void ShowNode(Node p, Graphics g, int left, int right, int lvl, int xp)
        {
            if (p == null)
                return;

            int x = (left + right) / 2;
            int y = ++lvl * 60;

            Pen pen = new Pen(Color.Black, 1);
            SolidBrush brush;
            if(p.isRed == true)
            {
                brush = new SolidBrush(Color.Black);  
            }
            else {
                brush = new SolidBrush(Color.Red);
            }
            g.DrawEllipse(pen, x, y, 20, 20);
            g.DrawString("" + p.val, new Font("Arial", 9), brush, x, y);
            g.DrawLine(pen, x + 10, y, xp, y - 40);

            ShowNode(p.left, g, left, x, lvl, x + 10);
            ShowNode(p.right, g, x, right, lvl, x + 10);
        }
    }
}
