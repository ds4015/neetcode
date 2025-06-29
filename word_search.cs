public class Solution {
    public bool Exist(char[][] board, string word) {
        List<List<int>> possibilities = new List<List<int>>();

        /* find all possible starting points on board */
        for (int i = 0; i < board.Length; i++)
            for (int j = 0; j < board[0].Length; j++)
                if (board[i][j] == word[0])
                {
                    List<int> coord = new List<int>();
                    coord.Add(i); coord.Add(j);
                    possibilities.Add(coord);
                }
        
        /* check for word at each starting point */
        foreach (var p in possibilities)
        {
            checkLetter(board, p[0], p[1], word, 0);
            if (wordFound) return true;
            lettersFound.Clear();
        }
        return false;
    }

    bool wordFound = false;
    List<List<int>> lettersFound = new List<List<int>>();

    void checkLetter(char[][] board, int row, int col, 
                        string word, int letterNum)
    {
        /* base cases */
        if (board[row][col] == word[letterNum] && 
            letterNum == word.Length-1)
        { wordFound = true; return; }

        /* letter not found, backtrack */
        if (board[row][col] != word[letterNum]) return;

        /* letter found, add it to list to avoid inf loop */
        if (board[row][col] == word[letterNum]) 
        {
            List<int> coord = new List<int>();
            coord.Add(row); coord.Add(col);
            lettersFound.Add(coord); 
            letterNum++; /* move on to next letter */
        }

        /* check all 4 directions for next letter */
        if (row > 0 && !alreadyChecked(row-1, col, false))
        {
            checkLetter(board, row-1, col, word, letterNum);
            if (wordFound) return;
        }
        if (col < board[0].Length - 1 && !alreadyChecked(row, col+1, false))
        {
            checkLetter(board, row, col+1, word, letterNum);
            if (wordFound) return;
        }            
        if (row < board.Length - 1 && !alreadyChecked(row+1, col, false))
        {
            checkLetter(board, row+1, col, word, letterNum);
            if (wordFound) return;
        }
        if (col > 0 && !alreadyChecked(row, col-1, false))
        {
            checkLetter(board, row, col-1, word, letterNum);
            if (wordFound) return;
        }
        /* bad path, remove letter from found list and go back */
        alreadyChecked(row, col, true);
        letterNum--;
    }

    bool alreadyChecked(int row, int col, bool rmv)
    {
        for (int i = 0; i < lettersFound.Count; i++)
        {
            if (lettersFound[i][0] == row && lettersFound[i][1] == col)
            {
                if (rmv) lettersFound.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}