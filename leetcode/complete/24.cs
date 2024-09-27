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
 //Instead of messing around with pointers, this code
 //is much easier to understand and debug.
 //There aren't enough nodes to worry using extra memory
 //for the list.
public class Solution {
    public ListNode SwapPairs(ListNode head) {
        if(head == null || head.next == null){
            return head;
        }

        //Make a list of refrences to the nodes
        var nodeList = new List<ListNode>();
        var pointer = head;
        while(pointer != null){
            nodeList.Add(pointer);
            pointer = pointer.next;
        }

        //Swap every pair of nodes
        var i = 0;
        while(i + 1 < nodeList.Count()){
            var x = nodeList[i];
            nodeList[i] = nodeList[i+1];
            nodeList[i+1] = x;
            i += 2;
        }

        //Rebuild the links
        for(i = 0; i < nodeList.Count() - 1; i++){
            nodeList[i].next = nodeList[i+1];
        }

        //Remove loop at end of list
        nodeList[nodeList.Count() -1].next = null;

        //Tada
        return nodeList[0];
    }
}