public class Solution {
    List<int> table = new List<int>();
    public int MinCostClimbingStairs(int[] cost) {
        for (int i = 0; i < cost.Length - 1; i++)
        {
            if (i == cost.Length - 2)
                table.Add(i+2);
            else if (cost[i] + cost[i+1] < cost[i] + cost[i+2])
                table.Add(i+1);
            else
                table.Add(i+2);
        }

        int cost0 = 0;
        int ind = 0;
        while (ind < cost.Length)
        {
            cost0 += cost[ind];
            if (ind > table.Count - 1)
                break;            
            ind = table[ind];
        }
        ind = 1;
        int cost1 = 0;
        while (ind < cost.Length)
        {
            cost1 += cost[ind];
            if (ind > table.Count - 1)
                break;
            ind = table[ind];
        }

        return Math.Min(cost0,cost1);        
    }
}