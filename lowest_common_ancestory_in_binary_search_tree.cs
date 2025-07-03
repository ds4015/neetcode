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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        traverse(root);
        for (int i = 0; i < dpn.Count; i++)
            if (dpn[i].Contains(p.val) && dpn[i].Contains(q.val))
                return nodes[i];
        return root;
    }

    List<List<int>> dpn = new List<List<int>>();
    List<TreeNode> nodes = new List<TreeNode>();
    List<int> empty = new List<int>();

    List<int> traverse(TreeNode root)
    {
        if (root == null) return empty;
        List<int> left = traverse(root.left);
        List<int> right = traverse(root.right);
        List<int> descendants = new List<int>();
        descendants.Add(root.val);
        foreach (var l in left)
            descendants.Add(l);
        foreach (var r in right)
            descendants.Add(r);
        List<int> descCopy = new List<int>(descendants);
        dpn.Add(descCopy);
        nodes.Add(root);
        return descendants;
    }
}