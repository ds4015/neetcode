public class PrefixTree {
    List<List<char>> prefixTree = new List<List<char>>();


    public PrefixTree() {
        
    }
    
    public void Insert(string word) {
        List<char> w = new List<char>();    
        foreach (var c in word)
            w.Add(c);
        prefixTree.Add(w);
    }
    
    public bool Search(string word) {
        foreach (var w in prefixTree)
        {
            if (w[0] != word[0])
                continue;
            int m = 0;
            for (int i = 0; i < w.Count; i++)
            {
                if (i > word.Length-1)
                    break;
                if (w[i] != word[i])
                    break;
                m++;
            }
            if (m == w.Count)
                return true;
        }
        return false;
    }
    
    public bool StartsWith(string prefix) {      
        foreach (var w in prefixTree)
        {
            if (w[0] != prefix[0])
                continue;
            int m = 0;
            for (int i = 0; i < w.Count; i++)
            {
                if (i > prefix.Length-1)
                    break;
                if (w[i] != prefix[i])
                    break;
                m++;
            }
            if (m == prefix.Length)
                return true;
        }
        return false;
    }
}