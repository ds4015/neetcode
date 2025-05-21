public class Solution {
    public int LengthOfLongestSubstring(string s) {

        int window_size = 1;
        int max_window_size = s.Length;

        if (s.Length == 0)
            return 0;

        int longest = 1;

        while (window_size < max_window_size)
        {
            int i = 0;
            int j = i + window_size;
            while (i + window_size < s.Length)
            {
                int length = checkDups(s, i, j);
                if (length > 0)
                    longest = length;
                i++;
                j = i + window_size;
            }       
            window_size++;
        }
        return longest;
    }

    private int checkDups(string s, int start, int end)
    {
        char[] windowChars = new char[end-start + 1];
        int j = 0;
        for (int i = start; i < end + 1; i++)
            windowChars[j++] = s[i];
        
        Array.Sort(windowChars);
        for (int i = 0; i < windowChars.Length - 1; i++)
            if (windowChars[i] == windowChars[i+1])
            {
                return -1;
            }
        
        return (end-start + 1);
    }
}