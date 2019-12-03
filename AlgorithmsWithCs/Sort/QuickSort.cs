using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

namespace AlgorithmsWithCs.Sort
{
    public class QuickSort<T> where T : IComparable<T>
    {
        private static Random random = new Random();
        public static void Sort(IList<T> list)
        {
            if(list==null || list.Count<2) return;
            Sort(list,0,list.Count-1);
        }

        private static void Sort(IList<T> list, int start, int end)
        {
            if(start>=end) return;
            int left = start;
            int right = end;
            int index = random.Next(start, end + 1);
            T pivot = list[index];
            while (left<=right)
            {
                while (left<=right && Less(list[left],pivot))
                {
                    left++;
                }

                while (left<=right && More(list[right],pivot))
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(list, left, right);
                    left++;
                    right--;
                }
            }
            Sort(list,start,right);
            Sort(list,left,end);
        }

        private static void Swap(IList<T> list, int i, int j)
        {
            var t = list[i];
            list[i] = list[j];
            list[j] = t;
        }
        private static bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }
        private static bool More(T a, T b)
        {
            return a.CompareTo(b) > 0;
        }
    }
}