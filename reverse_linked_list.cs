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
    List<ListNode> stack = new List<ListNode>();

    public ListNode ReverseList(ListNode head) {
        if (head == null)
            return null;
        while (head.next != null)
        {
            stack.Insert(0, head);
            head = head.next;
        }

        ListNode newHead = head;

        while (stack.Count > 0)
        {
            head.next = stack[0];
            head = stack[0];
            stack.RemoveAt(0);
        }

        head.next = null;

        return newHead;
    }
}