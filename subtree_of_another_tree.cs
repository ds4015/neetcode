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
    bool isSub = true;
    bool subRootFound = false;
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        /* base case */
        if (root == null)
            return false;

        /* same root-subroot val, check subtrees */
        if (root.val == subRoot.val)
        {
            subRootFound = true;

            /* if both childless, it's a match */
            if (root.left == null && subRoot.left == null &&
                root.right == null && subRoot.right == null)
                isSub = true;

            /* else check the subtrees */
            same = true;
            checkSubTree(root, subRoot);
            if (isSub) return true;
        }

        /* find next occurence of root-subroot match in tree */
        if (root.left != null)
        {
            IsSubtree(root.left, subRoot);
            if (isSub && subRootFound) return true;
        }
        if (root.right != null)
        {
            IsSubtree(root.right, subRoot);
            if (isSub && subRootFound) return true;
        }

        if (!subRootFound) return false;
        return false;
    }

    bool same = true;
    void checkSubTree(TreeNode r, TreeNode s)
    {        
        /* vals differ, not subtree */
        if (r.val != s.val)
        {
            same = false;
            isSub = false;
            return;
        }

        /* recurse if both children nonnull */
        if (r.left != null && s.left != null)
            checkSubTree(r.left, s.left);
        if (r.right != null && s.right != null)
            checkSubTree(r.right, s.right);           

        /* left-right null-nonnull mismatch, not subtree */
        if ((r.left == null && s.left != null) || 
            (r.left != null && s.left == null) ||
            (r.right == null && s.right != null) ||
            (r.right != null && s.right == null))
        {
            same = false;
            isSub = false;
            return;
        }

        if (!same) isSub = false;
        else isSub = true;
    }
}