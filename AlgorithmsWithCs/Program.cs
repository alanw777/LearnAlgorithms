using System;
using System.Collections;
using System.Collections.Generic;
using AlgorithmsWithCs.Misc;
using AlgorithmsWithCs.StackAndQueue;

namespace AlgorithmsWithCs
{
    class Program
    {
        static void Main(string[] args)
        {
            StackAndQueueTest.Test();
            var a = new int[] {30, -40, -20, -10, 40, 0, 10, 5};
            var rv = ThreeSum.Find(a);
            Utils.Log(rv.ToString());
            rv = ThreeSum.BinarySearchFind(a);
            Utils.Log(rv.ToString());
            //(((1+(2*3))-1)/2)
            Utils.Log(DijkstraDoubleStackAlgorithm.Calculate(new String[] {"(", "(", "(","1","+","(","2","*","3",")",")","-","1",")","/","2",")"}).ToString());
        }
    }
}