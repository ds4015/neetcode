public class Solution {
    public int EvalRPN(string[] tokens) {
        List<int> stack = new List<int>();

        int eval = 0;

        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] != "+" && tokens[i] != "-" && tokens[i] != "*" && tokens[i] != "/")
                stack.Insert(0, Convert.ToInt32(tokens[i]));
            else if (tokens[i] == "+")
            {
                eval = stack[0] + stack[1];
                stack.RemoveAt(0);
                stack.RemoveAt(0);
                stack.Insert(0, eval);              
            }
            else if (tokens[i] == "-")
            {
                eval = stack[1] - stack[0];
                stack.RemoveAt(0);
                stack.RemoveAt(0);
                stack.Insert(0, eval);              
            }
            else if (tokens[i] == "*")
            {
                eval = stack[0] * stack[1];
                stack.RemoveAt(0);
                stack.RemoveAt(0);
                stack.Insert(0, eval);                                
            }
            else if (tokens[i] == "/")
            {
                eval = stack[1] / stack[0];
                stack.RemoveAt(0);
                stack.RemoveAt(0);
                stack.Insert(0, eval);                              
            }
        }
        return stack[0];
    }

}