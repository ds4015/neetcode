public class Solution {
    bool cycle = false;
    public int CountComponents(int n, int[][] edges) {
        int components = 0;
        /* no edges - n discrete nodes */
        if (edges.Length == 0) return n;
        /* go through each val and perform dfs for components */
        for (int i = 0; i < n; i++)
        {
            cycle = false;
            if (!visited.Contains(i))
                dfs(edges, i);
            else
                continue;
            if (visited.Count == n)
            {
                components++;
                return components;
            }
            components++;
        }
        return components;
    }

    List<int> visited = new List<int>();
    void dfs(int[][] edges, int val)
    {
        if (!visited.Contains(val))
            visited.Add(val);
        else
        {
            cycle = true;
            return;
        }            
        /* connected components - either val in pair */
        for (int i = 0; i < edges.Length; i++)
            if (edges[i][0] == val)
                dfs(edges, edges[i][1]);
            else if (edges[i][1] == val)
                dfs(edges, edges[i][0]);
    }
}