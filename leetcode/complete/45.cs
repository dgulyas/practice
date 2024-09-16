namespace test;

class Program
{
    static void Main(string[] args)
    {
        var x = Jump([2,3,0,1,4]);
    }

    //It's 2am and this isn't my best work
    //There should be a more elegant solution
    //that automatically handles the edge cases
    //so fewer ifs and other things are needed.
    public static int Jump(int[] nums) {
        var minHopsFrom = new int[nums.Count()];
        minHopsFrom[minHopsFrom.Count() - 1] = 0;

        for(int i = nums.Count()-2; i >= 0; i--){
            if(nums[i] < 1){
                minHopsFrom[i] = 1000000;
                continue;
            }
            var minInWindow = -1;
            for(int j = 1; j <= nums[i]; j++){
                if(i+j > minHopsFrom.Count() - 1){
                    minInWindow = 0;
                }else if(minInWindow == -1 || minHopsFrom[i+j] < minInWindow){
                    minInWindow = minHopsFrom[i+j];
                }
            }
            minHopsFrom[i] = minInWindow + 1;
        }

        return minHopsFrom[0];
    }
}
