//This is the dumb and fast solution.
//There's a more complicated solution where you
//go through the array swapping each number
//to the front or back of the array
//and keep pointers to the next place to swap.
//This wouldn't destroy the existing values
//in the case that they weren't just ints, but
//actual data-filled objects.

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1, 2, 0 };
            SortColors(nums);
        }

        public static void SortColors(int[] nums)
        {
            var num0 = 0;
            var num1 = 0;
            var num2 = 0;
            for(int i  = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    num0++;
                }
                else if (nums[i] == 1)
                {
                    num1++;
                }
                else if (nums[i] == 2)
                {
                    num2++;
                }
            }

            for(int i = 0; i < num0; i++)
            {
                nums[i] = 0;
            }
            for (int i = num0; i < num0 + num1; i++){
                nums[i] = 1;
            }
            for(int i = num0 + num1; i < nums.Length; i++)
            {
                nums[i] = 2;
            }
        }

    }
}