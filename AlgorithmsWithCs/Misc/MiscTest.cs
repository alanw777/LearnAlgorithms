using System.Collections.Generic;

namespace AlgorithmsWithCs.Misc
{
    public class MiscTest
    {
        public static void Test()
        {
            Utils.Log("Misc Test");
            var a = new int[] {30, -40, -20, -10, 40, 0, 10, 5};
            var rv = ThreeSum.Find(a);
            Utils.Log(rv.ToString());
            rv = ThreeSum.BinarySearchFind(a);
            Utils.Log(rv.ToString());
        }
    }
}