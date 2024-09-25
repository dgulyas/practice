public class Solution {
    public bool IsIsomorphic(string s, string t) {
        var sToT = new Dictionary<char, char>();
        var tToS = new Dictionary<char, char>();
        
        for(int i = 0; i < s.Length; i++){
            var sLetter = s[i];
            var tLetter = t[i];
            
            var seenSLetter = sToT.ContainsKey(sLetter);
            var seenTLetter = tToS.ContainsKey(tLetter);

            if(seenSLetter && !seenTLetter || seenTLetter && !seenSLetter){
                return false;
            }

            if(!seenSLetter){
                sToT[sLetter] = tLetter;
                tToS[tLetter] = sLetter;
            }else{
                if(sToT[sLetter] != tLetter || tToS[tLetter] != sLetter){
                    return false;
                }
            }
        }
        return true;
    }
}