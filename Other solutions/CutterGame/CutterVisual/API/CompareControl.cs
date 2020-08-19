using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutterVisual.API
{
    public class CompareControl<T> : IComparer<T> where T : Control
    {
        public int Compare(T x, T y)
        {
            if (x.Height < y.Height)
            {
                return 1;
            }
            else if (x.Height > y.Height)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
