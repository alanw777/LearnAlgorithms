using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class MaxPriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> pq;
        private int N;

        public MaxPriorityQueue()
        {
            pq = new List<T>();
            pq.Add(default(T));
            N = 0;
        }

        public void Insert(T item)
        {
            pq.Add(item);
            N++;
            Swim(N);
        }

        public T DelMax()
        {
            if (IsEmpty()) throw new Exception("MaxPriorityQueue is Empty");
            var max = Max();
            Swap(1, N);
            pq.RemoveAt(N);
            N--;
            Sink(1);
            return max;
        }

        public T Max()
        {
            if (IsEmpty()) throw new Exception("MaxPriorityQueue is Empty");
            return pq[1];
        }

        public bool IsEmpty()
        {
            return N <= 0;
        }

        public int Count()
        {
            return N;
        }

        private bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }

        private void Swap(int i, int j)
        {
            var t = pq[i];
            pq[i] = pq[j];
            pq[j] = t;
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(pq[k / 2],pq[k]))
            {
                Swap(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2*k<=N)
            {
                int j = 2 * k;
                if (j + 1 <= N && !Less(pq[j + 1], pq[j])) j++;
                if(!Less(pq[k],pq[j])) break;
                Swap(j,k);
                k = j;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MaxPQEnumerator<T>(pq);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private class MaxPQEnumerator<T> : IEnumerator<T> where T : IComparable<T>
        {
            private MaxPriorityQueue<T> pqCopy;
            private readonly IList<T> pq;
            private bool first;
            public MaxPQEnumerator(IList<T> pq)
            {
                this.pq = pq;
                pqCopy = new MaxPriorityQueue<T>();
                for (int i = 1; i < pq.Count; i++)
                {
                    pqCopy.Insert(pq[i]);
                }

                first = true;
            }
            public bool MoveNext()
            {
                if (first)
                {
                    first = false;
                    return true;
                }
                if (!pqCopy.IsEmpty())
                {
                    pqCopy.DelMax();
                }

                return !pqCopy.IsEmpty();
            }

            public void Reset()
            {
                pqCopy = new MaxPriorityQueue<T>();
                for (int i = 1; i < pq.Count; i++)
                {
                    pqCopy.Insert(pq[i]);
                }
                first = true;
            }

            public T Current => pqCopy.Max();

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }
        }
    }
}