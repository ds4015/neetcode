public class Solution {
    public int Trap(int[] height) {
        if (height.Length == 1) return 0;

        /* break sequence up into 2 types of intervals */
        List<List<int>> fwdIntervals = new List<List<int>>();
        List<List<int>> bkwdIntervals = new List<List<int>>();

        int start = 0, end = height.Length-1;

        /* ignore edge runoff */
        while (height[start] <= height[start+1])
            start++;
        while (height[end] < height[end-1])
            end--;
        
        int i = start;

        while (i < end)
        {
            List<int> interval = new List<int>();
            interval.Add(height[i]);
            int j = i+1;

            if (height[i] == height[j]) {i++; continue;}

            /* foward interval: lg->small->lg */
            else if (height[i] > height[j])
            {
                while (j <= end && height[i] > height[j])
                {
                    interval.Add(height[j]);
                    j++;
                }
                /* passed the end w/o finding lg - runoff!
                    clear the interval and move on */
                if (j > end || (j < end && height[j] == height[j+1])) 
                { 
                    i++; 
                    interval.Clear(); 
                }
                /* otherwise add the interval to list of forwards */
                else
                { 
                    interval.Add(height[j]); 
                    fwdIntervals.Add(interval); 
                    i = j;
                }
            }
            /* backward interval: sm (after lg) ->lg */
            else
            {
                while (j <= end && height[i] < height[j])
                {
                    interval.Add(height[j]);
                    j++;
                }
                bkwdIntervals.Add(interval); i = j-1;
            }
        }

        int water = 0;
        /* forward interval water: # of midsection bars times
            left border height minus sum of midsection bars */
        foreach(var f in fwdIntervals)
        {
            int midSum = 0;
            for (int k = 1; k < f.Count-1; k++)
                midSum += f[k];
            int amount = (f.Count-2) * f[0] - midSum;
            water += amount;
        }
        /* backward interval water: sum of right border minus
            current height for all bars up to left border */
        foreach (var b in bkwdIntervals)
        {
            int e = b.Count-1;
            int amount = 0;
            for (int k = 0; k < e; k++)
                amount += (b[e] - b[k]);
            water += amount;
        }
        /* total water: forward + backward water */
        return water;
    }
}