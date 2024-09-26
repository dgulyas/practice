public class Solution {
    public string ConvertToTitle(int colNum) {
        var intAnswer = new List<int>();
        
        //This is standard logic for converting between
        //bases.
        //Example in base 10:
        //145 / 10 = 14
        //14 * 10 = 140
        //145 - 140 = 5 (The first number)
        //Repeat above steps with 14.
        while(colNum > 0){
            var quotient = colNum / 26;
            var remainder = colNum - (quotient * 26);
            intAnswer.Add(remainder);
            colNum = quotient;
        }

        //Since there is no zero in the alphabet, we
        //change and zero's into "10s" which are Z.
        //The next "letter" is incremented too soon.
        //This means that if the answer should be ZZZ, the
        //intAnswer right now will be 0,0,0,1. It should be
        //26,26,26.
        for(int i = 0; i < intAnswer.Count - 1; i++){
            while(intAnswer[i] <= 0){
                intAnswer[i] += 26;
                intAnswer[i+1]--;
            }
        }

        //If the answer is all Z's then there will be a leading
        //0 that needs to be removed before translating into letters.
        if(intAnswer.Last() == 0){
            intAnswer.RemoveAt(intAnswer.Count - 1);
        }

        //Convert the integers into the final answer.
        var answer = "";
        for(int i = 0; i < intAnswer.Count; i++){
            answer = (char)(intAnswer[i] + 64) + answer;
        }

        return answer;
    }
}