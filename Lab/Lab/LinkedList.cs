using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

		public void Clear()
		{
			First = null;
			Last = null;
			Count = 0;
		}

		public void PrintLinkedList()
		{
			foreach(var item in this)
			{
				Console.Write(item.ToString() + " ");
			}
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
