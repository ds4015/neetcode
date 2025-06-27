public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {

        List<int> indicesTried = new List<int>();

        while (indicesTried.Count < gas.Length)
        {
            int max = -9999;
            int start = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                if (indicesTried.Contains(i)) continue;
                if ((gas[i] - cost[i]) < 0) 
                { indicesTried.Add(i); continue; }

                if ((gas[i] - cost[i]) >= max) 
                {
                    max = gas[i] - cost[i]; 
                    start = i;
                }
            }
            route.Clear(); g = 0; nextIndex = start;
            travel(gas, cost, start);
            if (route.Count == gas.Length) return start;
            indicesTried.Add(start);
        }
        return -1;
    }

    int g = 0;
    int nextIndex = 0;
    List<int> route = new List<int>();
    void travel(int[] gas, int[] cost, int index)
    {
        if (route.Contains(index)) return;
        if (index == gas.Length-1)
            nextIndex = 0;
        else nextIndex++;
        
        g += gas[index];
        g -= cost[index];   
        if (g < 0) return;
        route.Add(index);
        travel(gas, cost, nextIndex);
    }
}