public class Solution {
    public string CountAndSay(int n) {
        var answer = "1";
        for(int i = 1; i < n; i++){
            answer = NextIteration(answer);
        }
        return answer;
    }

    
    private string NextIteration(string input){
        var answer = "";
        
        var curDigit = input[0];
        var curCount = 1;
        for(int i = 1; i < input.Length; i++){
            if(curDigit == input[i]){
                curCount++;
            }
            else{
                answer = answer + curCount + curDigit;
                curCount = 1;
                curDigit = input[i];
            }
        }
        answer = answer + curCount + curDigit;

        return answer;
    }
}