using Lab1;
using System;

namespace Lab
{
	class Program
	{
		static void Main()
		{
			var linkedList = new LinkedList<int>();
			linkedList.Add(10);
			linkedList.Add(2);
			linkedList.Add(22);
			linkedList.Add(11);


			linkedList.Delete(1);
			linkedList.Delete(3);
			linkedList.Delete(4);
			linkedList.Delete(13);

			linkedList.PrintLinkedList();

			Console.ReadLine();
		}
	}
}
