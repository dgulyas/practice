namespace pointStore
{
	class Point
	{
		public int X { get; set; }

		public int Y { get; set; }

		public int Value { get; set; }

		public bool IsInsideBox(Box box)
		{
			return X <= box.Right && X >= box.Left && Y <= box.Top && Y >= box.Bottom;
		}
	}

}
