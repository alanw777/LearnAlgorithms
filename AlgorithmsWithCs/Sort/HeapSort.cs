using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class HeapSort<T> where T : IComparable<T>
    {
        public static void Sort(IList<T> list)
        {
            if(list==null||list.Count<2) return;
            int N = list.Count;
            for (int i = N/2; i >= 1; i--)
            {
                Sink(list, i, N);
            }

            while (N>1)
            {
                Swap(list, 1, N--);
                Sink(list, 1, N);
            }
        }

        private static void Sink(IList<T> list, int k, int N)
        {
            while (2*k<=N)
            {
                int j = 2 * k;
                if (j + 1 <= N && Less(list, j, j + 1)) j++;
                if(!Less(list,k,j)) break;
                Swap(list, k, j);
                k = j;
            }
        }

        private static bool Less(IList<T> list, int i, int j)
        {
            return list[i - 1].CompareTo(list[j - 1]) < 0;
        }

        private static void Swap(IList<T> list, int i, int j)
        {
            var t = list[i - 1];
            list[i - 1] = list[j - 1];
            list[j - 1] = t;
        }
    }
}