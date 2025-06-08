public class Solution {
    List<string> foundWords = new List<string>();
    List<List<int>> processed = new List<List<int>>();   
    bool wordFound = false;
    public List<string> FindWords(char[][] board, string[] words) {
        foreach (var w in words)
        {
            wordFound = false;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == w[0])
                    {
                        processed.Clear();
                        bool found = search(board, i, j, w, 0);
                        if (found)
                        {
                            foundWords.Add(w);
                            break;
                        }
                    }
                }
                if (wordFound)
                    break;
            }
        }
        return foundWords;        
    }


    bool search(char[][] board, int row, int col, string word, int ind)
    {
        if (ind < word.Length)
            Console.WriteLine(word + ": " + word[ind]);
        if (ind == word.Length)
        {
            wordFound = true;
            return wordFound;
        }
        List<int> c = new List<int>();
        c.Add(row); c.Add(col);
        processed.Add(c);

        if (board[row][col] == word[ind++])
        {
            if (row < board.Length-1 && !alreadyChecked(row+1, col) && !wordFound)
                search(board, row+1, col, word, ind);
            if (col > 0 && !alreadyChecked(row, col-1) && !wordFound)
                search(board, row, col-1, word, ind);
            if (col < board[0].Length-1 && !alreadyChecked(row, col+1) && !wordFound)
                search(board, row, col+1, word, ind);
            if (row > 0 && !alreadyChecked(row-1, col) && !wordFound)
                search(board, row-1, col, word, ind);
            
            if (ind == word.Length)
                wordFound = true;
        }
        processed.Remove(c);
        return wordFound;
    }

    bool alreadyChecked(int row, int col)
    {
        foreach (var l in processed)
            if (l[0] == row && l[1] == col)
                return true;
        return false;
    }
}