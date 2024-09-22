public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        var hash = new HashSet<int>();
        for(int i = 0; i < nums.Count(); i++){
            if(i > k){
                hash.Remove(nums[i-(k+1)]);
            }
            
            if(hash.Contains(nums[i])){
                return true;
            }
            hash.Add(nums[i]);
            
        }
        return false;
    }
}