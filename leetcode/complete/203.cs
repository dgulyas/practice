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
    public ListNode RemoveElements(ListNode head, int val) {
        var newHead = head;
        while(newHead != null && newHead.val == val){
            newHead = newHead.next;
        }
        if(newHead == null){
            return newHead;
        }
        var follower = newHead;
        var leader = newHead.next;
        while(leader != null){
            if(leader.val == val){
                follower.next = leader.next;
            }else{
                follower = leader;
            }
            leader = leader.next;
        }
        return newHead;
    }
}