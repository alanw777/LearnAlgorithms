using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class QuickSort3Way<T> where T : IComparable<T>
    {
        public static void Sort(IList<T> list)
        {
            if(list==null || list.Count<2) return;
            Sort(list, 0, list.Count - 1);
        }

        private static void Sort(IList<T> list, int lo, int hi)
        {
            if(hi<=lo) return;
            int lt = lo, gt = hi;
            T v = list[lo];
            int i = lo + 1;
            while (i<=gt)
            {
                int cmp = list[i].CompareTo(v);
                if (cmp < 0) Swap(list, i++, lt++);
                else if (cmp > 0) Swap(list, i, gt--);
                else i++;
            }
            Sort(list,lo,lt-1);
            Sort(list,gt+1,hi);
        }

        private static void Swap(IList<T> list, int i, int j)
        {
            var t = list[i];
            list[i] = list[j];
            list[j] = t;
        }
    }
}