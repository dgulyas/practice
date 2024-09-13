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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null){
            return list2;
        }
        if(list2 == null){
            return list1;
        }
        
        ListNode combinedHead = new ListNode();
        ListNode combinedEnd = combinedHead;
        
        while(list1 != null && list2 != null){
            if(list1.val < list2.val){
                combinedEnd.next = list1;
                list1 = list1.next;
            }else{
                combinedEnd.next = list2;
                list2 = list2.next;
            }

            combinedEnd = combinedEnd.next;
        }

        if(list1 != null){
            combinedEnd.next = list1;
        }else if(list2 != null){
            combinedEnd.next = list2;
        }

        return combinedHead.next;
    }
}