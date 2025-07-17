public class Solution {
    public int MinDistance(string word1, string word2) {
        return edit(word1,word2,0,0,0);
    }

    int edit(string w1, string w2, int a, int b, int edits)
    {
        if (a > w1.Length-1) 
        { 
            while(b < w2.Length)
                {edits++; b++;}
            return edits; 
        }
        else if (b > w2.Length-1) 
        { 
            while(a < w1.Length)
                {edits++; a++;}
            return edits; 
        }
        if (w1[a] == w2[b]) return edit(w1,w2,a+1,b+1,edits);
        else
        {
            int insert = edit(w1,w2,a+1,b,edits+1);
            int delete = edit(w1,w2,a,b+1,edits+1);
            int replace = edit(w1,w2,a+1,b+1,edits+1);
            int min = 9999;
            if (delete < min) min = delete;
            if (insert < min) min = insert;
            if (replace < min) min = replace;
            return min;            
        }
        return -1;
    }
}