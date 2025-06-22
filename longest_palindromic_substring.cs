public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length == 1) return s.Substring(0,1);
        if (s.Length == 2 && s[0] == s[1]) return s.Substring(0,2);
        if (s.Length == 2 && s[0] != s[1]) return s.Substring(0,1);

        string palindrome = "";
        for (int i = 0; i < s.Length-1; i++)
        {
            for (int j = i+1; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {                 
                    string p = checkPalindrome(s, i, j);
                    if (p != "" && p.Length > palindrome.Length)
                        palindrome = p;
                }
            }
        }
        return palindrome;
    }

    string checkPalindrome(string s, int start, int end)
    {
        int st = start; int e = end;
        while (st < e)
        {
            if (s[st] == s[e])
            {
                st++;
                e--;
            }
            else break;
        }
        if (st != e + 1 && st != e)
            return "";
        return s.Substring(start, end-start+1);
    }
}