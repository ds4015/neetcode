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

    int maxDepth = 0;
    int depth = 0;

    public int MaxDepth(TreeNode root) {
        if (root == null)
        {
            if (depth > maxDepth)
                maxDepth = depth;
            return depth;
        }
        depth++;
        MaxDepth(root.left);
        MaxDepth(root.right);
        depth--;
        
        return maxDepth;

    }
}