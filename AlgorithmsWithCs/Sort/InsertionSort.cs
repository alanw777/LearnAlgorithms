using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class InsertionSort<T> where T : IComparable<T>
    {
        public static void Sort(IList<T> list)
        {
            int N = list.Count;
            for (int i = 0; i < N; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if(Less(list[j],list[j-1])) Swap(list,j,j-1);
                    else break;
                }
            }
        }

        private static bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }

        private static void Swap(IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}