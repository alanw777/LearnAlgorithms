namespace AlgorithmsWithCs.UnionFind
{
    public class WeightedQUPathCompress
    {
        private int[] id;
        private int[] sizes;

        public WeightedQUPathCompress(int N)
        {
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                sizes[i] = 1;
            }
        }

        public int Root(int i)
        {
            while (i!=id[i])
            {
                id[i] = id[id[i]];
                i = id[i];
            }
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
            if(i==j) return;
            if (sizes[i] < sizes[j])
            {
                id[i] = j;
                sizes[j] += sizes[i];
            }
            else
            {
                id[j] = i;
                sizes[i] += sizes[j];
            }
        }
    }
}