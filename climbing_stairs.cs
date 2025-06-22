public class Solution {
    List<int> table = new List<int>();
    public int ClimbStairs(int n) {
        table.Add(0);
        table.Add(1);
        table.Add(2);

        for (int i = 3; i <= n; i++)
            table.Add(table[i-1] + table[i-2]);
        return table[n];
    }
}