using System;
using System.Collections.Generic;
using System.Linq;

namespace pointStore
{
	class Hold
	{
		public int MaxPoints; //arbitrary number, not sure what's optimal
		public List<Point> Points { get; set; }

		//There are two modes for this class. Either is contains points, or it points to 4
		//instances of this class. If StoresPoints is true, this instance is storing points.
		//If StoresPoints if false it must point to 4 other Holds.
		public bool StoresPoints => Points != null;

		public int Level;

		public Point LargestPoint;

		//The origin is in the bottom left corner
		public List<Hold> Holds;

		public int TopBoundry;
		public int BottomBoundry;
		public int RightBoundry;
		public int LeftBoundry;

		public Hold(int tb, int bb, int rb, int lb, int level, int maxPoints = 512)
		{
			if (tb < bb || rb < lb)
			{
				throw new Exception("The holds boundaries are wrong.");
			}

			TopBoundry = tb;
			BottomBoundry = bb;
			RightBoundry = rb;
			LeftBoundry = lb;
			Level = level;
			MaxPoints = maxPoints;
			LargestPoint = new Point { Value = int.MinValue, X = -1, Y = -1 };
			Points = new List<Point>();
		}

		public void AddPoint(Point point)
		{
			if (point.Value > LargestPoint.Value)
			{
				LargestPoint = point;
			}

			if (StoresPoints)
			{
				Points.Add(point);

				//There are now too many points in here. Split them into 4 other Holds.
				if (Points.Count > MaxPoints)
				{
					Split();
				}
			}
			else
			{
				DepositPoint(point);
			}
		}

		//Should this point be added to this Hold??
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
				foreach (var hold in Holds)
				{
					hold.PrintData();
				}
			}
		}

		public Point GetLargestPointInBox(Box box)
		{
			if (IsContainedInside(box))
			{
				return LargestPoint;
			}
			if (IsPartiallyContainedInside(box))
			{
				if (!StoresPoints)
				{
					Point maxValuePoint = new Point { Value = int.MinValue, X = -1, Y = -1 };
					foreach (var hold in Holds)
					{
						var possibleLargestPoint = hold.GetLargestPointInBox(box);
						if (possibleLargestPoint?.Value > maxValuePoint.Value)
						{
							maxValuePoint = possibleLargestPoint;
						}
					}
				}
				else
				{
					Point maxValuePoint = Points.First();

					foreach (var point in Points)
					{
						if (point.Value > maxValuePoint.Value)
						{
							maxValuePoint = point;
						}
					}

					return maxValuePoint;
				}
			}

			return null;
		}

		//Returns true if this hold is fully contained in this box
		private bool IsContainedInside(Box box)
		{
			return box.Bottom <= BottomBoundry && box.Top >= TopBoundry && box.Left <= LeftBoundry && box.Right >= RightBoundry;
		}

		//Returns true if any part of this hold is contained in this box
		private bool IsPartiallyContainedInside(Box box)
		{
			if (BottomBoundry > box.Top) //we're above the box
			{
				return false;
			}
			if (TopBoundry < box.Bottom) //we're below the box
			{
				return false;
			}
			if (LeftBoundry > box.Right) //we're to the right of the box
			{
				return false;
			}
			if (RightBoundry < box.Left) //we're to the left of the box
			{
				return false;
			}
			return true;
		}

		//This is what happens when there are too many points in this hold. The area that
		//this hold covers is split into four and assigned to 4 other holds. The points
		//are then divided among the four new holds.
		private void Split()
		{
			CreateSubHolds();
			foreach (var point in Points)
			{
				DepositPoint(point);
			}

			Points = null;
		}

		//Doesn't this look fun to unit test....
		public void CreateSubHolds()
		{
			Holds = new List<Hold>();
			var xMiddle = (LeftBoundry + RightBoundry) / 2;
			var yMiddle = (BottomBoundry + TopBoundry) / 2;
			var xMiddlePlusOne = xMiddle + 1 > RightBoundry ? RightBoundry : xMiddle + 1;
			var yMiddlePlusOne = yMiddle + 1 > TopBoundry ? TopBoundry : yMiddle + 1;

			Holds.Add(new Hold(yMiddle, BottomBoundry, xMiddle, LeftBoundry, Level + 1, MaxPoints));
			Holds.Add(new Hold(yMiddle, BottomBoundry, RightBoundry, xMiddlePlusOne, Level + 1, MaxPoints));
			Holds.Add(new Hold(TopBoundry, yMiddlePlusOne, xMiddle, LeftBoundry, Level + 1, MaxPoints));
			Holds.Add(new Hold(TopBoundry, yMiddlePlusOne, RightBoundry, xMiddlePlusOne, Level + 1, MaxPoints));
		}

		//This function is called when we need to send a point to one of the sub holds.
		private void DepositPoint(Point point)
		{
			foreach (var hold in Holds)
			{
				if (hold.TakesThisPoint(point))
				{
					hold.AddPoint(point);
					return;
				}
			}
			throw new Exception("A point didn't fit in any of the available holds. Something is broken.");
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
