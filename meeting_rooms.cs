/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        List<int> start = new List<int>();
        List<int> end = new List<int>();
        foreach (var m in intervals)
        {
            start.Add(m.start);
            end.Add(m.end);
        }
        int[] s = start.ToArray();
        int[] e = end.ToArray();
        Array.Sort(s,e);

        for (int i = 1; i < s.Length; i++)
            if (s[i] < e[i-1])
                return false;
        return true;
    }
}