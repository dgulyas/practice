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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        if(head.next == null){
            return null;
        }

        var leader = head;
        for(int i = 0; i < n; i++){
            leader = leader.next;
        }

        if(leader == null){
            return head.next;
        }

        var follower = head;

        while(leader.next != null){
            leader = leader.next;
            follower = follower.next;
        }

        follower.next = follower.next.next;

        return head;
    }
}