using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface IList
    {
        IEnumerator GetEnumerator();
        int Size();
        void Clear();
        void AddStart(int val);
        void AddPos(int pos, int val);
        void AddEnd(int val);
        int[] ToArray();
        void Init(int[] arr);
        int DelStart();
        int DelEnd();
        int DelPos(int pos);
        void Set(int pos, int val);
        int Get(int pos);
        void Reverse();
        void HalfReverse();
        int IndMin();
        int IndMax();
        int Min();
        int Max();
        void Sort();
    }
}
