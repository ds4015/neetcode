public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {

        List<int> marked = new List<int>();

        int row = 0; int col = 0; int s = 0;

        while (marked.Count < (matrix[0].Length * matrix.Length))
        {
            while (col < matrix[0].Length - s)
                    marked.Add(matrix[row][col++]);
            col--;
            row++;
            if (marked.Count == matrix[0].Length * matrix.Length)
                break;
            while (row < matrix.Length -s)          
                    marked.Add(matrix[row++][col]);
            row--;
            col--;
            if (marked.Count == matrix[0].Length * matrix.Length)
                break;
            while (col >= s)
                marked.Add(matrix[row][col--]);
            row--;
            col++;
            if (marked.Count == matrix[0].Length * matrix.Length)
                break;            
            while (row > s)
                marked.Add(matrix[row--][col]);
            s++;
            row++;
            col++;
        }
    return marked;
    }
}