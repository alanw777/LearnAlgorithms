using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class SortTest
    {
        public static void Test()
        {
            Utils.Log("Sort Test");
//            var b = new List<int>() {30, -40, -20, -10, 40, 0, 10, 5,8,8,8,8,8,8,8,8,-8,-8,-8,-8,-8,-8};
//            QuickSort<int>.Sort(b);
//            Utils.Log(b);
//            SelectionSort<int>.Sort(b);
//            foreach (var item in b)
//            {
//                Utils.Log(item.ToString());
//            }
//
//            var array = new List<string>() {"abc", "zoo", "down", "wang", "Li"};
//            SelectionSort<string>.Sort(array);
//            InsertionSort<string>.Sort(array);
//            ShellSort<string>.Sort(array);
//            foreach (var item in array)
//            {
//                Utils.Log(item.ToString());
//            }
//
//            var cards = new List<int>(13);
//            for (int i = 1; i <= 13; i++)
//            {
//                cards.Add(i);
//            }
//
//            Shuffle<int>.Shuffling(cards);
//            Utils.Log(cards);
            var list = new List<int>(){3,2,1,5,6,4};
            var k = 2;
            var kthLargest = QuickSelect<int>.FindKthLargest(list, k);
            Utils.Log(kthLargest.ToString());
        }
    }
}