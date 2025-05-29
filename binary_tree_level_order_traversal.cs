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

    List<TreeNode> lvl = new List<TreeNode>();
    List<TreeNode> lvl2 = new List<TreeNode>(); 
    List<List<TreeNode>> lot = new List<List<TreeNode>>();
    List<List<int>> lotV = new List<List<int>>();    

    public List<List<int>> LevelOrder(TreeNode root) {
        if (root == null)
            return lotV;
        if (lot.Count == 0) {
            lvl.Add(root);
            lot.Add(lvl);
        }
        int j = 0;
        while (j < lot.Count)
        {
            List<int> lvl2V = new List<int>();               
            foreach (var v in lvl)
            {
                lvl2.Add(v);
                lvl2V.Add(v.val);
            }
            lotV.Add(lvl2V);

            lvl.Clear();
            while(lvl2.Count > 0)
            {
                if (lvl2[0].left != null)
                    lvl.Add(lvl2[0].left);
                if (lvl2[0].right != null)
                    lvl.Add(lvl2[0].right);
                lvl2.RemoveAt(0);
            }
            if (lvl.Count > 0)
                lot.Add(lvl);
            lvl2.Clear();
            j++;
        }
        return lotV;        
    }
}