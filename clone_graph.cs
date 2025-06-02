/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    List<int> cloned = new List<int>();
    List<Node> clonedNodes = new List<Node>();
    public Node CloneGraph(Node node) {
        if (node == null)
            return null;
        Node n = new Node(node.val);
        cloned.Add(n.val);
        clonedNodes.Add(n);

        for (int i = 0; i < node.neighbors.Count; i++)
        {
            if (!cloned.Contains(node.neighbors[i].val))
               n.neighbors.Add(CloneGraph(node.neighbors[i]));
            else
                n.neighbors.Add(clonedNodes[cloned.IndexOf(node.neighbors[i].val)]);
        }

        return n;
        
    }
}