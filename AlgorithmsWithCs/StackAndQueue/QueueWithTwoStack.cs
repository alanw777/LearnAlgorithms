using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.StackAndQueue
{
    public class QueueWithTwoStack<T>
    {
        private Stack<T> inStack;
        private Stack<T> outStack;
        private int N;

        public QueueWithTwoStack()
        {
            inStack = new Stack<T>();
            outStack = new Stack<T>();
            N = 0;
        }

        public void Enqueue(T item)
        {
            N++;
            inStack.Push(item);
        }

        public T Dequeue()
        {
            if (outStack.Count > 0)
            {
                N--;
                return outStack.Pop();
            }
            else
            {
                if (N > 0)
                {
                    while (inStack.Count>0)
                    {
                        outStack.Push(inStack.Pop());
                    }
                    N--;
                    return outStack.Pop();
                }
                else
                {
                    throw new Exception("Queue is empty");
                }
            }
        }

        public int Count => N;

        public bool IsEmpty()
        {
            return N < 1;
        }
    }
}