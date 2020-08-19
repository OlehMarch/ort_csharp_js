using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsTree
{
    public interface IBsTree 
    {
        void Add(int val);
        int Size();
        void Init(int [] ar);
        String ToString();
        int[] ToArray();
        int Nodes();
        int Leaves();
        int Width();
        int Height();
        void Reverse();
        void Del(int val);
        void Clear();
    }
}
