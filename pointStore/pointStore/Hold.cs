using System;
using System.Collections.Generic;

namespace pointStore
{
	class Hold
	{
		public int MaxPoints; //arbitrary number, not sure what's optimal
		public List<Point> Points { get; set; }

		//There are two modes for this class. Either is contains points, or it points to 4
		//instances of this class. If StoresPoints is true, this instance is storing points.
		//If StoresPoints if false it must point to 4 other Holds.
		public bool StoresPoints => Points == null;

		public int Level;

		public Point LargestPoint;

		//The origin is in the bottom left corner
		//TODO: These can just be a collection of 4 holds. No need to give them different names.
		public Hold BottomLeft;
		public Hold BottomRight;
		public Hold TopLeft;
		public Hold TopRight;

		public int TopBoundry;
		public int BottomBoundry;
		public int RightBoundry;
		public int LeftBoundry;

		public Hold(int tb, int bb, int rb, int lb, int level, int maxPoints = 512)
		{
			TopBoundry = tb;
			BottomBoundry = bb;
			RightBoundry = rb;
			LeftBoundry = lb;
			Level = level;
			MaxPoints = maxPoints;
			LargestPoint = new Point { Value = int.MinValue, X = -1, Y = -1 };
			Points = new List<Point>();
		}

		public void AddPoint(Point inputPoint)
		{
			if (inputPoint.Value > LargestPoint.Value)
			{
				LargestPoint = inputPoint;
			}

			if (StoresPoints)
			{
				Points.Add(inputPoint);

				//There are now too many points in here. Split them into 4 other Holds.
				if (Points.Count > MaxPoints)
				{
					//TODO: if we're too small we shouldn't be splitting
					Split();
				}
			}
			else
			{
				DepositPoint(inputPoint);
			}
		}

		//SHould this point be added to this Hold??
		public bool TakesThisPoint(Point p)
		{
			return p.X >= LeftBoundry && p.X <= RightBoundry && p.Y >= BottomBoundry && p.Y <= TopBoundry;
		}

		public void PrintData()
		{
			Console.WriteLine($"tb:{TopBoundry} bb{BottomBoundry} rb{RightBoundry} lb{LeftBoundry}");
			Console.WriteLine($"StoresPoints:{StoresPoints}");
			if (StoresPoints)
			{
				foreach (var point in Points)
				{
					Console.Write($"{point.X} {point.Y} {point.Value}, ");
				}
				Console.WriteLine();
			}
			else
			{
				print("BottomLeft");
				BottomLeft.PrintData();

				print("BottomRight");
				BottomRight.PrintData();

				print("TopLeft");
				TopLeft.PrintData();

				print("TopRight");
				TopRight.PrintData();
			}
		}

		//This is what happens when there are too many points in this hold. The area that
		//this hold covers is split into four and assigned to 4 other holds. The points
		//are then divided among the four new holds.
		private void Split()
		{
			var xMiddle = (LeftBoundry + RightBoundry) / 2;
			var yMiddle = (BottomBoundry + TopBoundry) / 2;
			BottomLeft = new Hold(yMiddle, BottomBoundry, xMiddle, LeftBoundry, Level + 1, MaxPoints);
			BottomRight = new Hold(yMiddle, BottomBoundry, RightBoundry, xMiddle + 1, Level + 1, MaxPoints);
			TopLeft = new Hold(TopBoundry, yMiddle + 1, xMiddle + 1, LeftBoundry, Level + 1, MaxPoints);
			TopRight = new Hold(TopBoundry, yMiddle + 1, RightBoundry, xMiddle + 1, Level + 1, MaxPoints);
			foreach (var point in Points)
			{
				DepositPoint(point);
			}

			Points = null;
		}

		private void DepositPoint(Point point)
		{
			if (BottomLeft.TakesThisPoint(point)) { BottomLeft.AddPoint(point); return; }
			if (BottomRight.TakesThisPoint(point)) { BottomRight.AddPoint(point); return; }
			if (TopLeft.TakesThisPoint(point)) { TopLeft.AddPoint(point); return; }
			if (TopRight.TakesThisPoint(point)) { TopRight.AddPoint(point); }
		}

		private void print(string s, bool newLine = true)
		{
			var printString = $"{new string(' ', Level * 1)}{s}";
			if (newLine)
			{
				Console.WriteLine(printString);
			}
			else
			{
				Console.Write(printString);
			}
		}


	}
}
