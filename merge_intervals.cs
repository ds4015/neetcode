public class Solution {
    public int[][] Merge(int[][] intervals) {
        List<int> first = new List<int>();
        List<int> second = new List<int>();

        foreach (var pair in intervals)
        {
            first.Add(pair[0]);
            second.Add(pair[1]);
        }
        int[] firstArr = first.ToArray();
        int[] secondArr = second.ToArray();

        int[][] ints = new int[firstArr.Length][];
        Array.Sort(firstArr,secondArr);
        for (int i = 0; i < firstArr.Length; i++)
        {
            int[] pair = new int[2];
            pair[0] = firstArr[i];
            pair[1] = secondArr[i];
            ints[i] = pair;
        }
        
        List<int> merged = new List<int>();
        for (int i = 0; i < ints.Length-1; i++)
        {
            if (merged.Contains(i)) continue;
            int j = i + 1;
            while (j < ints.Length)
            {
                /* A contains B, B contains A, A trails B, or B trails A */
                        /* all conditions for overlap and merging */
                if ((ints[j][0] >= ints[i][0] && ints[j][1] <= ints[i][1]) ||
                    (ints[i][0] >= ints[j][0] && ints[i][1] <= ints[j][1]) ||
                    (ints[j][0] >= ints[i][0] && ints[j][0] <= ints[i][1] && 
                        ints[j][1] > ints[i][1]) ||
                    (ints[i][0] >= ints[j][0] && ints[i][0] <= ints[j][1] && 
                        ints[i][1] > ints[j][1]))
                {
                    ints[i][0] = Math.Min(ints[i][0],ints[j][0]);
                    ints[i][1] = Math.Max(ints[i][1],ints[j][1]);
                    ints[j][0] = -1; ints[j][1] = -1;
                    merged.Add(j);
                }
                j++;
            }
        }
        List<int[]> intvls = new List<int[]>();
        foreach (var p in ints)
        {
            if (p[0] == -1)
                continue;
            intvls.Add(p);
        }
        return intvls.ToArray();        
    }
}