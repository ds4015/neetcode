public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        foreach (var row in matrix)
        {
            int res = binarySearch(row, 0, row.Length, target);
            if (res != -1)
                return true;
        }
        return false;
        
    }

    int binarySearch(int[] row, int s, int e, int t)
    {
        if (e - s == 1 && row[0] == t)
            return row[s];
        
        if (e - s == 1 && row[0] != t)
            return -1;
        
        int mp = (e - s)/2;

        if (row[s+ mp] == t)
            return mp + mp;

        if (row[s + mp] < t)
            return binarySearch(row, mp + s, row.Length, t);
        
        if (row[s + mp] > t)
            return binarySearch(row, 0, mp, t);
        
        return -1;

    }
}