using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class QuickSelect<T> where T : IComparable<T>
    {
        public static T FindKthLargest(IList<T> list, int k)
        {
            return FindKthSmallest(list, 0, list.Count - 1, list.Count - k);
        }

        private static T FindKthSmallest(IList<T> list, int start, int end, int k)
        {
            if (start >= end) return list[k];
            int left = start;
            int right = end;
            int pivot = start + (end - start) / 2;
            while (left<=right)
            {
                while (left <= right && Less(list[left], list[pivot])) left++;
                while (left <= right && More(list[right], list[pivot])) right--;
                if (left <= right)
                {
                    Swap(list,left,right);
                    left++;
                    right--;
                }
            }

            if (k <= right) return FindKthSmallest(list, start, right, k);
            if (k >= left) return FindKthSmallest(list, left, end, k);
            return list[k];
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