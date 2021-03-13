using Lab1;
using System;

namespace Lab
{
	class Program
	{
		static void Main()
		{
			var linkedList = new LinkedList<int>();
			linkedList.Add(11);
			linkedList.Add(22);
			linkedList.Add(333);
			linkedList.Add(1);
			linkedList.Add(1232);
			linkedList.Add(123234);
			linkedList.Add(435);

			linkedList.Delete(11);
			linkedList.Delete(333);
			linkedList.Delete(435);
			linkedList.Delete(11111);

			linkedList.PrintLinkedList();

			Console.ReadLine();
		}
	}
}
