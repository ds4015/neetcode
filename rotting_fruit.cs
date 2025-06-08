public class Solution {
    List<(int,int)> queue = new List<(int,int)>();
    List<(int,int)> nextQueue = new List<(int,int)>();
    int minutes = 0;
    bool impossible = false;
    public int OrangesRotting(int[][] grid) {

        for (int i = 0; i < grid.Length; i++)
            for (int j = 0; j < grid[0].Length; j++)
                if (grid[i][j] == 2)
                    queue.Add((i,j));
        while(checkFresh(grid))
        {
            if (impossible)
                return -1;
            while (queue.Count > 0)
            {
                var (a,b) = queue[0];
                if (a < grid.Length - 1 && grid[a+1][b] == 1)
                {
                    grid[a+1][b] = 2;
                    nextQueue.Add((a+1,b));
                }
                if (a > 0 && grid[a-1][b] == 1)
                {
                    grid[a-1][b] = 2;
                    nextQueue.Add((a-1,b));                    
                }
                if (b < grid[0].Length - 1 && grid[a][b+1] == 1)
                {
                    grid[a][b+1] = 2;
                    nextQueue.Add((a,b+1));
                }                    
                if (b > 0 && grid[a][b-1] == 1)
                {
                    grid[a][b-1] = 2;
                    nextQueue.Add((a,b-1));
                }
                queue.RemoveAt(0);
            }
            minutes++;
            foreach (var (a,b) in nextQueue)
                queue.Add((a,b));
            nextQueue.Clear();
        }
        return minutes;
    }
    bool checkFresh(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    /* single column or row */
                    if (grid.Length == 1)
                    {
                        if (grid[0].Length == 1)
                            impossible = true;
                        else if (j == 0 && grid[i][j+1] == 0)
                            impossible = true;
                        else if (j == grid[0].Length - 1 && grid[i][j-1] == 0)
                            impossible = true;
                    }
                    else if (grid[0].Length == 1)
                    {
                        if (grid.Length == 1)
                            impossible = true;
                        else if (i == 0 && grid[i+1][j] == 0)
                            impossible = true;
                        else if (i == grid.Length - 1 && grid[i-1][j] == 0)
                            impossible = true;
                    }
                    /* corners */
                    else if (i == 0 && j == 0)
                    {           
                        if (grid[i+1][j] == 0 && grid[i][j+1] == 0)
                            impossible = true;
                    }
                    else if (i == 0 && j == grid[0].Length-1)
                    {
                        if (grid[i+1][j] == 0 && grid[i][j-1] == 0)
                            impossible = true;                            
                    }
                    else if (i == grid.Length-1 && j == 0)
                    {
                        if (grid[i-1][j] == 0 && grid[i][j+1] == 0)
                            impossible = true;
                    }
                    else if (i == grid.Length-1 && j == grid[0].Length-1)
                    {
                        if (grid[i-1][j] == 0 && grid[i][j-1] == 0)
                            impossible = true;
                    }
                    /* top edge */
                    else if (i == 0 && j > 0 && j < grid[0].Length - 1)
                    {
                        if (grid[i][j-1] == 0 && grid[i][j+1] == 0 && grid[i+1][j] == 0)
                            impossible = true;
                    }
                    /* bottom edge */
                    else if (i == grid.Length-1 && j > 0 && j < grid[0].Length - 1)
                    {
                        if (grid[i][j-1] == 0 && grid[i][j+1] == 0 && grid[i-1][j] == 0)
                            impossible = true;
                    }
                    /* left edge */
                    else if (j == 0 && i > 0 && i < grid.Length - 1)
                    {
                        if (grid[i+1][j] == 0 && grid[i-1][j] == 0 && grid[i][j+1] == 0)
                            impossible = true;                            
                    }
                    /* right edge */
                    else if (j == grid[0].Length-1 && i > 0 && i < grid.Length - 1)
                    {
                        if (grid[i+1][j] == 0 && grid[i-1][j] == 0 && grid[i][j-1] == 0)
                            impossible = true;
                    }
                    /* inner */
                    else if (grid[i + 1][j] == 0 && grid[i][j + 1] == 0 && grid[i - 1][j] == 0
                        && grid[i][j - 1] == 0)
                    {
                        impossible = true;
                    }

                    return true;
                }
            }
        }
        return false;
    }
}