using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class MergeSort<T> where T : IComparable<T>
    {
        public static void Sort(IList<T> list)
        {
            if (list == null || list.Count < 2)
            {
                return;
            }
            var temp = new T[list.Count];
            Sort(list,0,list.Count-1,temp);
        }

        private static void Sort(IList<T> list, int start, int end, IList<T> temp)
        {
            if(start>=end)
                return;
            int mid = start + (end - start) / 2;
            Sort(list,start,mid,temp);
            Sort(list,mid+1,end,temp);
            Merge(list,start,mid,end,temp);
        }

        private static void Merge(IList<T> list, int start, int mid, int end, IList<T> temp)
        {
            if(start>=end)
                return;
            int left = start;
            int right = mid + 1;
            int index = start;
            while (left<=mid && right<=end)
            {
                if (Less(list[left], list[right])) temp[index++] = list[left++];
                else temp[index++] = list[right++];
            }

            while (left<=mid)
            {
                temp[index++] = list[left++];
            }

            while (right<=end)
            {
                temp[index++] = list[right++];
            }

            for (int i = start; i <= end; i++)
            {
                list[i] = temp[i];
            }
        }
        private static bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }
    }
}