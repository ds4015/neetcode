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
    int diameter = 0;
    int curDiam = -1;

    public int DiameterOfBinaryTree(TreeNode root) {

        if (root == null)
        {
            if (curDiam > diameter)
                diameter = curDiam;
            return diameter;
        }
        curDiam++;
        if (root.left == null && root.right == null)
        {
            if (curDiam > diameter)
                diameter = curDiam;
            curDiam = 0;
        }
        DiameterOfBinaryTree(root.left);
        DiameterOfBinaryTree(root.right);
        curDiam++;

        return diameter;
        
    }
}