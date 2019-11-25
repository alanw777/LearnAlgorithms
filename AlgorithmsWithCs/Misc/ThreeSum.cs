using System;

namespace AlgorithmsWithCs.Misc
{
    public class ThreeSum
    {
        public static int Find(int[] array)
        {
            if (array == null)
                return 0;
            if (array.Length < 3)
                return 0;
            int N = array.Length;
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i+1; j < N; j++)
                {
                    for (int k = j+1; k < N; k++)
                    {
                        if (array[i] + array[j] + array[k] == 0)
                            count++;
                    }
                }
            }

            return count;
        }

        public static int BinarySearchFind(int[] array)
        {
            if (array == null)
                return 0;
            if (array.Length < 3)
                return 0;
            int N = array.Length;
            int count = 0;
            Array.Sort(array);
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (j + 1 >= N) continue;
                    int rv = BinarySearch(array, j + 1, N - 1, -(array[i] + array[j]));
                    if (rv != -1)
                        count++;
                }
            }

            return count;
        }

        private static int BinarySearch(int[] array, int start, int end, int num)
        {
            while (start+1<end)
            {
                int mid = start + (end - start) / 2;
                if (num == array[mid])
                {
                    return mid;
                }

                if (num > array[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            if (array[start] == num)
                return start;
            if (array[end] == num)
                return end;
            return -1;
        }
    }
}