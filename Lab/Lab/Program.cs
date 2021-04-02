using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
	class Program
	{
		static void Main()
		{
			var linkedList = new Lab1.LinkedList<string>();
			var linkedList2 = new Lab1.LinkedList<string>();
			
			linkedList.Add("5");
			linkedList.Add("wd");
			linkedList.Add("adq");
			linkedList.Add("ewere");

			linkedList2.Add("4");
			linkedList2.Add("5");
			linkedList2.Add("adq");
			linkedList2.Add("ewere");
			linkedList2.Add("wd");

			Console.WriteLine(linkedList2.Is(linkedList));

			Console.ReadLine();
		}
	}
}
