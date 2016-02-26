using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			var hold = new Hold(100, 0, 100, 0, 0);
			hold.CreateSubHolds();

			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 100 && h.BottomBoundry == 51 && h.RightBoundry == 100 && h.LeftBoundry == 51));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 100 && h.BottomBoundry == 51 && h.RightBoundry == 50 && h.LeftBoundry == 0));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 50 && h.BottomBoundry == 0 && h.RightBoundry == 100 && h.LeftBoundry == 51));
			Assert.AreEqual(1,
				hold.Holds.Count(h => h.TopBoundry == 50 && h.BottomBoundry == 0 && h.RightBoundry == 50 && h.LeftBoundry == 0));
		}
	}
}
