public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> anagramGroups = new List<List<string>>();
        for (int i = 0; i < strs.Length; i++)
        {
            List<string> otherWords = new List<string>();
            otherWords.AddRange(strs);
            otherWords.RemoveRange(0, i+1);

            List<string> anagrams = new List<string>();

            /* if word not already in anagram groups, get its anagrams */
            if (!checkGroupsForExisting(strs[i], anagramGroups))
            {
                anagrams = GetAnagrams(strs[i], otherWords);
                anagramGroups.Add(anagrams);
            }
        }
        return anagramGroups;
    }

    /* get all anagrams in list for given word */
    private List<string> GetAnagrams(string word, List<string> otherWords)
    {        
        List<string> anagrams = new List<string>();

        /* last word in list - single: add to anagrams and return */
        if (otherWords.Count == 0)
        {
            anagrams.Add(word);
            return anagrams;
        }

        /* check if original word has already been added to anagrams */
        bool dupAlreadyAdded = false;

        for (int i = 0; i < otherWords.Count; i++)
        {
            /* skip if not same length */
            if (word.Length != otherWords[i].Length)
                continue;

            /* if same word encountered, add both to anagrams list */
            if (word.Equals(otherWords[i]))
            {
                /* only add orig word if it hasn't been added yet */
                if (!dupAlreadyAdded)
                {
                    anagrams.Add(word);
                    dupAlreadyAdded = true;
                }
                anagrams.Add(word);
                continue;
            }

            char[] word_letters = new char[word.Length];
            char[] othWord_letters = new char[otherWords[i].Length];

            for (int j = 0; j < word.Length; j++)
            {
                word_letters[j] = word[j];
                othWord_letters[j] = otherWords[i][j];
            }

            /* sort and compare the letters of both words */
            Array.Sort(word_letters);
            Array.Sort(othWord_letters);

            bool wordsMatch = true;

            for (int j = 0; j < word.Length; j++)
            {
                if (word_letters[j] != othWord_letters[j])
                {
                    wordsMatch = false;
                    break;
                }
            }

            /* not an anagram, continue to next word in list */
            if (!wordsMatch)
                continue;

            /* otherwise, an anagram - add both if not already in the list */
            if (!anagrams.Contains(word))
                anagrams.Add(word);
            if (!anagrams.Contains(otherWords[i]))
                anagrams.Add(otherWords[i]);
        }

        /* if no anagrams found, just add the word as its own anagram */
        if (anagrams.Count == 0)
            anagrams.Add(word);
          
        return anagrams;
    }

    /* check if a word is already in anagram groups to exclude it */
    bool checkGroupsForExisting(string word, List<List<string>> groups)
    {
        for (int i = 0; i < groups.Count; i++)
        {
            for (int j = 0; j < groups[i].Count; j++)
            {
                if (groups[i][j].Equals(word))
                    return true;
            }
        }
        return false;
    }
}