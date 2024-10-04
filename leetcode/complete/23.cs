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
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists.Count() == 0){
            return null;
        }
        
        var heap = new PriorityQueue<ListNode, int>();
        for(int i = 0; i < lists.Count(); i++){
            if(lists[i] != null){
                heap.Enqueue(lists[i], lists[i].val);
            }
        }
        
        var answerHead = new ListNode();
        var answer = answerHead;

        while(heap.Count > 0){
            var nextNode = heap.Dequeue();
            answer.next = nextNode;
            answer = nextNode;
            if(answer.next != null){
                heap.Enqueue(answer.next, answer.next.val);
            }
        }
		
		//Probably not needed, since it's one of the ends of the lists
        answer.next = null;
		
		//head was set to an empty node, so return actual start of list
        return answerHead.next;
    }
}