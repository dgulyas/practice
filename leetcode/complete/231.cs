public class Solution {
    public bool IsPowerOfTwo(int n) {
        if(n < 1){
            return false;
        }
        var bitString = Convert.ToString(n, 2);
        var num1s = bitString.Count(c => c == '1');
        var num0s = bitString.Count(c => c == '0');
        return num1s == 1 && num0s == bitString.Count() - 1;
    }
}