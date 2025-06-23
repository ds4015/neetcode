public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {

        /* make 3 passes through string */
        for (int i = 0; i < 3; i++)
        {
            checkWords(s, wordDict);

            /* if last past failed, do another but
               skip found words from previous pass in order
               they were found to try different permutations */

            if (lettersProcessed.Count == s.Length)
                return true;
            lettersProcessed.Clear();
            /* add all the words found in previous pass to new
                do-not-check list for new pass */
            foreach (var w in wordsFoundInterim)
                if (!wordsFound.Contains(w))
                    wordsFound.Add(w);
        }        
        /* if still can't split after 3 passes, it's over */
        return false;
    }

    List<string> wordsFound = new List<string>();
    List<string> wordsFoundInterim = new List<string>();
    List<int> lettersProcessed = new List<int>();

    void checkWords(string s, List<string> wordDict)
    {
        List<char> word = new List<char>();
        int newWordStartsAt = 0;        

        /* go through string */
        for (int i = 0; i < s.Length; i++)
        {
            word.Add(s[i]);
            /* check dict for match after every char added */
            int wordInd = wordInDict(word, wordDict);
            if (wordInd != -1)
            {
                /* if match, add to interim do-not-check list and proceed */
                string theWord = string.Join("", word);
                if (!wordsFound.Contains(theWord)) {
                    for (int j = newWordStartsAt; j < newWordStartsAt + 
                                                    theWord.Length; j++)
                        lettersProcessed.Add(j);
                    wordsFoundInterim.Add(theWord);
                    if (wordsFound.Count > 0)
                        wordsFound.RemoveAt(0);
                    word.Clear();
                    newWordStartsAt = i+1;
                }
            }
        }
    }

    int wordInDict(List<char> word, List<string> dict)
    {
        int wordInd = 0;
        foreach (var w in dict)
        {
            if (word.Count != w.Length) continue;
            bool found = true;
            for (int i = 0; i < Math.Min(word.Count, w.Length); i++)
            {
                if (w[i] != word[i])
                {
                    found = false;
                    break;
                }
            }
            if (found) return wordInd;
            wordInd++;
        }
        return -1;            
    }
}