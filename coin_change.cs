public class Solution {
    public int CoinChange(int[] coins, int amount) {
        Array.Sort(coins);
        addCoin(coins, amount, new List<int>());
        if (min == 9999) return -1;
        return min;
    }

    List<List<int>> combos = new List<List<int>>();
    int min = 9999;
    void addCoin(int[] coins, int amount, List<int> combo)
    {
        if (combo.Count > min) return;
        if (amount == 0)
        {
            List<int> comboCopy = new List<int>(combo);
            if (comboCopy.Count < min) min = comboCopy.Count;
            combos.Add(comboCopy);
            return;
        }

        for (int i = coins.Length-1; i >= 0; i--)
        {
            if (amount >= coins[i])
            {
                if (combo.Count == 0 || 
                (combo.Count > 0 && combo[combo.Count-1] >= coins[i]))
                {
                    combo.Add(coins[i]);
                    addCoin(coins, amount-coins[i], combo);
                    combo.RemoveAt(combo.Count-1);
                }
            }
        }
    }
}