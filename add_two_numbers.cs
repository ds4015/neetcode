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
        List<ListNode> stack1 = new List<ListNode>();
        List<ListNode> stack2 = new List<ListNode>();
        List<ListNode> sumStack = new List<ListNode>();

        ListNode h1 = l1;
        ListNode h2 = l2;

        while (h1 != null)
        {
            stack1.Add(h1);
            h1 = h1.next;
        }
        while (h2 != null)
        {
            stack2.Add(h2);
            h2 = h2.next;
        }

        List<ListNode> sumList = new List<ListNode>();


        int carry = 0;

        while (stack1.Count > 0 && stack2.Count > 0)
        {
            int sum = stack1[0].val + stack2[0].val + carry;
            if (sum > 9) {
                carry = 1;
                sum -= 10;
            } else {
                carry = 0;
            }

            ListNode digit = new ListNode(sum);
            sumStack.Add(digit);
            stack1.RemoveAt(0);
            stack2.RemoveAt(0);
        }

        while (stack1.Count > 0)
        {
            int sum = stack1[0].val + carry;
            if (sum > 9) {
                carry = 1;
                sum -= 10;
            } else {
                carry = 0;
            }
            ListNode digit = new ListNode(sum);
            sumStack.Add(digit);
            stack1.RemoveAt(0);
        }
        while (stack2.Count > 0)
        {
            int sum = stack2[0].val + carry;
            if (sum > 9) {
                carry = 1;
                sum -= 10;
            } else {
                carry = 0;
            }
            ListNode digit = new ListNode(sum);
            sumStack.Add(digit);
            stack2.RemoveAt(0);
        }
        if (carry == 1)
        {
            ListNode digit = new ListNode(1);
            sumStack.Add(digit);
            carry = 0;
        }
        sumStack.Reverse();
        while (sumStack.Count > 0)
        {
            if (sumList.Count == 0)
                sumStack[0].next = null;
            else
                sumStack[0].next = sumList[0];
            
            sumList.Insert(0, sumStack[0]);
            sumStack.RemoveAt(0);
        }

        return sumList[0];
    }
}