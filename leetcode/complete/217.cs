public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        if(nums.Count() < 2){
            return false;
        }
        Array.Sort(nums);
        for(int i = 1; i < nums.Count(); i++){
            if(nums[i-1] == nums[i]){
                return true;
            }
        }
        return false;
    }
}