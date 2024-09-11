//This isn't the "proper" answer. There are stack based solutions that are
//O(n). This one is O(n^2), but prunes enough that it doesn't exceed the
//time limit.

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 });
        }

        public static int LargestRectangleArea(int[] heights)
        {
            var maxArea = 0;

            for(int i = 0; i < heights.Length; i++)
            {
                if(i > 0 && heights[i] == heights[i - 1])
                {
					//If this bar is the same height as the last bar,
					//we can skip it since it'll be included in the
					//previous rectangle.
                    continue;
                }

                var guess = GetSizeAtIndex(heights, i);
                if(guess > maxArea)
                {
                    maxArea = guess;
                }
            }

            return maxArea;
        }

        public static int GetSizeAtIndex(int[] heights, int i)
        {
			//Find the start and end of the rectangle with
			//height (heights[i]) that includes i.
            var start = i;
            while (true)
            {
                if(start == 0 || heights[start-1] < heights[i])
                {
                    break;
                }
                start--;
            }

            var end = i;
            while (true)
            {
                if (end >= heights.Length - 1 || heights[end + 1] < heights[i])
                {
                    break;
                }
                end++;
            }

            return (end - start + 1) * heights[i];
        }

    }
}