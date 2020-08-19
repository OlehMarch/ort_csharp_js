using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_01
{
    public interface IList
    {
        int Size();
        void Clear();
        void Init(int[] array);
        int[] ToArray();
        
        void AddStart(int value);
        void AddEnd(int value);
        void AddPos(int pos, int value);

        int DelStart();
        int DelEnd();
        int DelPos(int pos);

        void Set(int pos, int value);
        int Get(int pos);

        void Reverse();
        void HalfReverse();

        int Min();
        int Max();
        int IndMin();
        int IndMax();
        
        void Sort();
    }
}
