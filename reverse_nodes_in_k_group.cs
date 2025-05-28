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
    public ListNode ReverseKGroup(ListNode head, int k) {

        List<ListNode> stack = new List<ListNode>();

        ListNode origHead = head;
        for (int i = 0; i < k - 1; i++)
            origHead = origHead.next;

        ListNode lastOfBatch = new ListNode();

        while (true)
        {
            for (int i = 0; i < k; i++)
            {
                if (head == null)
                    break;
                stack.Insert(0, head);
                head = head.next;
            }
            if (stack.Count < k)
                return origHead;
            
            ListNode cont = head;

            head = stack[0];
            lastOfBatch.next = head;
            while (stack.Count > 0)
            {
                stack.RemoveAt(0);
                if (stack.Count == 0)
                {
                    lastOfBatch = head;
                    head.next = cont;
                    head = head.next;
                    break;
                }
                head.next = stack[0];
                head = head.next;
            }
        }
    }
}