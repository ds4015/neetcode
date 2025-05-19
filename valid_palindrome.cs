public class Solution {
    public bool IsPalindrome(string s) {

        s = s.Trim();
        s = s.ToLower();
        s = Regex.Replace(s, "[^a-z0-9]", String.Empty);

        int start = 0;
        int end = s.Length - 1;
        while (start < end)
        {
            if (s[start] != s[end])
                return false;
            start++;
            end--;
        }        
        return true;
    }
}
