using System;

namespace Lab2
{
    public class BalancedBinarySearchTree<T>
    where T: IComparable
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        public BalancedBinarySearchTree()
        {
        }

        public void Insert(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }
            
            Root.Insert(data);
            Count++;
        }
    }
}