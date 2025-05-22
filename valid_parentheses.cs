public class Solution {
    public bool IsValid(string s) {
        List<char> stack = new List<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                stack.Insert(0, s[i]);
            else if (s[i] == ')' && (stack.Count < 1 || stack[0] != '('))
                return false;
            else if (s[i] == ']' && (stack.Count < 1 || stack[0] != '['))
                return false;
            else if (s[i] == '}' && (stack.Count < 1 || stack[0] != '{'))
                return false;                
            else if (s[i] == ')' && stack[0] == '(')
                stack.RemoveAt(0);
            else if (s[i] == ']' && stack[0] == '[')
                stack.RemoveAt(0);
            else if (s[i] == '}' && stack[0] == '{')
                stack.RemoveAt(0);
        }
        if (stack.Count > 0)
            return false;
        return true;        
    }
}