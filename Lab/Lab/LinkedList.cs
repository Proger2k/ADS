using System;
using System.Collections;
using System.Collections.Generic;
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
			First = null;
			Last = null;
			Count = 0;
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

			if(Last != null)
			{
				Last.Next = item;
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
