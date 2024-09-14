namespace test;

class Program
{
    static void Main(string[] args)
    {
        //var theList = new ListNode(1, new ListNode(4, new ListNode(3,new ListNode(2, new ListNode(5, new ListNode(2))))));
        //var theList = new ListNode(1);
        var theList = new ListNode(1, new ListNode(1));
        var x = Partition(theList, 0);
    }

    public static ListNode Partition(ListNode head, int x) {
        if(head == null || head.next == null){
            return head;
        }
        
        //Create two lists, one holding the larger and one the lesser nodes
        ListNode lessThanHead = null;
        ListNode lessThan = null;
        ListNode greaterOrEqualHead = null;
        ListNode greaterOrEqual = null;

        //As we walk down the list, add the nodes to one of the two new lists
        var traveller = head;
        while (traveller != null){
            if(traveller.val < x){
                if(lessThanHead == null){
                    lessThanHead = traveller;
                    lessThan = lessThanHead;
                }else{
                    lessThan.next = traveller;
                    lessThan = traveller;
                }
            }else{
                if(greaterOrEqualHead == null){
                    greaterOrEqualHead = traveller;
                    greaterOrEqual = greaterOrEqualHead;
                }else{
                    greaterOrEqual.next = traveller;
                    greaterOrEqual = traveller;
                }
            }
            traveller = traveller.next;
        }

        //The end of the larger list could still be pointed at some
        //smaller node
        if(greaterOrEqual != null){
            greaterOrEqual.next = null;
        }

        //If all nodes are greater, than just return that list
        if(lessThan == null){
            return greaterOrEqualHead;
        }

        //Append the two lists
        lessThan.next = greaterOrEqualHead;

        return lessThanHead;
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
