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
    List<ListNode> processedNodes = new List<ListNode>();

    public bool HasCycle(ListNode head) {
        while (head != null)
        {
            if (processedNodes.Contains(head.next))
                return true;
            else
                processedNodes.Add(head);
            head = head.next;
        }
        return false;
    }
}