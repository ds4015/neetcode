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
    bool same = true;

    public bool IsSameTree(TreeNode p, TreeNode q) {

        if (p == null && q != null)
        {
            same = false;
            return same;
        }
        if (q == null && p != null)
        {
            same = false;
            return same;
        }
        if (p == null && q == null)
        {
            return same;
        }
        
        if (p.val != q.val)
        {
            same = false;
            return same;
        }

        IsSameTree(p.left, q.left);
        IsSameTree(p.right, q.right);
        
        return same;
    }
}