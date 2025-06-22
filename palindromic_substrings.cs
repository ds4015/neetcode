public class Solution {
    public int CountSubstrings(string s) {
        int count = s.Length;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i+1; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    bool isPal = checkPalindrome(s, i, j);
                    if (isPal) count++;
                }
            }
        }
        return count;        
    }

    bool checkPalindrome(string s, int start, int end)
    {
        int st = start; int en = end;
        while (st < en)
        {
            if (s[st] == s[en])
            {
                st++;
                en--;
            }
            else break;
        }

        if(st != en + 1 && st != en)
            return false;
        return true;
    }
}