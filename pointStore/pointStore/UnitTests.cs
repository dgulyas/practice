using System;
using System.Linq;
using NUnit.Framework;

namespace pointStore
{
	[TestFixture]
	class UnitTests
	{
		[Test]
		public void addPointToHoldTest()
		{
			var hold = new Hold(100, 0, 100, 0, 10);
			var point = new Point { X = 10, Y = 11, Value = 86 };

			hold.AddPoint(point);
			Assert.Contains(point, hold.Points);
		}

		[Test]
		public void holdStoresPointsTest()
		{
			var hold = new Hold(100, 0, 100, 0, 4);

			Assert.IsTrue(hold.StoresPoints);
			hold.AddPoint(new Point { X = 10, Y = 11, Value = 86 });
			hold.AddPoint(new Point { X = 20, Y = 70, Value = 86 });
			hold.AddPoint(new Point { X = 30, Y = 11, Value = 86 });
			hold.AddPoint(new Point { X = 70, Y = 70, Value = 86 });
			hold.AddPoint(new Point { X = 80, Y = 11, Value = 86 }); //This point causes the hold to split.
			Assert.IsFalse(hold.StoresPoints);
		}

		[Test]
		public void CreateSubHoldsTest()
		{
			var hold = new Hold(100, 0, 100, 0, 1);
			hold.AddPoint(new Point { Value = 10, Y = 90, X = 10 });
			hold.AddPoint(new Point { Value = 10, Y = 10, X = 10 });

			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 100 && h.BottomBoundry == 51 && h.RightBoundry == 100 && h.LeftBoundry == 51));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 100 && h.BottomBoundry == 51 && h.RightBoundry == 50 && h.LeftBoundry == 0));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 50 && h.BottomBoundry == 0 && h.RightBoundry == 100 && h.LeftBoundry == 51));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 50 && h.BottomBoundry == 0 && h.RightBoundry == 50 && h.LeftBoundry == 0));
			Assert.AreEqual(4, hold.Holds.Count);
		}

		[Test]
		public void CreateSubHoldsTestSkinny()
		{
			var hold = new Hold(100, 0, 2, 0, 1);
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 0 });
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 80 });

			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 100 && h.BottomBoundry == 51 && h.RightBoundry == 2 && h.LeftBoundry == 2));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 100 && h.BottomBoundry == 51 && h.RightBoundry == 1 && h.LeftBoundry == 0));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 50 && h.BottomBoundry == 0 && h.RightBoundry == 2 && h.LeftBoundry == 2));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 50 && h.BottomBoundry == 0 && h.RightBoundry == 1 && h.LeftBoundry == 0));
			Assert.AreEqual(4, hold.Holds.Count);
		}

		//If a hold is 1 dimensional it should only split in two.
		[Test]
		public void CreateSubHoldsTestVerticalLine()
		{
			var hold = new Hold(100, 0, 0, 0, 1);
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 0 });
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 80 });

			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 100 && h.BottomBoundry == 51 && h.RightBoundry == 0 && h.LeftBoundry == 0));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 50 && h.BottomBoundry == 0 && h.RightBoundry == 0 && h.LeftBoundry == 0));
			Assert.AreEqual(2, hold.Holds.Count);
		}

		[Test]
		public void CreateSubHoldsHoritintalLine()
		{
			var hold = new Hold(0, 0, 100, 0, 1);
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 0 });
			hold.AddPoint(new Point { Value = 10, X = 80, Y = 0 });

			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 0 && h.BottomBoundry == 0 && h.RightBoundry == 50 && h.LeftBoundry == 0));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 0 && h.BottomBoundry == 0 && h.RightBoundry == 100 && h.LeftBoundry == 51));
			Assert.AreEqual(2, hold.Holds.Count);
		}

		//if the hold in only a point it shouldn't split
		[Test]
		public void CreateSubHoldPoint()
		{
			var hold = new Hold(0, 0, 0, 0, 1);
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 0 });
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 0 });
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 0 });

			Assert.IsTrue(hold.StoresPoints);
			Assert.IsNull(hold.Holds);
		}

		[Test]
		public void LargestPointSinglePoint()
		{
			var hold = new Hold(100, 0, 100, 0);
			var point = new Point { Value = 10, X = 0, Y = 0 };
			hold.AddPoint(point);

			Assert.AreEqual(point, hold.LargestPoint);
		}

		[Test]
		public void LargestPointBasicMultiplePoints()
		{
			var hold = new Hold(100, 0, 100, 0);
			var largestPoint = new Point { Value = 10, X = 0, Y = 0 };
			hold.AddPoint(new Point { Value = 0, X = 10, Y = 0 });
			hold.AddPoint(new Point { Value = 1, X = 20, Y = 0 });
			hold.AddPoint(largestPoint);
			hold.AddPoint(new Point { Value = 2, X = 30, Y = 0 });
			hold.AddPoint(new Point { Value = 3, X = 40, Y = 0 });

			Assert.AreEqual(largestPoint, hold.LargestPoint);
		}

		[Test]
		public void LargestPointSplitHold()
		{
			var hold = new Hold(100, 0, 100, 0, 3);
			var largestPoint = new Point { Value = 10, X = 70, Y = 70 };
			hold.AddPoint(largestPoint);
			hold.AddPoint(new Point { Value = 0, X = 10, Y = 10 });
			hold.AddPoint(new Point { Value = 1, X = 10, Y = 70 });
			hold.AddPoint(new Point { Value = 2, X = 70, Y = 10 });

			Assert.AreEqual(largestPoint, hold.LargestPoint);
		}

		[Test]
		public void LargestPoint1000Points()
		{
			var hold = new Hold(100, 0, 100, 0, 10);
			var rand = new Random();

			for (int i = 0; i < 999; i++)
			{
				hold.AddPoint(new Point { Value = i, X = rand.Next(0, 101), Y = rand.Next(1, 101) });
			}

			var largestPoint = new Point { Value = 1000, X = rand.Next(0, 101), Y = rand.Next(1, 101) };
			hold.AddPoint(largestPoint);

			Assert.AreEqual(largestPoint, hold.LargestPoint);
		}

		[TestCase(50, 950, 50, 950)]
		[TestCase(500, 550, 0, 1000)]
		[TestCase(0, 1000, 500, 550)]
		public void GetLargestPointInBoxTest1(int boxBottom, int boxTop, int boxLeft, int boxRight) //This name sucks
		{
			var hold = new Hold(1000, 0, 1000, 0, 512);
			var rand = new Random(11);

			var box = new Box { Bottom = boxBottom, Top = boxTop, Left = boxLeft, Right = boxRight };
			var largestPoint = new Point { Value = 0, X = boxRight, Y = boxTop };
			hold.AddPoint(largestPoint);

			for (int i = 0; i < 1000000; i++)
			{
				var point = new Point { Value = i, X = rand.Next(1001), Y = rand.Next(1001) };
				if (pointIsInBox(point, box))
				{
					largestPoint = point; //each point has a larger value than the last
				}
				hold.AddPoint(point);
			}
			var tmp = hold.GetLargestPointInBox(box);

			Assert.AreEqual(largestPoint, tmp);
		}

		private bool pointIsInBox(Point point, Box box)
		{
			if (point.X > box.Right)
			{
				return false;
			}
			if (point.X < box.Left)
			{
				return false;
			}
			if (point.Y > box.Top)
			{
				return false;
			}
			if (point.Y < box.Bottom)
			{
				return false;
			}
			return true;
		}

	}
}
