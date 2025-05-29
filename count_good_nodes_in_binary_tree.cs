/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    List<int> values = new List<int>();
    int goodNodes = 0;
    bool badNode = false;

    public int GoodNodes(TreeNode root) {
        if (root == null)
            return goodNodes;
        for (int i = 0; i < values.Count; i++)
            if (root.val < values[i])
                badNode = true;
        if (!badNode)
            goodNodes++;
        else
            badNode = false;
        /* store val in path list */
        values.Add(root.val);
        GoodNodes(root.left);
        GoodNodes(root.right);
        /* done processing, erase the node from comp list */
        values.RemoveAt(values.Count - 1);

        return goodNodes;         
    }
}