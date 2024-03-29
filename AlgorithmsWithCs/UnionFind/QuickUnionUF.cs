namespace AlgorithmsWithCs.UnionFind
{
    public class QuickUnionUF
    {
        private int[] id;
        
        public QuickUnionUF(int N)
        {
            for (int i = 0; i < N; i++) id[i] = i;
        }

        private int Root(int i)
        {
            while (i!=id[i]) i = id[i];
            return i;
        }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);
            id[i] = j;
        }
    }
}