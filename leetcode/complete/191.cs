//This isn't a "proper" solution.
//A better one would see if n is greater than
//successively smaller powers of 2 and minus
//the power from n, counting how many times
//that happens until n is 0.
//But this was fun to write in one line.

public class Solution {
    public int HammingWeight(int n) {
        return Convert.ToString(n, 2).Count(c => c == '1');
    }
}