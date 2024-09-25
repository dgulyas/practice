public class Solution {
    public int TitleToNumber(string columnTitle) {
        int sum = 0;
        int placeValue = 1;
        for(int i = columnTitle.Length - 1; i >= 0; i--){
            sum += (columnTitle[i] - 64) * placeValue;
            placeValue *= 26;
        }
        return sum;
    }
}