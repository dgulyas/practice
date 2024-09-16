namespace test;

class Program
{
    static void Main(string[] args)
    {
        var x = ThreeSum(new int[] {-1,0,1,2,-1,-4});
    }

    public static IList<IList<int>> ThreeSum(int[] nums) {
        var numHash = new HashSet<int>(nums);
        var numArray = numHash.ToArray();
        Array.Sort(numArray);
        
        var answers = new List<IList<int>>();        

        for(int i = 0; i < numArray.Length; i++){
            for(int j = i+1; j < numArray.Length; j++ ){
                var numNeededFor0 = 0 - numArray[i] - numArray[j];
                if( numHash.Contains(numNeededFor0)){
                    answers.Add(new List<int>{numArray[i], numArray[j], numNeededFor0});
                }
            }
        }

        return answers;
    }
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
