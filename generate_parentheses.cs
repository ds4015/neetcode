public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        List<string> stack = new List<string>();

        stack.Insert(0, "()");

        for (int i = 1; i < n; i++)
        {
            List<string> num = new List<string>();
            foreach (var s in stack)
            {
                int count = 1;
                for (int j = 0; j < s.Length; j++)
                {
                    string cnct = s.Substring(0, j+1) + "()" + 
                        s.Substring(j+1);
                    if (!num.Contains(cnct)) num.Add(cnct);
                }
            }
            stack.Clear();
            foreach (var c in num)
                stack.Add(c);
        }
        return stack;
    }
}