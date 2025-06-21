public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {

        if (!wordList.Contains(endWord))
            return 0;

        /* bfs to build adjacency lists */
        List<string> queue = new List<string>();
        List<List<string>> adjacency = new List<List<string>>();
        queue.Add(beginWord);

        List<string> processed = new List<string>();

        while (queue.Count > 0)
        {
            string word = queue[0];
            queue.RemoveAt(0);
            processed.Add(word);
            List<string> a = buildAdjList(word, wordList);
            foreach (var v in a)
                if (!processed.Contains(v) && !queue.Contains(v))
                    queue.Add(v);
            adjacency.Add(a);            
        }
        findPath(adjacency, 0, processed, endWord);
        return depth;        
    }

    /* helper for building adjacency lists */
    List<string> buildAdjList(string word, IList<string> list)
    {
        List<string> adj = new List<string>();
        foreach (var w in list)
        {
            int diff = 0;
            for (int i = 0; i < word.Length; i++)
                if (word[i] != w[i])
                    diff++;
            if (diff == 1)
                adj.Add(w);
        }
        return adj;
    }

    /* bfs to find min depth */
    int depth = 1;
    List<string> p = new List<string>();
    void findPath(List<List<string>> all, int index, List<string> pr, string target)
    {
        /* check adjacency lists sequentially */
        for (int j = 0; j < all.Count; j++)
        {
            if (p.Contains(pr[j]))
                continue;
            if (!all[j].Contains(target))
                depth++;
            else
            {
                depth++;
                return;
            }
            /* check all internal lists at current level for target */
            foreach (var m in all[j])
            {
                int ind = -1;
                for (int i = 0; i < pr.Count; i++)
                    if (pr[i] == m)
                        ind = i;

                /* return depth if found */
                if (all[ind].Contains(target))
                {
                    depth++;                
                    return;
                }
                p.Add(m);
            }
            /* not found at this level, proceed to next */
            depth++;
        }
        /* not found at all - depth set to 0 */
        depth = 0;
    }
}