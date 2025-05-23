public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {

        List<int> stack1 = new List<int>();
        List<int> stack2 = new List<int>();

        int[] result = new int[temperatures.Length];

        for (int i = temperatures.Length-1; i >= 0; i--)
            stack1.Insert(0, temperatures[i]);

        int r = 0;
        while(stack1.Count > 0)
        {
            int j = 0;

            int curr = 0;           
            stack2.Insert(0, stack1[0]);
            stack1.RemoveAt(0);

            while (stack1.Count > 0 && stack1[0] <= stack2[curr])
            {
                stack2.Insert(0, stack1[0]);
                stack1.RemoveAt(0);       
                curr++;
            }

            /* last item - no future days, set to 0 */
            if (stack1.Count < 1 && stack2.Count == 1)
            {
                result[r] = 0;
            }

            /* no more numbers on stack 1 > current temp, result for this one is 0 */
            else if (stack1.Count < 1 && stack2[0] <= stack2[curr])
            {
                result[r] = 0;
            }
            else
            {
                stack2.Insert(0, stack1[0]);
                stack1.RemoveAt(0);
                curr++;
                result[r] = curr;                           
            }    

            while (j != curr)
            {
                stack1.Insert(0, stack2[0]);
                stack2.RemoveAt(0);
                j++;
            }
            stack2.RemoveAt(0);
            r++;
        }   
        return result;
    }
}
