using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace AlgorithmsWithCs.StackAndQueue
{
    public class QueueWithResizeArray<T>: IEnumerable<T>
    {
        private T[] array;
        private int N;
        private int first;
        private int last;

        public QueueWithResizeArray()
        {
            array = new T[1];
            N = 0;
            first = 0;
            last = -1;
        }

        public void Clear()
        {
            array = new T[1];
            N = 0;
            first = 0;
            last = -1;
        }

        public void Enqueue(T item)
        {
            if (N + 1 > array.Length / 2)
            {
                ResizeExpand();
            }
            N++;
            array[++last] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is Empty!");
            }

            var rv = array[first];
            array[first] = default(T);
            N--;
            first++;
            if (N < array.Length / 4)
            {
                ResizeShrink();
            }
            return rv;
        }

        public bool IsEmpty()
        {
            return N<=0;
        }

        private void ResizeExpand()
        {
            var bigArray = new T[array.Length * 2];
            int index = 0;
            for (int i = first; i <= last; i++)
            {
                bigArray[index++] = array[i];
            }

            first = 0;
            last = N - 1;

            array = bigArray;
            Utils.Log("Expand : " + bigArray.Length);
        }

        private void ResizeShrink()
        {
            var smallArray = new T[array.Length / 2];
            int index = 0;
            for (int i = first; i <= last; i++)
            {
                smallArray[index++] = array[i];
            }
            first = 0;
            last = N - 1;

            array = smallArray;
            Utils.Log("Shrink : " + smallArray.Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(array,first,last);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private class QueueEnumerator<T> : IEnumerator<T>
        {
            private readonly T[] array;
            private readonly int first;
            private readonly int last;
            private int position;
            public QueueEnumerator(T[] array, int first,int last)
            {
                this.array = array;
                this.first = first;
                this.last = last;
                position = first-1;
            }

            public bool MoveNext()
            {
                position++;
                return position <= last;
            }

            public void Reset()
            {
                position = first-1;
            }

            public T Current => array[position];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}