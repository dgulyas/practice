public class Solution {
    public uint reverseBits(uint n) {
        string binary = Convert.ToString(n, 2);
        binary = binary.PadLeft(32, '0');
                    
        uint answer = 0;
        uint pow2 = 1;
        for(int i = 0; i < binary.Length; i++){
            if(binary[i] == '1'){
                answer += pow2;
            }
            pow2 *= 2;
        }
        return answer;
    }
}