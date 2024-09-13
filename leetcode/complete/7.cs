public class Solution {
    public int Reverse(int x) {
        var isNegative = x < 0;

        var strInt = x.ToString();

        //Remove the - char if present
        if(isNegative){
            strInt = strInt.TrimStart('-');
        }
        
        //convert to an array so we can reverse is easily
        var arrayInt = strInt.ToCharArray();
        Array.Reverse(arrayInt);
        strInt = new String(arrayInt);

        //remove any leading 0's and add back the - char if needed
        strInt = strInt.TrimStart('0');
        if(isNegative){
            strInt = "-" + strInt;
        }

        int.TryParse(strInt, out int reversedInt);

        return reversedInt;
    }
}