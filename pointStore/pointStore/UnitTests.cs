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
			var hold = new Hold(100, 0, 100, 0, 0, 10);
			var point = new Point { X = 10, Y = 11, Value = 86 };

			hold.AddPoint(point);
			Assert.Contains(point, hold.Points);
		}

		[Test]
		public void holdStoresPointsTest()
		{
			var hold = new Hold(100, 0, 100, 0, 0, 4);

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
			var hold = new Hold(100, 0, 100, 0, 0, 1);
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
			var hold = new Hold(100, 0, 2, 0, 0, 1);
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
			var hold = new Hold(100, 0, 0, 0, 0, 1);
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
			var hold = new Hold(0, 0, 100, 0, 0, 1);
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
			var hold = new Hold(0, 0, 0, 0, 0, 1);
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 0 });
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 0 });
			hold.AddPoint(new Point { Value = 10, X = 0, Y = 0 });

			Assert.IsTrue(hold.StoresPoints);
			Assert.IsNull(hold.Holds);
		}

		//need to test that the highest value point is returned
	}
}
