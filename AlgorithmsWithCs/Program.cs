using System;
using AlgorithmsWithCs.Misc;

namespace AlgorithmsWithCs
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] {30, -40, -20, -10, 40, 0, 10, 5};
            var rv = ThreeSum.Find(a);
            Utils.Log(rv.ToString());
            rv = ThreeSum.BinarySearchFind(a);
            Utils.Log(rv.ToString());
        }
    }
}