/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        if(headA == null || headB == null){
            return null;
        }
        var seenNodes = new HashSet<ListNode>();
        var aPointer = headA;
        while(aPointer!= null){
            seenNodes.Add(aPointer);
            aPointer = aPointer.next;
        }
        var bPointer = headB;
        while(bPointer != null){
            if(seenNodes.Contains(bPointer)){
                return bPointer;
            }
            bPointer = bPointer.next;
        }

        return null;        
    }
}