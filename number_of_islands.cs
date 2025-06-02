public class Solution {
    List<List<int>> islands = new List<List<int>>();
    List<List<int>> toBeProcessed = new List<List<int>>();
    List<int> island = new List<int>();
    int tbp = 0;

    public int NumIslands(char[][] grid) {
        /* number of squares to process */
        tbp = grid.Length * grid[0].Length;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                List<int> square = new List<int>();
                square.Add(i);
                square.Add(j);
                toBeProcessed.Add(square);
            }
        }

        /* process squares */
        while (tbp > 0)
        {
            int nextRow = toBeProcessed[0][0];
            int nextCol = toBeProcessed[0][1];
            List<int> isle = discoverIsland(grid, nextRow, nextCol);
            if (isle.Count > 0)
                islands.Add(isle);
            island.Clear();
        }
        return islands.Count;
    }

    List<int> discoverIsland(char[][] grid, int row, int col)
    {
        /* if water, backtrack */
        if (grid[row][col] == '0')
        {
            processSquare(row, col);
            return island;
        }
        
        int squareNum = row * grid[0].Length + col;
        island.Add(squareNum);
        processSquare(row, col);

        /* check all 4 directions (3 for edge squares) */
        if (row < grid.Length - 1 && needsProcessing(row + 1, col))
            discoverIsland(grid, row + 1, col);
        if (col > 0 && needsProcessing(row, col - 1))
            discoverIsland(grid, row,  col - 1);
        if (col < grid[0].Length - 1 && needsProcessing(row, col + 1))
            discoverIsland(grid, row, col + 1);     
        if (row > 0 && needsProcessing(row - 1, col))
            discoverIsland(grid, row - 1, col);
        return island;
    }

    /* remove a square from list if already processed */
    void processSquare(int row, int col)
    {
        bool removed = false;
        for (int i = 0; i < tbp; i++)
        {
                if (toBeProcessed[i][0] == row && toBeProcessed[i][1] == col)
                {
                    toBeProcessed.RemoveAt(i);
                    tbp--;
                    if (tbp == 0)
                        return;
                    removed = true;
                }
            if (removed)
                break;
        }
    }

    /* check to see if a square is still in the list to be processed */
    bool needsProcessing(int row, int col)
    {
        bool tbpr = false;
        for (int i = 0; i < tbp; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (toBeProcessed[i][0] == row && toBeProcessed[i][1] == col)
                    tbpr = true;
            }
            if (tbpr)
                break;
        }
        return tbpr;
    }
}