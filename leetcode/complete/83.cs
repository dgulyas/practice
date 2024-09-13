/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if(head == null || head.next == null){
            return head;
        }

        var leader = head.next;
        var follower = head;

        while (leader != null){
            if(leader.val == follower.val){
                follower.next = leader.next;
            }else{
                follower = leader;
            }
            leader = leader.next;
        }
        return head;
    }
}