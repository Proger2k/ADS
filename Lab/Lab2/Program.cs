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
            
            var tree2 = new BalancedBinarySearchTree<int>();
            tree2.Insert(50);
            tree2.Insert(45);
            tree2.Insert(60);
            tree2.Insert(46);
            tree2.Insert(30);
            tree2.Insert(32);
            tree2.Insert(47);
            tree2.Insert(25);
            tree2.Insert(28);
            tree2.Insert(55);
            tree2.Insert(56);
            tree2.Insert(100);
            tree2.Insert(90);
            tree2.Insert(80);
            tree2.Insert(120);

            
            tree.PrintSorted();
            Console.WriteLine();
            Console.WriteLine();
            tree2.PrintSorted();
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine(tree.CommonAncestor(28, 32));
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