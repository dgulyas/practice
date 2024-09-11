//I copied the binary search algorithm from
//https://www.c-sharpcorner.com/blogs/binary-search-implementation-using-c-sharp1
//and modified it to deal with 2 dimensions.

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[3][]
            {
                new int []{1,2,3,4 },
                new int []{5,6,7,8 },
                new int []{9,10,11,12 }
            };
            var found = SearchMatrix(nums, 11);
        }

        public static bool SearchMatrix(int[][] matrix, int target)
        {
            var height = matrix.Length;
            var width = matrix[0].Length;

            int min = 0;
            int max = (height * width) - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (target == matrix[mid / width][mid % width])
                {
                    return true;
                }
                else if (target < matrix[mid / width][mid % width])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return false;
        }

    }
}