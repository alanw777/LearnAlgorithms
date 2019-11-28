using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class ShellSort<T> where T : IComparable<T>
    {
        public static void Sort(IList<T> list)
        {
            int N = list.Count;
            int h = 1;
            while (h<N)
            {
                h = 3 * h + 1;
            }

            while (h>=1)
            {
                for (int i = h; i < N; i++)
                {
                    for (int j = i; j >= h; j = j - h)
                    {
                        if(Less(list[j],list[j-h])) Swap(list,j,j-h);
                        else break;
                    }
                }

                h = h / 3;
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