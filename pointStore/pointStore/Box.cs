/*
This class defines a box in a 2D integer plane. Each property
defines the line that that side of the box lies on.
*/

namespace pointStore
{
	class Box
	{
		public int Top { get; set; }

		public int Bottom { get; set; }

		public int Left { get; set; }

		public int Right { get; set; }
	}
}
