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
        if (head.next == null)
            return null;

        List<ListNode> stack = new List<ListNode>();

        ListNode origHead = head;
        while (head.next != null)
        {
            stack.Insert(0, head);
            head = head.next;
        }

        /* if n = 1, simply remove last node: set prev node's next to null */
        if (n == 1)
        {
            stack[0].next = null;
            return origHead;
        }

        int count = 1;

        while (count < n - 1)
        {
            head = stack[0];
            stack.RemoveAt(0);
            count++;
        }

        stack[0].next = null;
        stack.RemoveAt(0);
        if (stack.Count > 0)
            stack[0].next = head;
        else
            origHead = head;

        return origHead;

    }
}