public class Solution {
    List<List<int>> checkedSquares = new List<List<int>>();
    List<List<int>> kissToHug = new List<List<int>>();
    bool surrounded = true; 

    public void Solve(char[][] board) {

        for (int i = 1; i < board.Length - 1; i++)
        {
            for (int j = 1; j < board[0].Length - 1; j++)
            {
                checkedSquares.Clear();
                surrounded = true;
                if (board[i][j] == 'O')
                    checkRegion(board, i, j);
                if (surrounded)
                    foreach (var k in kissToHug)
                        board[k[0]][k[1]] = 'X';
                kissToHug.Clear();
            }
        }
        
    }

    bool checkRegion(char[][] board, int row, int col)
    {
        List<int> c = new List<int>();
        c.Add(row); c.Add(col);
        checkedSquares.Add(c);

        if ((row == 0 || row == board.Length - 1 ||
            col == 0 || col == board[0].Length - 1))
        {
            if (board[row][col] == 'O')
                surrounded = false;
            return surrounded;
        } 

        if (board[row][col] == 'O')
            kissToHug.Add(c);
        else
            return surrounded;

        if (!alreadyChecked(row+1, col))
            checkRegion(board, row+1, col);
        if (!alreadyChecked(row, col-1))
            checkRegion(board, row, col-1);
        if (!alreadyChecked(row, col+1))
            checkRegion(board, row, col+1);
        if (!alreadyChecked(row-1, col))
            checkRegion(board, row-1, col);
        
        checkedSquares.Remove(c);
        return surrounded;   
    }

    bool alreadyChecked(int r, int c)
    {
        foreach (var s in checkedSquares)
            if (s[0] == r && s[1] == c)
                return true;
        return false;
    }

}