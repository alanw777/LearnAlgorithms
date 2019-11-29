using System;
using System.Collections.Generic;

namespace AlgorithmsWithCs.StackAndQueue
{
    public class MaxStack<T> where T : IComparable<T>
    {
        private Stack<T> stack;
        private Stack<T> maxStack;

        public MaxStack()
        {
            stack = new Stack<T>();
            maxStack = new Stack<T>();
        }

        public void Push(T item)
        {
            stack.Push(item);
            if (maxStack.Count > 0 && Less(maxStack.Peek(), item) || maxStack.Count<1)
            {
                maxStack.Push(item);
            }
            else
            {
                maxStack.Push(maxStack.Peek());
            }
        }

        public T Pop()
        {
            maxStack.Pop();
            return stack.Pop();
        }

        public T Max => maxStack.Peek();

        public int Count => stack.Count;

        public bool IsEmpty()
        {
            return stack.Count < 1;
        }

        private static bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }
    }
}