public class Solution {
    bool cycle = false;
    public bool ValidTree(int n, int[][] edges) {
        for (int i = 0; i < edges.Length; i++)
        {
            /* disconnected branch check */
            if (visited.Count > 0 && 
                !visited.Contains(edges[i][0]) && 
                !visited.Contains(edges[i][1]))
                return false;
            visited.Clear();
            detectCycle(edges, edges[i][0]);
            /* cycle detected in previous pass */
            if (cycle)
                return false;
            if (visited.Count == n) return true;
        }
        return true;
    }

    /* dfs - keep track of visited nodes */
    List<int> visited = new List<int>();
    void detectCycle(int[][] edges, int val)
    {
        if (visited.Contains(val))
        {
            cycle = true;
            return;
        }
        visited.Add(val);
        for (int i = 0; i < edges.Length; i++)
            if (edges[i][0] == val)
                detectCycle(edges, edges[i][1]);
    }
}