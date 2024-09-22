public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var nextEmptySpace = m+n-1;
        var currNums1 = m-1;
        var currNums2 = n-1;
        while(nextEmptySpace >= 0){
            if(currNums1 < 0)
            {
                nums1[nextEmptySpace] = nums2[currNums2];
                currNums2--;
            }
            else if (currNums2 < 0)
            {
                nums1[nextEmptySpace] = nums1[currNums1];
                currNums1--;
            }
            else if(nums2[currNums2] > nums1[currNums1])
            {
                nums1[nextEmptySpace] = nums2[currNums2];
                currNums2--;
            }
            else
            {
                nums1[nextEmptySpace] = nums1[currNums1];
                currNums1--;
            }
            nextEmptySpace--;
        }
    }
}