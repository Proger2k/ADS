using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BalancedBinarySearchTree<int>();
            tree.Insert(50);
            tree.Insert(45);
            tree.Insert(60);
            tree.Insert(46);
            tree.Insert(30);
            tree.Insert(32);
            tree.Insert(47);
            tree.Insert(25);
            tree.Insert(28);
            tree.Insert(55);
            tree.Insert(56);
            tree.Insert(100);
            tree.Insert(90);
            tree.Insert(80);
            tree.Insert(120);

            
            tree.PrintSorted();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(tree.FatherNode(34));

            Console.WriteLine(tree.IsBalanced());
            /*
            tree.PrintSorted();
            Console.WriteLine();
            Console.WriteLine(tree.FindSecondLargest());
            tree.DeleteDuplicate();
            tree.PrintSorted();
            Console.WriteLine();
            
            Console.WriteLine(tree.FindMiddle());
            
            tree.DeleteEven();
            tree.PrintSorted();
            Console.WriteLine();
            
            Console.WriteLine(tree.FindMiddle());
            */
            Console.ReadLine();
        }
    }
}