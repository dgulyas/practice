/*
Once long ago I heard a programming problem that said:

You are given a list of points that are randomly placed on a 2d plane. Each point
has a value. Given a box on the plane, find the point that's A0inside the box and
B) has the highest value.

Sadly I can't find the original description of the problem, so I'm unsure if ints
or decimals were used for the coordinate system and don't remember what order of
magnitude everything was on. This solution makes the assumption that values and
coordinated are both ints.

The solution makes use of two classes.

Point: Contains the coordinates and value of a given point.

Hold: This class follows the Composite design pattern and has two modes.
In the first mode it acts as a list of points. When a point is added it checks
if contains too many points and if it does it switches to the second mode. The
second mode is a container that points to 4 other instances of Hold. This forms
a tree like structure where every internal node has degree 4, and the leafs
hold all the points. One optimization is that each node remembers the highest
value point that is contained among it's children.

Therefore to find the point with the greatest value we ask the question, does
the box we're given intersect or contain the current node? If it intersect it
we need to transverse down it. It if contains it we return that nodes
highest value point. Therefore our transversal only needs to go deeper if
a Hold is on the edge of the box we're given, and we ignore all nodes that
are irrelevant. When we our transversal reaches a leaf node we're forced to
iterate through all the points in that leaf.
*/

using System;
using System.Collections.Generic;

namespace pointStore
{
	class Program
	{
		static void Main(string[] args)
		{
			var hold = new Hold(1000, 0, 1000, 0, 0, 10);
			Random rnd = new Random(10);
			for (int i = 0; i < 100; i++)
			{
				var tmpPoint = new Point { Value = rnd.Next(1, 1000000), X = rnd.Next(0, 10001), Y = rnd.Next(0, 10001) };
				hold.AddPoint(tmpPoint);
			}

			hold.PrintData();

			Console.WriteLine();
		}
	}
}
