public class Solution {
    public int StrStr(string haystack, string needle) {
        for(int i = 0; i < haystack.Length - needle.Length + 1; i++){
            var needleFound = true;
            for(int j = 0; j < needle.Length; j++){
                if(haystack[i+j] != needle[j]){
                    needleFound = false;
                }
            }
            if(needleFound){
                return i;
            }
        }

        return -1;
    }
}