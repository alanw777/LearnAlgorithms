namespace AlgorithmsWithCs.StackAndQueue
{
    public class StackAndQueueTest
    {
        public struct User
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
        }

        public static void Test()
        {
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
        }
    }
}