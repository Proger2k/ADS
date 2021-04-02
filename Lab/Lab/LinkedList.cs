using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Lab1
{
	public class LinkedList<T> : IEnumerable
	{
		public Item<T> First { get; set; }
		public Item<T> Last { get; set; }
		public int Count { get; set; }

		public LinkedList()
		{
			Clear();
		}

		public void Delete(T data)
		{
			if (First == null)
				return;

			if(First.Data.Equals(data))
			{
				First = First.Next;
				Count--;
				return;
			}

			var current = First.Next;
			var previous = First;

			while(current != null)
			{
				if(current.Data.Equals(data))
				{
					previous.Next = current.Next;
					Count--;

					if (First.Next == null)
						Last = null;

					return;
				}

				previous = current;
				current = current.Next;
			}
		}

		public void Add(T data)
		{
			var item = new Item<T>(data);

			if (Last != null)
			{
				var previous = First;
				var current = previous.Next;

				if (Compare(previous, item))
				{
					First = item;
					First.Next = previous;
					Count++;
					return;
				}
				
				while(current != null)
				{
					if (Compare(current, item))
					{
						item.Next = current;
						previous.Next = item;
						Count++;
						return;
					}

					previous = current;
					current = previous.Next;
				}

				previous.Next = item;
				Last = item;
				Count++;
			}
			else
			{
				First = item;
				Last = item;
				Count = 1;
			}
		}

		private bool Compare(Item<T> item1, Item<T> item2)
		{
			if(item1.Data is int || item1.Data is double)
			{
				return Convert.ToDouble(item1.Data) >= Convert.ToDouble(item2.Data);
			}
			else
			{
				List<string> mass = new List<string>();
				mass.Add(item1.Data.ToString());
				mass.Add(item2.Data.ToString());

				mass.OrderBy(x => x);

				if (mass[0] == item1.Data.ToString())
					return true;
				else
					return false;
			}
		}

		public bool IsEmpty()
		{
			if (First == null && Last == null)
				return true;
			return false;
		}

		public bool Search(T data)
		{
			foreach(var item in this)
				if (item.Equals(data))
					return true;

			return false;
		}

		public void Clear()
		{
			First = null;
			Last = null;
			Count = 0;
		}

		public void Read(LinkedList<int> list)
		{
			try
			{
				List<int> data = Console.ReadLine().Split(" ").Select(x => Convert.ToInt32(x)).ToList();
				foreach (var item in data)
					list.Add(item);
			}
			catch
			{
				Console.WriteLine("Неверный формат");
				Console.WriteLine();
			}
		}

		public void PrintLinkedList()
		{
			foreach(var item in this)
			{
				Console.Write(item.ToString() + " ");
			}
			Console.WriteLine();
		}

		public bool Is(LinkedList<T> list)
		{
			foreach (var item in list)
			{
				bool flag = true;
				foreach (var item2 in this)
				{
					if (item.Equals(item2))
					{
						flag = false;
					}
				}
				if (flag)
					return false;
			}
			return true;
		}

		public IEnumerator GetEnumerator()
		{
			var current = First;
			while(current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}
	}
}
