public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        List<List<int>> queue = new List<List<int>>();
        List<int> distances = new List<int>();
        List<List<int>> chests = new List<List<int>>();

        /* find chests */
        for (int i = 0; i < grid.Length; i++)
            for (int j = 0; j < grid[0].Length; j++)
                if (grid[i][j] == 0)
                {
                    List<int> chest = new List<int>();
                    chest.Add(i); chest.Add(j);
                    chests.Add(chest);
                }
        
        /* bfs from each chest outward */
        foreach (var c in chests)
        {
            queue.Add(c);
            distances.Add(0);
            List<List<int>> visited = new List<List<int>>();

            while (queue.Count > 0)
            {
                int row = queue[0][0];
                int col = queue[0][1];
                int currDist = distances[0];

                List<int> queuePos = new List<int>(queue[0]);

                queue.RemoveAt(0);
                distances.RemoveAt(0);                
                visited.Add(queuePos);

                /* water or another chest encountered, return */
                if (currDist != 0 && grid[row][col] <= 0) continue;
 
                /* update distance if new min */
                if (grid[row][col] > currDist)
                    grid[row][col] = currDist;

                /* bfs in 4 directions */
                List<int> up = new List<int>();
                up.Add(row-1); up.Add(col);
                List<int> down = new List<int>();
                down.Add(row+1); down.Add(col);
                List<int> left = new List<int>();
                left.Add(row); left.Add(col-1);                
                List<int> right = new List<int>();
                right.Add(row); right.Add(col+1);               

                /* only add to queue if in range and not already visited
                    and not already in queue */
                if (!alreadyVisited(queue,row-1,col) && 
                    !alreadyVisited(visited,row-1,col) && row > 0)
                {
                    queue.Add(up); 
                    distances.Add(currDist+1);
                }
                if (!alreadyVisited(queue,row+1,col) && 
                    !alreadyVisited(visited,row+1,col) && row < grid.Length-1)                    
                {
                    queue.Add(down);
                    distances.Add(currDist+1);
                }
                if (!alreadyVisited(queue,row,col-1) &&
                    !alreadyVisited(visited,row,col-1) && col > 0)
                {
                    queue.Add(left); 
                    distances.Add(currDist+1);
                }                    
                if (!alreadyVisited(queue,row,col+1) &&
                    !alreadyVisited(visited,row,col+1) && col < grid[0].Length-1)
                {
                    queue.Add(right);
                    distances.Add(currDist+1);
                }                    
            }
        }        
    }

    bool alreadyVisited(List<List<int>> visited, int row, int col)
    {
        foreach (var v in visited)
            if (v[0] == row && v[1] == col)
                return true;
        return false;
    }
}