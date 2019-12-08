using System;
using System.Runtime.InteropServices.ComTypes;

namespace AlgorithmsWithCs.SymbolTable
{
    public sealed class STWithBST<TKey,TValue> where TKey : IComparable<TKey>
    {
        private sealed class Node<TKey,TValue> where TKey : IComparable<TKey>
        {
            public TKey Key;
            public TValue Value;
            public Node<TKey, TValue> Left,Right;
            public int N;

            public Node(TKey key, TValue value, int n)
            {
                Key = key;
                Value = value;
                N = n;
            }
        }

        private Node<TKey, TValue> Root;

        public int Size()
        {
            return Size(Root);
        }

        private int Size(Node<TKey, TValue> node)
        {
            if (node == null) return 0;
            return node.N;
        }

        public void Put(TKey key, TValue value)
        {
            Root = Put(Root,key,value);       
        }

        private Node<TKey, TValue> Put(Node<TKey, TValue> node,TKey key, TValue value)
        {
            if (node == null) return new Node<TKey, TValue>(key, value, 1);
            int cmp = key.CompareTo(node.Key);
            if (cmp > 0) node.Right = Put(node.Right, key, value);
            else if (cmp < 0) node.Left = Put(node.Left, key, value);
            else node.Value = value;
            node.N = Size(node.Left) + Size(node.Right) + 1;
            return node;
        }

        public TValue Get(TKey key)
        {
            return Get(Root, key);
        }

        private TValue Get(Node<TKey, TValue> node, TKey key)
        {
            if (node == null) return default(TValue);
            int cmp = key.CompareTo(node.Key);
            if (cmp > 0) return Get(node.Right, key);
            if (cmp < 0) return Get(node.Left, key);
            return node.Value;
        }

        public void DelMin()
        {
            Root = DelMin(Root);
        }

        private Node<TKey,TValue> DelMin(Node<TKey, TValue> node)
        {
            if (node.Left == null) return node.Right;
            node.Left = DelMin(node.Left);
            node.N = Size(node.Left) + Size(node.Right) + 1;
            return node;
        }

        public void DelMax()
        {
            Root = DelMax(Root);
        }

        private Node<TKey, TValue> DelMax(Node<TKey, TValue> node)
        {
            if (node.Right == null) return node.Left;
            node.Right = DelMax(node.Right);
            node.N = Size(node.Left) + Size(node.Right) + 1;
            return node;
        }

        public TKey Min()
        {
            return Min(Root).Key;
        }

        private Node<TKey,TValue> Min(Node<TKey, TValue> node)
        {
            if (node.Left == null) return node;
            return Min(node.Left);
        }
        
        public TKey Max()
        {
            return Max(Root).Key;
        }

        private Node<TKey,TValue> Max(Node<TKey, TValue> node)
        {
            if (node.Right == null) return node;
            return Max(node.Right);
        }

        public void Delete(TKey key)
        {
            Root = Delete(Root, key);
        }

        private Node<TKey, TValue> Delete(Node<TKey, TValue> node, TKey key)
        {
            if (node == null) return null;
            int cmp = key.CompareTo(node.Key);
            if (cmp > 0) node.Right = Delete(node.Right, key);
            else if (cmp < 0) node.Left = Delete(node.Left, key);
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;
                var temp = node;
                node = Min(temp.Right);
                node.Right = DelMin(temp.Right);
                node.Left = temp.Left;
            }

            node.N = Size(node.Left) + Size(node.Right) + 1;
            return node;
        }

        public TKey Floor(TKey key)
        {
            var node = Floor(Root, key);
            if (node == null) return default(TKey);
            return node.Key;
        }

        private Node<TKey, TValue> Floor(Node<TKey, TValue> node, TKey key)
        {
            if (node == null) return null;
            int cmp = key.CompareTo(node.Key);
            if (cmp == 0) return node;
            if (cmp < 0) return Floor(node.Left, key);
            var temp = Floor(node.Right, key);
            if (temp != null) return temp;
            return node;
        }
        
        public TKey Ceil(TKey key)
        {
            var node = Ceil(Root, key);
            if (node == null) return default(TKey);
            return node.Key;
        }

        private Node<TKey, TValue> Ceil(Node<TKey, TValue> node, TKey key)
        {
            if (node == null) return null;
            int cmp = key.CompareTo(node.Key);
            if (cmp == 0) return node;
            if (cmp > 0) return Ceil(node.Right, key);
            var temp = Ceil(node.Left, key);
            if (temp != null) return temp;
            return node;
        }
        
    }
}