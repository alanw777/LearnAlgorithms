using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class Shuffle<T>
    {
        public static void Shuffling(IList<T> list)
        {
            var random = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int r = random.Next(0, i + 1);
                Swap(list,i,r);
            }
        }

        private static void Swap(IList<T> list,int i,int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}