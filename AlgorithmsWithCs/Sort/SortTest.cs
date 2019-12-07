using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class SortTest
    {
        public static void Test()
        {
            Utils.Log("Sort Test");
            var random = new Random();
            var b = new List<int>() {30, -40, -20, -10, 40, 0, 10, 5, 8, 8, 8, 8, 8, 8, 8, 8, -8, -8, -8, -8, -8, -8};
//            QuickSort<int>.Sort(b);
            QuickSort3Way<int>.Sort(b);
//            MergeSort<int>.Sort(b);
            Utils.Log(b);
            //荷兰国旗问题 把包含三个颜色的数组排序
//            var colors = new List<int>() {0, 1, 2, 2, 1, 1, 1, 0, 0, 0, 1, 2, 2, 2, 2};
//            QuickSort3Way<int>.Sort(colors);
//            Utils.Log(colors);
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
//            var list = new List<int>() {3, 2, 1, 5, 6, 4};
//            var k = 2;
//            var kthLargest = QuickSelect<int>.FindKthLargest(list, k);
//            Utils.Log(kthLargest.ToString());

//            var maxPQ = new MaxPriorityQueue<int>();
//            for (int i = 0; i < 10; i++)
//            {
//                maxPQ.Insert(random.Next(1,11));
//            }
//
//            foreach (var i in maxPQ)
//            {
//                Utils.Log(i);
//            }
//            
//            foreach (var i in maxPQ)
//            {
//                Utils.Log(i);
//            }
            
            var minPQ = new MinPriorityQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                minPQ.Insert(random.Next(1,11));
            }

            while (!minPQ.IsEmpty())
            {
                Utils.Log(minPQ.DelMin());
            }

//            foreach (var i in minPQ)
//            {
//                Utils.Log(i);
//            }
//            
//            foreach (var i in minPQ)
//            {
//                Utils.Log(i);
//            }
        }
    }
}