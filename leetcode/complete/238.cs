public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] fromStart = new int[nums.Length];
        int[] fromEnd = new int[nums.Length];
        int[] answer = new int[nums.Length];

        for(int i = 0; i < nums.Length; i++){
            var a = nums[i];
            if(i > 0){
                a = a * fromStart[i-1];
            }
            fromStart[i] = a;
        }

        for(int i = nums.Length -1; i >= 0; i--){
            var a = nums[i];
            if(i < nums.Length - 1){
                a = a * fromEnd[i+1];
            }
            fromEnd[i] = a;
        }

        for(int i = 0; i < answer.Length; i++){
            if (i == 0)
            {
                answer[i] = fromEnd[1];
            }
            else if (i == answer.Length - 1)
            {
                answer[i] = fromStart[answer.Length - 2];
            }else{
                answer[i] = fromStart[i-1] * fromEnd[i+1];
            }
        }

        return answer;
    }
}