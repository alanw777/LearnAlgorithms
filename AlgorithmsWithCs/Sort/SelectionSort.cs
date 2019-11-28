using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AlgorithmsWithCs.Sort
{
    public class SelectionSort<T> where T : IComparable<T>
    {
        public static void Sort(IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var min = i;
                for (int j = i+1; j < list.Count; j++)
                {
                    if (Less(list[j],list[min]))
                    {
                        min = j;
                    }
                }

                Swap(list, min, i);
            }   
        }

        private static bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }

        private static void Swap(IList<T> list, int a, int b)
        {
            var temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
        
        
    }
}