using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BalancedBinarySearchTree<int>();
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(10);
            tree.Insert(12);
            tree.Insert(34);
            tree.Insert(28);
            tree.Insert(9);
            tree.Insert(21);
            tree.Insert(42);
            
            
            Console.ReadLine();
        }
    }
}