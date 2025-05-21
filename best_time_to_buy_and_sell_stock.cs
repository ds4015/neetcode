public class Solution {
    public int MaxProfit(int[] prices) {

        int window_size = 1;
        int max_profit = 0;

        int i = 0;
        int j = i + window_size;

        while (window_size < prices.Length)
        {
            while (j < prices.Length)
            {
                if ((prices[j] - prices[i]) > max_profit)
                    max_profit = prices[j] - prices[i];
                j++;
                i++;
            }
            window_size++;
            i = 0;
            j = i + window_size;
        }
        return max_profit;
    }
}