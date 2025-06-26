public class Solution {
    public void SetZeroes(int[][] matrix) {

        List<List<int>> queue = new List<List<int>>();

        for (int i = 0; i < matrix.Length; i++)
            for (int j = 0; j < matrix[0].Length; j++)
                if (matrix[i][j] == 0)
                {
                    List<int> coords = new List<int>();
                    coords.Add(i); coords.Add(j); 
                    queue.Add(coords);
                }

        foreach (var c in queue)
            setZero(matrix, c[0], c[1]);
    }

    void setZero(int[][] matrix, int row, int col)
    {
        for (int i = 0; i < matrix[row].Length; i++)
            matrix[row][i] = 0;
        for (int i = 0; i < matrix.Length; i++)
            matrix[i][col] = 0;
    }
}