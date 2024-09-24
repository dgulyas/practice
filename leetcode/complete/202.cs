public class Solution {
    public bool IsHappy(int n) {
        var seenNumbers = new HashSet<int>();
        seenNumbers.Add(n);
        while(true){
            n = GetNextNumber(n);
            if(n == 1){
                return true;
            }
            if(seenNumbers.Contains(n)){
                return false;
            }
            seenNumbers.Add(n);
        }
    }

    private int GetNextNumber(int n){
        var sum = 0;
        while(n > 0){
            var nextDigit = n % 10;
            sum += nextDigit * nextDigit;
            n = n / 10;
        }
        return sum;
    }
}