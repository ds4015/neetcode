public class Solution {
    public int CharacterReplacement(string s, int k) {
        char[] sArray = new char[s.Length];
        char[] sArraySorted = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            sArray[i] = s[i];
            sArraySorted[i] = s[i];
        }

        Array.Sort(sArraySorted);

        int count = 1;

        char[] letters = new char[s.Length];
        int[] freqs = new int[s.Length];

        int freq = 1;
        int ind = 0;


        for (int i = 1; i < sArraySorted.Length; i++)
        {
            Console.Write(sArraySorted[i-1]);
            if (sArraySorted[i] == sArraySorted[i-1])
                count++;
            else
            {
                letters[ind] = sArraySorted[i-1];
                freqs[ind++] = count;
                count = 1;
            }
            if (i == sArraySorted.Length - 1)
            {
                letters[ind] = sArraySorted[i];
                freqs[ind] = count;
            }
        }

        Array.Sort(freqs, letters);
        Array.Reverse(freqs);
        Array.Reverse(letters);
        int l = 0;

        int max = freqs[0];
        int c = 0;

        /* sort chars by frequency, get top 6 most frequent */
        for (int i = 0; i < freqs.Length; i++)
        {
            if (c < 7 && i < (freqs.Length - 1) && freqs[i] > max - 8)
                c++;
            else
                break;
        }

        char[] lettersToTest = new char[c];
        for (int i = 0; i < c; i++)
            lettersToTest[i] = letters[i];

        int total_length = 0;
        int max_window_size = s.Length;

        /* go through sliding windows for all 6 most frequent letters */
        for (int m = 0; m < lettersToTest.Length; m++)
        {
            int window_size = 1;

            while (window_size < max_window_size)
            {
                int i = 0;            
                int j = i + window_size;

                int repl = k;
                int start = 0;

                while (j < s.Length)
                {
                    int length = 0;
                    repl = k;

                    while (i <= j)
                    {
                        /* if letter not in frequent letters or is but not currently being 
                           checked, can replace it if sufficient k */
                        if ((!Array.Exists(lettersToTest, element => element == s[i]) || 
                            (Array.Exists(lettersToTest, element => element == s[i]) && 
                            s[i] != lettersToTest[m])) && repl > 0)
                        {
                            repl--;
                            length++;
                            i++;
                        }
                        else if (s[i] == lettersToTest[m])
                        {
                            i++;
                            length++;
                        }
                        else
                        {                       
                            if (length > total_length)
                                total_length = length;
                            length = 0;
                            i++;
                        }
                    }

                    if (length > total_length)
                        total_length = length;

                    i = start++;
                    j = i + window_size;
                }
                window_size++;
            }
        }
        return total_length;
    }
}