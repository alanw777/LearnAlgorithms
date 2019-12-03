using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class MergeSort<T> where T : IComparable<T>
    {
        //小于这个值的数组用插入排序，避免频繁递归函数调用，这个值的大小和具体
        //机器相关，一般在5到15效果不错，可以通过试验选择一个值。
        private const int Cutoff = 7;

        public static void Sort(IList<T> list)
        {
            if (list == null || list.Count < 2)
            {
                return;
            }

            var temp = new T[list.Count];
            Sort(list, 0, list.Count - 1, temp);
        }

        private static void Sort(IList<T> list, int start, int end, IList<T> temp)
        {
            if (start >= end)
                return;
            if (end - start + 1 <= Cutoff)
            {
                InsertionSort(list, start, end);
                return;
            }

            int mid = start + (end - start) / 2;
            Sort(list, start, mid, temp);
            Sort(list, mid + 1, end, temp);

            //如果已经是有序了，则不用合并
            if (list[mid].CompareTo(list[mid + 1]) <= 0)
            {
                return;
            }
            Merge(list, start, mid, end, temp);
        }

        private static void Merge(IList<T> list, int start, int mid, int end, IList<T> temp)
        {
            if (start >= end)
                return;
            int left = start;
            int right = mid + 1;
            int index = start;
            while (left <= mid && right <= end)
            {
                if (Less(list[left], list[right])) temp[index++] = list[left++];
                else temp[index++] = list[right++];
            }

            while (left <= mid)
            {
                temp[index++] = list[left++];
            }

            while (right <= end)
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

        private static void Swap(IList<T> list, int i, int j)
        {
            var t = list[i];
            list[i] = list[j];
            list[j] = t;
        }

        private static void InsertionSort(IList<T> list, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (Less(list[j], list[j - 1])) Swap(list, j, j - 1);
                    else break;
                }
            }
        }
    }
}