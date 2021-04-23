using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BalancedBinarySearchTree<int>();
            //tree.Insert(12);
            tree.Insert(8);
            tree.Insert(10);
            tree.Insert(10);
            tree.Insert(13);
            tree.Insert(34);
            tree.Insert(34);
            tree.Insert(32);
            tree.Insert(28);
            tree.Insert(9);
            tree.Insert(21);
            tree.Insert(42);
            tree.Insert(42);
            tree.Insert(42);
            tree.Insert(56);
            tree.Insert(58);
            tree.Insert(60);
            tree.Insert(41);
            tree.Insert(41);
            tree.Insert(41);
            tree.Insert(41);
            tree.Insert(41);
            tree.Insert(43);
            
            var tree2 = new BalancedBinarySearchTree<int>();
            tree2.Insert(12);
            tree2.Insert(8);
            tree2.Insert(10);
            tree2.Insert(10);
            tree2.Insert(13);
            tree2.Insert(34);
            tree2.Insert(34);
            tree2.Insert(32);
            tree2.Insert(28);
            tree2.Insert(9);
            tree2.Insert(21);
            tree2.Insert(42);
            tree2.Insert(42);
            tree2.Insert(42);
            tree2.Insert(56);
            tree2.Insert(58);
            tree2.Insert(60);
            tree2.Insert(41);
            tree2.Insert(41);
            tree2.Insert(41);
            tree2.Insert(41);
            tree2.Insert(41);
            tree2.Insert(43);

            
            
            tree.PrintSorted();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(tree.FatherNode(34));
            
            
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