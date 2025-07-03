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
    public bool IsValidBST(TreeNode root) {
        traverse(root);

        if (!valid) return false;
        return true;
    }

    bool valid = true;
    List<int> empty = new List<int>();
    List<int> traverse(TreeNode root)
    {
        if (!valid || root == null) return empty;

        List<int> left = traverse(root.left);
        List<int> right = traverse(root.right);

        foreach (var l in left)
            if (l >= root.val)
                valid = false;
        if (!valid) return empty;
        foreach (var r in right)
            if (r <= root.val)
                valid = false;
        if (!valid) return empty;
        List<int> descendants = new List<int>();
        descendants.Add(root.val);
        foreach (var l in left)
            descendants.Add(l);
        foreach (var r in right)
            descendants.Add(r);
        return descendants;
    }
}