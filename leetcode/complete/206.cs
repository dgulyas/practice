//Have one pointer itterate through the list
//and another one following one node behind.
//For each node, get the next node, and then 
//have the current node point at the one behind it.

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
    public ListNode ReverseList(ListNode head) {
        var leader = head;
        ListNode follower = null;
        while (leader != null){
            var next = leader.next;
            leader.next = follower;
            follower = leader;
            leader = next;
        }
        return follower;
    }
}