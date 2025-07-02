public class Solution {
    public List<int> PartitionLabels(string s) {

        List<List<char>> substrings = new List<List<char>>();

        for (int i = 0; i < s.Length; i++)
        {
            int listFoundIndex = 0;
            bool merge = false;
            for (int j = 0; j < substrings.Count; j++)
            {
                if (substrings[j].Contains(s[i]))
                {
                    merge = true;
                    substrings[j].Add(s[i]);
                    listFoundIndex = j;
                    break;
                }
            }
            if (!merge)
            {
                List<char> c = new List<char>();
                c.Add(s[i]);
                substrings.Add(c);
            }
            else
            {
                for (int k = substrings.Count-1; k > listFoundIndex; k--)
                {
                    substrings[k-1].AddRange(substrings[k]);
                    substrings.RemoveAt(k);
                }
            }
        }
        List<int> counts = new List<int>();
        foreach (var sub in substrings)
            counts.Add(sub.Count);
        return counts;        
    }
}