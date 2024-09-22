/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if(head == null || head.next == null){
            return false;
        }
        var leader = head;
        var follower = head;

        while(true){
            for(int i = 0; i < 2; i++){
                leader = leader.next;
                if(leader == null){
                    return false;
                }
                if(leader == follower){
                    return true;
                }
            }
            follower = follower.next;
        }
        return false;
    }
}