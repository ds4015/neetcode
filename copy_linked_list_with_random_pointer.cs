/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {

        if (head == null)
            return null;

        Node origHead = head;
        Node newHead = new Node(head.val);
        head = head.next;
        Node origNewHead = newHead;

        /* first copy nodes */
        while (head != null)
        {
            Node newNode = new Node(head.val);
            newHead.next = newNode;
            newHead = newHead.next;
            head = head.next;
        }

        newHead = origNewHead;

        while (newHead != null)
            newHead = newHead.next;

        head = origHead;
        newHead = origNewHead;

        /* store indices/nodes in dict for copying random */
        Dictionary<int, Node> nodeList = new Dictionary<int, Node>();
        Dictionary<int, Node> nodeListCopy = new Dictionary<int, Node>();        
        int index = 1;
        while (head != null)
        {
            nodeList.Add(index, head);
            nodeListCopy.Add(index, newHead);
            head = head.next;
            newHead = newHead.next;
            index++;
        }

        head = origHead;
        newHead = origNewHead;

        while (head != null)
        {
            Node randNode = head.random;
            foreach (var k in nodeList.Keys)
            {
                if (nodeList[k] == randNode)
                    newHead.random = nodeListCopy[k];
            }
            newHead = newHead.next;
            head = head.next;
        }

        newHead = origNewHead;
        return newHead;        
    }
}