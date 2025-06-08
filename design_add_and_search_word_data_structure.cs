public class WordDictionary {

    List<List<char>> dictionary;

    public WordDictionary() {
        dictionary = new List<List<char>>();
    }
    
    public void AddWord(string word) {
        List<char> w = new List<char>();
        foreach (var c in word)
            w.Add(c);
        dictionary.Add(w);        
    }
    
    public bool Search(string word) {
        foreach (var w in dictionary)
        {
            int m = 0;
            int n = 0;
            for (int i = 0; i < w.Count; i++)
            {
                if (i > word.Length-1)
                    break;
                if (word[i] == '.')
                {
                    n++; m++; continue;
                }
                if (word[i] != w[i])
                    break;
                m++; n++;
            }
            if (m == word.Length && n == w.Count)
                return true;
        }
        return false;        
    }
}