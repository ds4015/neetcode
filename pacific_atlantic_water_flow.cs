public class Solution {
    List<List<int>> pacAtl = new List<List<int>>();
    bool fromTheRiver = false;
    bool toTheSea = false;
    public List<List<int>> PacificAtlantic(int[][] heights) {
        for (int i = 0; i < heights.Length; i++)
        {
            for (int j = 0; j < heights[0].Length; j++)
            {
                seek(heights, i, j);
                if (fromTheRiver && toTheSea)
                {
                    List<int> coord = new List<int>();
                    coord.Add(i); coord.Add(j);
                    pacAtl.Add(coord);
                }
                fromTheRiver = false; toTheSea = false;
            }
        }
        return pacAtl;
    }

    List<List<int>> visited = new List<List<int>>();
    void seek(int[][] heights, int row, int col)
    {
        if (fromTheRiver && toTheSea)
            return;
        List<int> c = new List<int>();
        c.Add(row); c.Add(col);
        visited.Add(c);
        if (row == 0 || col == 0)
            fromTheRiver = true;
        if (row == heights.Length - 1 || col == heights[0].Length - 1)
            toTheSea = true;

        List<int> next = new List<int>();
        next.Add(row+1); next.Add(col);
        if (row < heights.Length - 1 && heights[row][col] >= heights[row+1][col] &&
            !visitedContains(next))
            seek(heights, row+1, col);
        next.Clear(); next.Add(row); next.Add(col-1);
        if (col > 0 && heights[row][col] >= heights[row][col-1] &&
            !visitedContains(next))
            seek(heights, row, col-1);
        next.Clear(); next.Add(row); next.Add(col+1);
        if (col < heights[0].Length - 1 && heights[row][col] >= heights[row][col+1] &&
            !visitedContains(next))
            seek(heights, row, col+1);
        next.Clear(); next.Add(row-1); next.Add(col);
        if (row > 0 && heights[row][col] >= heights[row-1][col] &&
            !visitedContains(next))
            seek(heights, row-1, col);
        visited.Remove(c);
        return;
    }

    bool visitedContains(List<int> element)
    {
        foreach (var l in visited)
            if (l[0] == element[0] && l[1] == element[1])
                return true;
        return false;
    }
}