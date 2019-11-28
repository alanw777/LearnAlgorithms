using System.Collections.Generic;

namespace AlgorithmsWithCs.StackAndQueue
{
    public static class DijkstraDoubleStackAlgorithm
    {
        private static Stack<float> numberStack = new Stack<float>();
        private static Stack<string> opStack = new Stack<string>();
        public static float Calculate(IEnumerable<string> expression)
        {
            foreach (var item in expression)
            {
                switch (item)
                {
                    case "(":
                        break;
                    case "+":
                        opStack.Push(item);
                        break;
                    case "-":
                        opStack.Push(item);
                        break;
                    case "*":
                        opStack.Push(item);
                        break;
                    case "/":
                        opStack.Push(item);
                        break;
                    case ")":
                        numberStack.Push(Calc());
                        break;
                    default:
                        numberStack.Push(float.Parse(item));
                        break;
                }
            }

            return numberStack.Pop();
        }

        private static float Calc()
        {
            float right = numberStack.Pop();
            float left = numberStack.Pop();
            string item = opStack.Pop();
            float rv = 0;
            switch (item)
            {
                case "+":
                    rv = left + right;
                    break;
                case "-":
                    rv = left - right;
                    break;
                case "*":
                    rv = left * right;
                    break;
                case "/":
                    rv = left / right;
                    break;
            }

            return rv;
        }
    }
}