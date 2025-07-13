public class Solution {
    public int NumDecodings(string s) {

        /* impossible check - 0 preceded by anything but 1 or 2 */
        if (s[0] - '0' == 0) return 0;
        for (int i = 1; i < s.Length; i++)
            if (s[i] == '0' && s[i-1] != '1' && s[i-1] != '2')
                return 0;

        List<List<int>> theWays = new List<List<int>>();
        List<int> first = new List<int>();
        first.Add(s[0] - '0');
        theWays.Add(first);

        for (int i = 1; i < s.Length; i++)
        {
            List<List<int>> toAdd = new List<List<int>>();
            /* for each valid permutaion thus far .. */
            for (int j = 0; j < theWays.Count; j++)
            {
                /* if 0 and preceding is 1 or 2, replace w/10 or 20 */
                if (s[i] == '0')
                {
                    if (s[i-1] != '1' && s[i-1] != '2') return 0;
                    if (theWays[j][theWays[j].Count-1] == 1)
                        theWays[j][theWays[j].Count-1] = 10;
                    else if (theWays[j][theWays[j].Count-1] == 2)
                        theWays[j][theWays[j].Count-1] = 20;
                }
                /* if 1, add single 1; if preceded by 1, add 11;
                    if preceded by 2, add 21 */
                else if (s[i] == '1')
                {
                    List<int> newJ = new List<int>(theWays[j]);
                    theWays[j].Add(1);
                    if (newJ[newJ.Count-1] == 1)
                    {
                        if (i < s.Length-1 && s[i+1] == '0')
                            continue;

                        newJ[newJ.Count-1] = 11;
                        toAdd.Add(newJ);
                    }
                    
                    else if (newJ[newJ.Count-1] == 2)
                    {
                        if (i < s.Length-1 && s[i+1] == '0')
                            continue;
                
                        newJ[newJ.Count-1] = 21;
                        toAdd.Add(newJ);
                    }              
                }
                /* if 2, add single 2; if preceded by 1, add 12;
                    if preceded by 2, add 22 */                
                else if (s[i] == '2')
                {
                    List<int> newJ = new List<int>(theWays[j]);
                    theWays[j].Add(2);
                    if (newJ[newJ.Count-1] == 1)
                    {
                        if (i < s.Length-1 && s[i+1] == '0')
                            continue;
                        newJ[newJ.Count-1] = 12;
                        toAdd.Add(newJ);
                    }
                    else if (newJ[newJ.Count-1] == 2)
                    {
                        if (i < s.Length-1 && s[i+1] == '0')
                            continue;
                        newJ[newJ.Count-1] = 22;
                        toAdd.Add(newJ);
                    }
                }
                /* if anything else, add single; if 1-6 preceded by
                    2, add 20 + X; if 1-9 preceded by 1, add 10 + X */ 
                else
                {
                    List<int> newJ = new List<int>(theWays[j]);
                    theWays[j].Add(s[i] - '0');
                    if (newJ[newJ.Count-1] == 2 && s[i] - '0' > 6) 
                        continue;
                    if (newJ[newJ.Count-1] == 1)
                    {
                        newJ[newJ.Count-1] = 10 + (s[i] - '0');
                        toAdd.Add(newJ);
                    }
                    else if (newJ[newJ.Count-1] == 2)
                    {
                        newJ[newJ.Count-1] = 20 + (s[i] - '0');
                        toAdd.Add(newJ);
                    }
                }
            }
            /* add new permutations at the end */
            foreach (var l in toAdd)
                theWays.Add(l);
        }
        return theWays.Count;
    }
}