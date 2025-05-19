public class Solution {
    public bool IsValidSudoku(char[][] board) {
        int[] rowCheck = new int[9];
        int[] colCheck = new int[9];
        for (int i = 0; i < rowCheck.Length; i++)
        {
            rowCheck[i] = 0;
            colCheck[i] = 0;
        }
        
        /* row check */
        for (int i = 0; i < board.Length; i++)
        {
            foreach (var num in board[i])
            {
                if (num != '.')
                {
                    rowCheck[(num - '0' - 1)] += 1;
                }
            }
            for (int k = 0; k < rowCheck.Length; k++)
            {
                if (rowCheck[k] > 1)
                    return false;
                rowCheck[k] = 0;
            }
        }


        /* col check */
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board.Length; j++)
            {
                if (board[j][i] != '.')
                    colCheck[(board[j][i] - '0' - 1)] += 1;
            }
            for (int k = 0; k < colCheck.Length; k++)
            {
                if (colCheck[k] > 1)
                    return false;
                colCheck[k] = 0;
            }
        }

        /* subgrid check */
        for (int i = 0; i < 9; i = i + 3)
        {
            for (int j = 0; j < 9; j = j + 3)
            {
                if (!checkSubgrid(board, i, j))
                    return false;
            }
        }

        return true;

    }

    private bool checkSubgrid(char[][] board, int row, int col)
    {
        int[] subgrid = new int[9];
        for (int k = 0; k < subgrid.Length; k++)
            subgrid[k] = 0;
        for (int i = row; i < row + 3; i++)
        {
            for (int j = col; j < col + 3; j++)
            {
                if (board[i][j] != '.')
                    subgrid[(board[i][j] - '0' - 1)] += 1;
            }
        }
        for (int k = 0; k < subgrid.Length; k++)
        {
            if (subgrid[k] > 1)
                return false;
        }
        return true;
    }
}
