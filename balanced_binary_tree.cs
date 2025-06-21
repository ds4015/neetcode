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
    bool b = true;
    int[] nodes = new int[1000];
    public bool IsBalanced(TreeNode root) {
        for (int i = 0; i < 1000; i++)
            nodes[i] = -1;
        traversal(root);
        if (!b) return false;
        return true;
    }

    int nodeNum = -1;
    int traversal(TreeNode r)
    {
        nodeNum++;
        if (r == null)
            return 0;
        
        int left = traversal(r.left);
        int right = traversal(r.right);

        if (Math.Abs(left - right) > 1)
            b = false;
        nodes[nodeNum] = Math.Max(left, right);
        return nodes[nodeNum] + 1;
    }
}