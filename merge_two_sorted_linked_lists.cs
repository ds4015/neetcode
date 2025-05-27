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

        if (list1 == null && list2 != null)
            return list2;
        else if (list2 == null && list1 != null)
            return list1;
        else if (list1 == null && list2 == null)
            return null;

        List<ListNode> mergedList = new List<ListNode>();

        /* compare values for merging */
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                mergedList.Add(list1);
                if (list1.next != null && list1.next.val <= list2.val)
                {
                    mergedList.Add(list1.next);
                    list1 = list1.next;
                }
                else if (list2.next != null && list2.val < list1.next.val)
                {
                    mergedList.Add(list2);
                    list2 = list2.next;
                }
                list1 = list1.next;
            }
            else if (list2.val < list1.val)
            {
                mergedList.Add(list2);
                if (list2.next != null && list2.next.val <= list1.val)
                {
                    mergedList.Add(list2.next);
                    list2 = list2.next;
                }
                else if (list1.next != null && list1.val < list1.next.val)
                {
                    mergedList.Add(list1);
                    list1 = list1.next;
                }
                list2 = list2.next;
            }
        }

        /* at least one list processed - add remainder of other list */
        if (list1 == null)
        {
            while (list2 != null)
            {
                mergedList.Add(list2);
                list2 = list2.next;
            }
        }
        else if (list2 == null)
        {
            while (list1 != null)
            {
                mergedList.Add(list1);
                list1 = list1.next;
            }
        }

        /* set the next links in the final merged list */
        for (int i = 0; i < mergedList.Count - 1; i++)
            mergedList[i].next = mergedList[i+1];
        
        mergedList[mergedList.Count - 1].next = null;

        return mergedList[0];
    }
}