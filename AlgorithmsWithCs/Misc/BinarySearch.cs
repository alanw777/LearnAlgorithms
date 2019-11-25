namespace AlgorithmsWithCs.Misc
{
    public class BinarySearch
    {
        public static int Find(int[] array, int num)
        {
            if (array == null)
                return -1;
            int start = 0;
            int end = array.Length - 1;
            while (start+1<end)
            {
                int mid = start + (end - start) / 2;
                if (num > array[mid])
                {
                    start = mid + 1;
                }else if (num < array[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    return mid;
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