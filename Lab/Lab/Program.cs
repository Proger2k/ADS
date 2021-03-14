using Lab1;
using System;

namespace Lab
{
	class Program
	{
		static void Main()
		{
			var linkedList = new LinkedList<int>();

			linkedList.PrintLinkedList();
			Console.WriteLine(linkedList.IsEmpty());

			linkedList.Add(10);
			linkedList.Add(2);
			Console.WriteLine("Найти 2 : " + linkedList.Search(2));
			linkedList.Add(22);
			linkedList.Add(11);
			Console.WriteLine("Найти 11 : " + linkedList.Search(11));
			linkedList.PrintLinkedList();
			Console.WriteLine(linkedList.IsEmpty());

			linkedList.Delete(10);
			linkedList.Delete(2);
			Console.WriteLine("Найти 2 : " + linkedList.Search(2));
			linkedList.Delete(22);
			linkedList.Delete(11);

			linkedList.PrintLinkedList();
			Console.WriteLine(linkedList.IsEmpty());

			Console.ReadLine();
		}
	}
}
