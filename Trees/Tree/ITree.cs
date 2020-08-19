namespace Task4_02
{
    public interface ITree
    {
        void Init(int[] ini);
        void Clear();
        int Size();
        void Add(int value);
        int Height();
        int Width();
        int Nodes();
        int Leaves();
        int[] ToArray();
        void Reverse();
        void Delete(int value);
    }
}