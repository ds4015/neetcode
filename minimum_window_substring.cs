public class Solution {
    public string MinWindow(string s, string t) {

        int i = 0;
        char[] toCheck = t.ToArray();

        string currSubStr = "";
        string lastSubStr = "";
        while (i < s.Length)
        {
            bool keepSliding = false;            
            int j = i;
            char[] tArr = t.ToArray();
            string tCopy = new string(tArr);

            /* first instance of match in t */
            if (tCopy.Contains(s[j])) keepSliding = true;
            /* slide till end or all chars in t found */
            while (keepSliding)
            {
                currSubStr += s[j];
                if (tCopy.Contains(s[j]))
                {
                    int index = tCopy.IndexOf(s[j]);
                    tArr[index] = '.';
                    tCopy = new string(tArr);
                }
                j++;
                if (j > s.Length-1 || allCheckedCheck(tArr)) break;
            }

            /* if all chars in t found and substr new min, update */
            if (allCheckedCheck(tArr)) {
                if (lastSubStr.Equals("") || 
                    currSubStr.Length < lastSubStr.Length)
                {
                    lastSubStr = lastSubStr.Remove(0,lastSubStr.Length);
                    lastSubStr += currSubStr;                    
                }
            }
            currSubStr = currSubStr.Remove(0,currSubStr.Length);
            /* move on to next char in s and repeat */
            i++;
        }
        return lastSubStr;
    }

    bool allCheckedCheck(char[] toBeChecked)
    {
        foreach (var l in toBeChecked)
            if (l != '.')
                return false;
        return true;
    }
}