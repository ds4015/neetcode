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

public class Codec {

    /* format: root - left - right:
            ro le ri
            ro(Val) le (ro(Val)) ri (ro(Val))
            N = null
            recursive
            e.g., ro1lero2leNriNriro3leNriN 
            means root 1 has children 2 and 3
            which are leaf nodes */

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {

        if (root == null) return "N";

        string ro = "ro" + root.val.ToString() + "le";
        string le = Serialize(root.left) + "ri";
        string ri = Serialize(root.right);

        return ro + le + ri;        
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        if (data.Equals("N")) return null;

        int rootVal = data[2] - '0';
        TreeNode root = new TreeNode(rootVal);

        List<TreeNode> nodes = new List<TreeNode>();
        nodes.Add(root);

        int i = 4;
        /* go through serialized string */
        while (i < data.Length)
        {
            /* process left child */
            if (data[i] == 'e')
            {
                /* not null, get value of left child */
                if (data[i+1] == 'r')
                {
                    int k = i+3;
                    /* val may be more than 1 digit */
                    while (Char.IsNumber(data[k])) k++;
                    string valSubStr = data.Substring(i+3,k-(i+3));
                    int val = Int32.Parse(valSubStr);                    
                    /* create new left child and assign to parent */
                    TreeNode n = new TreeNode(val);
                    nodes[nodes.Count-1].left = n;
                    nodes.Add(n);
                    /* advance to right child */
                    i += (4 + valSubStr.Length);
                }
                else i += 3; /* left child is null, go to right child */
            }
            /* process right child */
            else if (data[i] == 'i')
            {
                /* right child not null */
                if (data[i+1] == 'r')
                {
                    int k = i+3;
                    while (Char.IsNumber(data[k])) k++;
                    string valSubStr = data.Substring(i+3,k-(i+3));
                    int val = Int32.Parse(valSubStr);
                    TreeNode n = new TreeNode(val);
                    nodes[nodes.Count-1].right = n;
                    /* parent node now has both children set, 
                        pop it for backtrack */                     
                    nodes.RemoveAt(nodes.Count-1);
                    nodes.Add(n); /* add right child to nodes */
                    i += (4 + valSubStr.Length);
                }
                else 
                {
                    /* right child is null, pop parent for backtrack */
                    nodes.RemoveAt(nodes.Count-1);                
                    i += 3;
                }
            }
        }        
        return root;
    }
}