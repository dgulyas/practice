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
			var point = new Point { X = 10, Y = 11, Value = 86 };

			Assert.IsTrue(hold.StoresPoints);

			//when we add the 5th point the hold should split
			for (int i = 0; i < 5; i++)
			{
				hold.AddPoint(point);
			}
			Assert.IsFalse(hold.StoresPoints);
		}
	}
}
