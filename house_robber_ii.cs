public class Solution {
    List<int> numsDouble = new List<int>();
    List<int> profits = new List<int>();
    public int Rob(int[] nums) {
        /* one or two house cases */
        if (nums.Length == 1)
            return nums[0];
        if (nums.Length == 2)
            return Math.Max(nums[0], nums[1]);

        /* double the house list to account for circle */
        for (int i = 0; i < nums.Length; i++)
            numsDouble.Add(nums[i]);
        for (int i = 0; i < nums.Length; i++)
            numsDouble.Add(nums[i]);

        /* check each series of 3 houses for max */
        for (int i = 0; i < nums.Length; i++)
        {
            int j = i;
            int total = 0;
            while (j < i + nums.Length - 1)
            {
                /* if sides sum greater than mid or 2 away from end of circle */
                if ((j + 2 == i + nums.Length) || 
                    (numsDouble[j] + numsDouble[j+2] > numsDouble[j+1]))
                {
                    total += numsDouble[j];
                    j += 2;
                }
                /* mid greater than side sums, choose that house instead */
                else
                {
                    total += numsDouble[j+1];
                    j += 3;
                }
            }
            profits.Add(total);                
        }
        profits.Sort();
        return profits[profits.Count-1];        
    }
}