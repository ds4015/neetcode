public class Solution {
    int maxArea = 0;
    int area = 0;
    int squares = 0;

    public int MaxAreaOfIsland(int[][] grid) {
        squares = grid.Length * grid[0].Length;

        while (squares > 0)
        {
            int row = 0;
            int col = 0;
            bool foundNext = false;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == -1)
                        continue;
                    else
                    {
                        row = i;
                        col = j;
                        foundNext = true;
                        break;
                    }
                }
                if (foundNext)
                    break;
            }
            int islandArea = findIsland(grid, row, col);
            Console.WriteLine("islandArea = " + islandArea);
            if (islandArea > maxArea)
                maxArea = islandArea;
            Console.WriteLine("maxArea = " + maxArea);
            area = 0;
        }
        return maxArea;        
    }

    int findIsland(int[][] grid, int row, int col)
    {
        if (grid[row][col] == 0)
        {
            if (grid[row][col] == 0)
                squares--;
            grid[row][col] = -1;        
            return area;
        }
        grid[row][col] = -1;
        squares--;

        area++;
        
        if (row < grid.Length - 1 && grid[row+1][col] != -1)
            findIsland(grid, row + 1, col);
        if (col > 0 && grid[row][col-1] != -1)
            findIsland(grid, row, col - 1);
        if (col < grid[0].Length - 1 && grid[row][col+1] != -1)
            findIsland(grid, row, col + 1);
        if (row > 0 && grid[row-1][col] != -1)
            findIsland(grid, row-1, col);

        return area;
    }
}