public class Solution {
    public bool CheckValidString(string s) {

        List<char> pStack = new List<char>();
        List<int> pIndices = new List<int>();
        List<char> starStack = new List<char>();
        List<int> starIndices = new List<int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(') 
                {pStack.Insert(0,'('); pIndices.Insert(0,i);}
            else if (s[i] == '*') 
                {starStack.Insert(0,'*'); starIndices.Insert(0,i);}
            else
            {
                if (pStack.Count > 0) 
                    {pStack.RemoveAt(0); pIndices.RemoveAt(0);}
                else if (starStack.Count > 0) 
                    {starStack.RemoveAt(0); starIndices.RemoveAt(0);}
                else return false;
            }
        }
        while (pStack.Count > 0)
        {
            if (starStack.Count > 0)
            {
                if (pIndices[0] < starIndices[0]) 
                {
                    pStack.RemoveAt(0);
                    starStack.RemoveAt(0);
                    pIndices.RemoveAt(0);
                    starIndices.RemoveAt(0);
                }
                else return false;
            }
            else return false;
        }
        return true;
    }
}
