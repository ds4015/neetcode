public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
            return false;

        char[] s_letters = new char[t.Length];
        char[] t_letters = new char[t.Length];
        for (int i = 0; i < t.Length; i++)
        {
            s_letters[i] = s[i];
            t_letters[i] = t[i];
            Console.WriteLine(s_letters[i]);
        }
        Array.Sort(s_letters);
        Array.Sort(t_letters);

        for (int i = 0; i < t.Length; i++)
            if (s_letters[i] != t_letters[i])
            return false;
        return true;
    }
}
