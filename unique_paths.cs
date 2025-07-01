public class Solution {
    public int UniquePaths(int m, int n) {

        List<List<int>> queue = new List<List<int>>();

        List<int> coord = new List<int>();
        coord.Add(0);
        coord.Add(0);
        queue.Add(coord);

        queue = followPath(queue, m, n);
        return queue.Count;
    }

    List<List<int>> followPath(List<List<int>> queue, int m, int n)
    {
        if (checkIfDone(queue, m, n))
            return queue;
        List<List<int>> updQ = new List<List<int>>();
        foreach (var c in queue)
        {
            List<int> newCoord = new List<int>();
            /* add right square if not at edge */
            if (c[0] < m-1)
            {
                newCoord.Add(c[0]+1);
                newCoord.Add(c[1]);
                List<int> ncCopy = new List<int>(newCoord);
                updQ.Add(ncCopy);
            }
            newCoord.Clear();
            /* add down square if not at edge */
            if (c[1] < n-1)
            {
                newCoord.Add(c[0]);
                newCoord.Add(c[1]+1);
                List<int> ncCopy = new List<int>(newCoord);
                updQ.Add(ncCopy);
            }
        }
        return followPath(updQ, m, n);        
    }

    /* if all coords are at goal, return true */
    bool checkIfDone(List<List<int>> queue, int m, int n)
    {
        foreach (var p in queue)
        {
            if (p[0] != m-1 || p[1] != n-1)
                return false;
        }
        return true;
    }

}