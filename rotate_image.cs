public class Solution {
    public void Rotate(int[][] matrix) {
        for (int i = 0; i < matrix.Length - 1; i++)
        {
            for (int j = i; j < matrix.Length - 1; j++)
            {
                int temp = matrix[i][j+1];
                matrix[i][j+1] = matrix[j+1][i];
                matrix[j+1][i] = temp;
            }

        }
        foreach (var row in matrix)
            Array.Reverse(row);
    }
}