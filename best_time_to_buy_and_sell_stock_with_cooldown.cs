public class Solution {
    public int MaxProfit(int[] prices) {
        /* 1 = buy, 2 = sell, 3 = hold */

        List<List<int>> actions = new List<List<int>>();

        for (int i = 0; i < prices.Length; i++)
        {
            /* first day - buy or hold */
            if (i == 0)
            {
                List<int> a = new List<int>();
                a.Add(1);
                actions.Add(a);
                List<int> a2 = new List<int>();
                a2.Add(3);
                actions.Add(a2);
                continue;
            }
            int range = actions.Count;
            for (int j = 0; j < range; j++)
            {
                /* last action buy: can now hold or sell */
                if (actions[j][actions[j].Count-1] == 1)
                {
                    List<int> aLCopy = new List<int>(actions[j]);
                    aLCopy.Add(3);                    
                    actions[j].Add(2);
                    actions.Add(aLCopy);
                }
                /* last action sell: can now only hold for a day */
                else if (actions[j][actions[j].Count-1] == 2)
                    actions[j].Add(3);
                /* last action hold */
                else if (actions[j][actions[j].Count-1] == 3)
                {
                    bool lastActionSell = true;
                    int k = actions[j].Count-2;
                    /* check for last action before the hold */
                    while (k >= 0)
                    {
                        if (actions[j][k] == 3)
                            { k--;  continue; }
                        else if (actions[j][k] == 1)
                        {
                            lastActionSell = false;
                            break;
                        }
                        else break;
                    }
                    /* if last action before hold was buy, can sell or hold */
                    if (!lastActionSell)                    
                    {                    
                        List<int> aLCopy = new List<int>(actions[j]);
                        aLCopy.Add(3);
                        actions[j].Add(2);
                        actions.Add(aLCopy);
                    }
                    /* if last action before hold was sell, can buy or hold */
                    else 
                    {
                        List<int> aLCopy = new List<int>(actions[j]);
                        aLCopy.Add(3);
                        actions[j].Add(1);
                        actions.Add(aLCopy);
                    }
                }
            }
        }
        /* now have all possible routes/permutations */

        int maxProfit = 0;
        int runningValue = 0;

        /* for each set of actions, calculate profit */
        foreach (var actionList in actions)
        {
            for (int i = 0; i < prices.Length; i++)
            {
                int coinValue = prices[i];
                int act = actionList[i];
                if (act == 1)
                    runningValue -= coinValue;
                else if (act == 2)
                    runningValue += coinValue;
            }
            if (runningValue > maxProfit)
                maxProfit = runningValue;
            runningValue = 0;
        }
        return maxProfit;
    }
}