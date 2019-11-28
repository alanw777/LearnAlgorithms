using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsWithCs.StackAndQueue
{
    public class StackWithResizeArray<T> : IEnumerable<T>
    {
        private T[] array;
        private int N;

        public StackWithResizeArray()
        {
            array = new T[1];
            N = 0;
        }

        public void Push(T item)
        {
            if (N + 1 <= array.Length / 2)
            {
                array[N++] = item;
            }
            else
            {
                ResizeExpand();
                array[N++] = item;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is Empty!");
            }

            var rv = array[N - 1];
            array[N - 1] = default(T);
            N--;
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
            for (int i = 0; i < N; i++)
            {
                bigArray[i] = array[i];
            }

            array = bigArray;
        }

        private void ResizeShrink()
        {
            var smallArray = new T[array.Length / 2];
            for (int i = 0; i < N; i++)
            {
                smallArray[i] = array[i];
            }

            array = smallArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(array,N);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private class StackEnumerator<T> : IEnumerator<T>
        {
            private readonly T[] array;
            private readonly int N;
            private int position;
            public StackEnumerator(T[] array, int N)
            {
                this.array = array;
                this.N = N;
                position = N;
            }

            public bool MoveNext()
            {
                position--;
                return position >= 0;
            }

            public void Reset()
            {
                position = N;
            }

            public T Current => array[position];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }

   
}