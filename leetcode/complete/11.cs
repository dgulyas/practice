public class Solution {
    public int MaxArea(int[] height) {
        int left = 0;
        int right = height.Length - 1;

        var maxWater = 0;

        while(left != right){
            var possibleMax = Area(height, left, right);
            if(possibleMax > maxWater){
                maxWater = possibleMax;
            }
            if(height[left] > height[right]){
                right--;
            }
            else{
                left++;
            }
        }

        return maxWater;
    }

    public int Area(int[] height, int left, int right){
        return Math.Min(height[left], height[right]) * (right - left);
    }
}