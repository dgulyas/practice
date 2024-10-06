public class Solution {
    //We're going to reorder the numbers in the array
    //such that all _positive_ numbers are in their matching 
    //index - 1. So 1 is in index 0, 2 is in index 1, ect.
    //Ex: [1,2,-4,4,0,-8,7]
    //Then we just go along the array and return the first
    //number that's not positive. If they're all positive
    //that means every integer in the array was a unique
    //positive int so return Count() + 1;
    public int FirstMissingPositive(int[] nums) {
        for(int i = 0; i < nums.Count(); i++){
            PutInPlace(nums, i);
        }

        for(int i = 0; i < nums.Count(); i++){
            if(nums[i] != i + 1){
                return i + 1;
            }
        }

        return nums.Count() + 1;
    }

    //Need to put a[i] in spot a[a[i] - 1], then repeat with what
    //was in that spot.
    private void PutInPlace(int[] nums, int index){
        var number = nums[index];
        
        //While:
        //  The number is positive
        //  The number can fit in the array
        //  The number isn't in it's proper place already
        //Keep putting numbers where they belong.
        while(number > 0 && number <= nums.Count() && nums[number - 1] != number){
            int tmp = nums[number - 1];
            nums[number - 1] = number;
            number = tmp;
        }
    }
}