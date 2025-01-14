﻿namespace Lab1
{
	public class Item<T>
	{
		private T data = default(T);
		public T Data
		{
			get
			{
				return data;
			}
			set
			{
				if (value != null)
					data = value;
			}
		}
		public Item<T> Next { get; set; }

		public Item(T data)
		{
			Data = data;
		}

		public override string ToString()
		{
			return $"{Data}";
		}
	}
}
