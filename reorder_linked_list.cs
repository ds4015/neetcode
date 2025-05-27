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
    public void ReorderList(ListNode head) {
        if (head.next == null)
            return;

        List<ListNode> stack = new List<ListNode>();
        List<ListNode> revStack = new List<ListNode>();

        ListNode origHead = head;

        while (head.next != null)
        {
            stack.Insert(0, head);
            revStack.Add(head);
            head = head.next;
        }

        while (true)
        {
            revStack[0].next = head;
            revStack.RemoveAt(0);
            if (head == revStack[0])
            {
                head.next = null;
                break;
            }
            head.next = revStack[0];
            head = stack[0];
             if (revStack[0] == stack[0])
            {
                head.next = null;
                break;
            }
            stack.RemoveAt(0);
        }
        head = origHead;      
    }
}