public class Solution {
    public List<string> LetterCombinations(string digits) {
        buildStrings(digits, 0, "");
        return combos;
    }

    List<string> combos = new List<string>();
    void buildStrings(string digits, int index, string current)
    {
        if (index > digits.Length-1) {
            if (current != "")
                combos.Add(current); 
            return;
        }

        string letters = returnPattern(digits[index]);

        foreach (var l in letters)
        {
            current += l;
            buildStrings(digits, index+1, current);           
            current = current.Substring(0, current.Length-1);
        }
    }

    string returnPattern(char d)
    {
        string res = "";
        switch(d)
        {
            case '2': 
                res = "abc";
                break;
            case '3':
                res = "def";
                break;
            case '4': 
                res = "ghi";
                break;
            case '5':
                res = "jkl";
                break;
            case '6': 
                res = "mno";
                break;
            case '7':
                res = "pqrs";
                break;
            case '8': 
                res = "tuv";
                break;
            case '9':
                res = "wxyz";
                break;
            default:
                res = "";
                break;
        }
        return res;
    }
}