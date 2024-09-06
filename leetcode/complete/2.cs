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
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {

		var carry = 0;
		var head = new ListNode();
		var answer = head;

		do
		{
			var sum = carry;
			carry = 0;

			if (l1 != null)
			{
				sum += l1.val;
				l1 = l1.next;
			}
			if (l2 != null)
			{
				sum += l2.val;
				l2 = l2.next;
			}

			if (sum > 9)
			{
				carry = 1;
				sum = sum - 10;
			}

			head.val = sum;
			if (l1 != null || l2 != null || carry > 0)
			{
				head.next = new ListNode();
				head = head.next;
			}
			else{
				break;
			}

		} while (true);

		return answer;
	}
}