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
            var a = new int[] {30, -40, -20, -10, 40, 0, 10, 5};
            var rv = ThreeSum.Find(a);
            Utils.Log(rv.ToString());
            rv = ThreeSum.BinarySearchFind(a);
            Utils.Log(rv.ToString());
            //(((1+(2*3))-1)/2)
            Utils.Log(DijkstraDoubleStackAlgorithm.Calculate(new String[] {"(", "(", "(","1","+","(","2","*","3",")",")","-","1",")","/","2",")"}).ToString());

        }

        class MyClass : IEnumerable
        {
            private int[] a;
            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            class MyClassEnumerator:IEnumerator
            {
                public bool MoveNext()
                {
                    throw new NotImplementedException();
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }

                public MyClass Current { get; }

                object IEnumerator.Current => Current;

                public void Dispose()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}