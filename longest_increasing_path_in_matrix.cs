public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {

        for (int i = 0; i < matrix.Length; i++)
            for (int j = 0; j < matrix[0].Length; j++)
            {
                runningTotal = 0;
                visited.Clear();
                followPath(matrix, i, j, -1);
            }
        return maxPath;
    }

    List<List<int>> visited = new List<List<int>>();
    int runningTotal = 0;
    int maxPath = 0;
    void followPath(int[][] matrix, int row, int col, int lastValue)
    {
        if (matrix[row][col] > lastValue)
        {
            runningTotal++;
            List<int> c = new List<int>();
            c.Add(row); c.Add(col);
            visited.Add(c);
            lastValue = matrix[row][col];
        }
        else 
        {
            if (runningTotal > maxPath)
               maxPath = runningTotal;
            return;
        }

        if (row > 0 && !alreadyVisited(row-1, col))
            followPath(matrix, row-1, col, lastValue);
        if (row < matrix.Length-1 && !alreadyVisited(row+1, col))            
            followPath(matrix, row+1, col, lastValue);
        if (col > 0 && !alreadyVisited(row, col-1))
            followPath(matrix, row, col-1, lastValue);
        if (col < matrix[0].Length-1 && !alreadyVisited(row, col+1))
            followPath(matrix, row, col+1, lastValue);

        if (runningTotal > maxPath) maxPath = runningTotal;

        runningTotal--;
        visited.RemoveAt(visited.Count-1);
    }

    bool alreadyVisited(int row, int col)
    {
        foreach (var coord in visited)
            if (coord[0] == row && coord[1] == col)
                return true;
        return false;
    }
}