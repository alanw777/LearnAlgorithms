using System;

namespace AlgorithmsWithCs.StackAndQueue
{
    public class StackAndQueueTest
    {
        public struct User : IEquatable<User>
        {
            private static long count = 0;
            public long id;
            public string name;
            public float score;

            public User(string name, float score) : this()
            {
                this.name = name;
                this.score = score;
                this.id = count++;
            }

            public override string ToString()
            {
                return $"name : {this.name} , score : {this.score},id : {this.id}";
            }

            public bool Equals(User other)
            {
                return id == other.id && name == other.name && score.Equals(other.score);
            }

            public override bool Equals(object obj)
            {
                return obj is User other && Equals(other);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ score.GetHashCode();
                    return hashCode;
                }
            }

            public static bool operator ==(User left, User right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(User left, User right)
            {
                return !left.Equals(right);
            }
        }

        public static void Test()
        {
            Utils.Log("Stack and queue test");
            var random = new Random();
            var stack = new StackWithResizeArray<int>();
            Utils.Log(stack.IsEmpty().ToString());
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Utils.Log(stack.IsEmpty().ToString());
            Utils.Log(stack.Pop().ToString());
            Utils.Log(stack.Pop().ToString());
            Utils.Log(stack.Pop().ToString());
            Utils.Log(stack.IsEmpty().ToString());

            var stack2 = new StackWithResizeArray<User>();
            stack2.Push(new User("wang", 100));
            stack2.Push(new User("li", 88));
            stack2.Push(new User("zhu", 60));
            
            foreach (var user in stack2)
            {
                Utils.Log(user.ToString());
            }

            foreach (var user in stack2)
            {
                Utils.Log(user.ToString());
            }

//            var e = stack2.GetReversEnumerator();
//            while (e.MoveNext())
//            {
//                Utils.Log(e.Current.ToString());
//            }
//
//            e.Dispose();

            var queue = new QueueWithResizeArray<int>();
            Utils.Log(queue.IsEmpty().ToString());
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Utils.Log(queue.IsEmpty().ToString());
            Utils.Log(queue.Dequeue().ToString());
            Utils.Log(queue.Dequeue().ToString());
            Utils.Log(queue.Dequeue().ToString());
            Utils.Log(queue.IsEmpty().ToString());
            
            var queue2 = new QueueWithResizeArray<User>();
            queue2.Enqueue(new User("wang", 100));
            queue2.Enqueue(new User("li", 88));
            queue2.Enqueue(new User("zhu", 60));
            foreach (var user in queue2)
            {
                Utils.Log(user.ToString());
            }

            foreach (var user in queue2)
            {
                Utils.Log(user.ToString());
            }
            queue.Clear();
            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 100; i++)
            {
                queue.Dequeue();
            }
            
//            Utils.Log("Queue with two stack");
//            var qs = new QueueWithTwoStack<int>();
//            for (int i = 0; i < 5; i++)
//            {
//                qs.Enqueue(i);
//            }
//
//           Utils.Log(qs.Dequeue().ToString());
//           Utils.Log(qs.Dequeue().ToString());
//           qs.Enqueue(5);
//           qs.Enqueue(6);
//           while (!qs.IsEmpty())
//           {
//               Utils.Log(qs.Dequeue().ToString());
//           }
            Utils.Log("max stack");
            var maxStack = new MaxStack<int>();
            for (int i = 0; i < 10; i++)
            {
                maxStack.Push(random.Next(0,10));
            }
            Utils.Log("max : " + maxStack.Max);
            while (maxStack.Count>1)
            {
                Utils.Log(maxStack.Pop().ToString() + " : max = " + maxStack.Max);
            }
            
            Utils.Log(DijkstraDoubleStackAlgorithm.Calculate(new String[] {"(", "(", "(","1","+","(","2","*","3",")",")","-","1",")","/","2",")"}).ToString());

            
        }
    }
}