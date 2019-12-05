using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsWithCs
{
    public static class Utils
    {
        public static void Log(object text)
        {
            Console.WriteLine(text);
        }

        public static void Log(IList list)
        {
            var rv = new StringBuilder();
            rv.Append("[");
            foreach (object obj in list)
            {
                rv.Append(obj.ToString()).Append(",");
            }

            rv.Remove(rv.Length-1, 1);
            rv.Append("]\n");
            Utils.Log(rv.ToString());
        }
    }
}