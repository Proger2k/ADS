using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BalancedBinarySearchTree(15);
            tree.Insert(tree.MainNode,3);
            tree.Insert(tree.MainNode,8);
            tree.Insert(tree.MainNode,10);
            tree.Insert(tree.MainNode,12);
            tree.Insert(tree.MainNode,34);
            tree.Insert(tree.MainNode,28);
            tree.Insert(tree.MainNode,19);
            tree.Insert(tree.MainNode,21);
            tree.Insert(tree.MainNode,42);

            Console.ReadLine();
        }
    }
}