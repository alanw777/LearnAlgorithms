using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsWithCs.Sort
{
    public class MinPriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> pq;
        private int N;

        public MinPriorityQueue()
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

        public T DelMin()
        {
            if (IsEmpty()) throw new Exception("MinPriorityQueue is Empty");
            var min = Min();
            Swap(1, N);
            pq.RemoveAt(N);
            N--;
            Sink(1);
            return min;
        }

        public T Min()
        {
            if (IsEmpty()) throw new Exception("MinPriorityQueue is Empty");
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

        private bool More(T a, T b)
        {
            return a.CompareTo(b) > 0;
        }

        private void Swap(int i, int j)
        {
            var t = pq[i];
            pq[i] = pq[j];
            pq[j] = t;
        }

        private void Swim(int k)
        {
            while (k > 1 && More(pq[k / 2],pq[k]))
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
                if (j + 1 <= N && !More(pq[j + 1], pq[j])) j++;
                if(!More(pq[k],pq[j])) break;
                Swap(j,k);
                k = j;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MinPQEnumerator<T>(pq);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private class MinPQEnumerator<T> : IEnumerator<T> where T : IComparable<T>
        {
            private MinPriorityQueue<T> pqCopy;
            private readonly IList<T> pq;
            private bool first;
            public MinPQEnumerator(IList<T> pq)
            {
                this.pq = pq;
                pqCopy = new MinPriorityQueue<T>();
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
                    pqCopy.DelMin();
                }

                return !pqCopy.IsEmpty();
            }

            public void Reset()
            {
                pqCopy = new MinPriorityQueue<T>();
                for (int i = 1; i < pq.Count; i++)
                {
                    pqCopy.Insert(pq[i]);
                }
                first = true;
            }

            public T Current => pqCopy.Min();

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }
        }
    }
}