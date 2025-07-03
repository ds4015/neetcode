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
    public int KthSmallest(TreeNode root, int k) {
        traverse(root);
        return order[k-1];
    }

    List<int> order = new List<int>();
    void traverse(TreeNode root)
    {
        if (root == null) return;

        traverse(root.left);
        order.Add(root.val);
        traverse(root.right);
    }
}