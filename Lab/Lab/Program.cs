using Lab1;
using System;

namespace Lab
{
	class Program
	{
		static void Main()
		{
			var linkedList = new LinkedList<int>();

			Console.Write("Элементы списка: ");
			linkedList.PrintLinkedList();
			Console.WriteLine("Пустой ли список ? " + linkedList.IsEmpty());
			Console.WriteLine("Кол-во элементов в списке: " + linkedList.Count);
			Console.WriteLine("Есть ли число 11 в списке ? " + linkedList.Search(11));
			Console.WriteLine("Добавление элементов");
			Console.WriteLine();

			linkedList.Add(10);
			linkedList.Add(2);
			linkedList.Add(22);
			linkedList.Add(11);

			Console.Write("Элементы списка: ");
			linkedList.PrintLinkedList();
			Console.WriteLine("Пустой ли список ? " + linkedList.IsEmpty());
			Console.WriteLine("Кол-во элементов в списке: " + linkedList.Count);
			Console.WriteLine("Есть ли число 11 в списке ? " + linkedList.Search(11));
			Console.WriteLine("Есть ли число 12 в списке ? " + linkedList.Search(12));
			Console.WriteLine("Удаление элементов");
			Console.WriteLine();

			linkedList.Delete(10);
			linkedList.Delete(2);
			linkedList.Delete(22);
			linkedList.Delete(11);

			Console.Write("Элементы списка: ");
			linkedList.PrintLinkedList();
			Console.WriteLine("Пустой ли список ? " + linkedList.IsEmpty());
			Console.WriteLine("Кол-во элементов в списке: " + linkedList.Count);
			Console.WriteLine("Есть ли число 11 в списке ? " + linkedList.Search(11));

			Console.ReadLine();
		}
	}
}
