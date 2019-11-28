using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsWithCs.StackAndQueue
{
    public class StackWithLinkedList<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> linkedList;

        public StackWithLinkedList()
        {
            linkedList = new LinkedList<T>();
        }

        public void Push(T item)
        {
            var newNode = new LinkedListNode<T>(item);
            linkedList.AddFirst(newNode);
        }

        public T Pop()
        {
            if (IsEmpty())
                return default(T);
            var rv = linkedList.First;
            linkedList.RemoveFirst();
            return rv.Value;
        }

        public bool IsEmpty()
        {
            return linkedList.Count < 1;
        }

        public IEnumerator<T> GetReversEnumerator()
        {
            return new StackReversEnumerator(linkedList.Last);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator(linkedList.First);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<T>
        {
            private LinkedListNode<T> current;
            private readonly LinkedListNode<T> first;

            public StackEnumerator(LinkedListNode<T> first)
            {
                current = null;
                this.first = first;
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = this.first;
                    return true;
                }

                if (current.Next == null) return false;
                current = current.Next;
                return true;
            }

            public void Reset()
            {
                current = this.first;
            }

            public T Current => current.Value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }

        private class StackReversEnumerator : IEnumerator<T>
        {
            private LinkedListNode<T> last;
            private LinkedListNode<T> current;

            public StackReversEnumerator(LinkedListNode<T> last)
            {
                this.last = last;
                current = null;
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = last;
                    return true;
                }

                if (current.Previous == null) return false;
                current = current.Previous;
                return true;
            }

            public void Reset()
            {
                current = this.last;
            }

            public T Current => current.Value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}