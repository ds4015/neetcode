public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        int i = 0;
        List<List<int>> newInts = new List<List<int>>();

        /* empty intervals list - just add new and return */
        if (intervals.Length == 0)
        {
            List<int> empty = new List<int>();
            empty.Add(newInterval[0]); empty.Add(newInterval[1]);
            newInts.Add(empty);
        }

        /* process intervals list */
        while (i < intervals.Length)
        {
            List<int> interval = new List<int>();
            interval.Add(intervals[i][0]);
            interval.Add(intervals[i][1]);

            /* new smaller than first - add to front */
            if (i == 0 && newInterval[0] < intervals[i][0] &&
                    newInterval[1] < intervals[i][0])
            {
                List<int> first = new List<int>();
                first.Add(newInterval[0]);
                first.Add(newInterval[1]);
                newInts.Add(first);
                fillRest(newInts, intervals, i);
                break;
            }

            /* new subsumes entire interval - replace */
            if (newInterval[0] < intervals[i][0] &&
                newInterval[1] > intervals[i][1])
            {
                /* keep expanding until it stops subsuming */
                int b = i;
                while (b < intervals.Length && newInterval[1] > intervals[b][1])
                    b++;

                if (b == intervals.Length) b--;

                interval[0] = newInterval[0];
                interval[1] = newInterval[1];
                newInts.Add(interval);
                fillRest(newInts, intervals, b+1);
                break;
            }
            
            /* otherwise, find appropriate spot to insert */
            if (newInterval[0] > intervals[i][1])
            { 
                newInts.Add(interval); i++; 
                if (i == intervals.Length)
                {
                    List<int> newCopy = new List<int>(interval);
                    newCopy[0] = newInterval[0];
                    newCopy[1] = newInterval[1];
                    newInts.Add(newCopy);
                    break;
                }            
                continue; 
            }

            if (newInterval[1] < intervals[i][0])
            { 
                i--;
                newInts.RemoveAt(newInts.Count-1);
                interval[0] = intervals[i][0];
                interval[1] = intervals[i][1];
            }

            /* no prev interval, new start smaller than first */
            if (newInterval[0] < intervals[i][0])
            {
                List<int> newCopy = new List<int>(interval);
                newCopy[0] = newInterval[0];
                
                /* overlap with first, merge */
                newCopy[1] = intervals[i][1];
                newInts.Add(newCopy);
                break;
            }

            /* new does NOT overlap with previous interval */
            if (newInterval[0] > intervals[i][1])
            {
                newInts.Add(interval);
                List<int> intCopy = new List<int>(interval);

                /* does not overlap with next interval either - sandwich */
                if (newInterval[1] < intervals[i+1][0])
                {
                    intCopy[0] = newInterval[0];
                    intCopy[1] = newInterval[1];
                    newInts.Add(intCopy);
                    fillRest(newInts, intervals, i+1);
                    break;
                }

                /* does overlap with next interval - merge */
                int k = i;
                    /* keep expanding until it stops overlapping */
                while (newInterval[1] > intervals[k][1])
                    k++;

                intCopy[0] = newInterval[0];
                intCopy[1] = intervals[k][1];
                newInts.Add(intCopy);
                fillRest(newInts, intervals, k+1);
                break;
            }

            /* new DOES overlap with previous interval */
            if (newInterval[0] <= intervals[i][1])
            {
                /* fully within previous interval */
                if (newInterval[1] <= intervals[i][1])
                {
                    interval[0] = intervals[i][0];
                    interval[1] = intervals[i][1];
                    newInts.Add(interval);
                    fillRest(newInts, intervals, i+1);
                    break;
                }

                /* no next interval - update end to match new interval */
                if (i == intervals.Length - 1)
                {
                    interval[1] = newInterval[1];
                    newInts.Add(interval);
                    break;
                }

                /* doesn't overlap with next interval - only merge prev */
                if (newInterval[1] < intervals[i+1][0])
                {
                    interval[1] = newInterval[1];
                    newInts.Add(interval);
                    fillRest(newInts, intervals, i+1);
                    break;              
                }

                int l = i;
                /* also overlaps with next interval - merge both */
                while (newInterval[1] > intervals[l][1])
                    l++;  /* keep expanding while it overlaps */
                interval[0] = intervals[i][0];
                interval[1] = intervals[l][1];
                newInts.Add(interval);
                fillRest(newInts, intervals, l+1);
                break;
            }
            i++;
        }

        /* conv list back to jagged array for result */
        int[][] newIntervals = new int[newInts.Count][];
        int j = 0;
        foreach (var pair in newInts)
        {
            int[] p = new int[2];
            p[0] = pair[0]; p[1] = pair[1];
            newIntervals[j++] = p;
        }
        return newIntervals;
    }

    /* pad remaining intervals after insertion of new */
    void fillRest(List<List<int>> newInts, int[][] ints, int ind)
    {
        for (int i = ind; i < ints.Length; i++)
        {
            List<int> interval = new List<int>();
            interval.Add(ints[i][0]);
            interval.Add(ints[i][1]);
            newInts.Add(interval);
        }
    }
}