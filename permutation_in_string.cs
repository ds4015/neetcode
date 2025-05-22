public class Solution {
    public bool CheckInclusion(string s1, string s2) {

        /* only check window size that is length of s1 */
        int window_size = s1.Length;
        int max_window_size = s1.Length + 1;

        int i = 0;
        int j = i + window_size;
        bool permutationFound = false;

        while (window_size < max_window_size && !permutationFound)
        {
            while (j <= s2.Length && !permutationFound)
            {
                permutationFound = checkPermutation(s1, s2, i, j-1);
                i++;
                j++;
            }

            window_size++;
            i = 0;
            j = i + window_size;
        }
        return permutationFound;
    }

    bool checkPermutation(string s1, string s2, int s, int e)
    {
        char[] s2Window = new char[e - s + 1];

        char[] s1Chars = new char[s1.Length];

        for (int i = 0; i < s2Window.Length; i++)
        {
            s2Window[i] = s2[s++];
            s1Chars[i] = s1[i];
        }
        Array.Sort(s2Window);
        Array.Sort(s1Chars);

        for (int i = 0; i < s2Window.Length; i++)
            if (s2Window[i] != s1Chars[i])
                return false;

        return true;
    }
}