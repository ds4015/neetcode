public class Solution {
    List<int> table = new List<int>();
    public int Rob(int[] nums) {
        /* 1 house or 2, choose max */
        if (nums.Length == 1)
            return nums[0];
        if (nums.Length == 2)
            return Math.Max(nums[0], nums[1]);

        /* for every 3 houses, choose max of sides sum or middle */
        for (int i = 0; i < nums.Length - 2; i++)
        {
            /* manage last 4 houses by simple math */
            if (i == nums.Length - 4)
            {
                if (nums[i] + nums[i+2] > nums[i+1] + nums[i+3])
                    table.Add(i);
                else
                    table.Add(i+1);
            }
            /* store max index in table */
            else if (nums[i] + nums[i+2] > nums[i+1])
                table.Add(i);
            else table.Add(i+1);
        }
        if (table[table.Count-1] == nums.Length-3)
            table.Add(nums.Length-1);

        /* follow the table indices either 0 or 1 indexed for max profit */
        int result0 = makeProfits(nums, 0);
        int result1 = makeProfits(nums, 1);
        return Math.Max(result0, result1);
    }

    int makeProfits(int[] nums, int start)
    {
        int lastIndex = -2;
        int result = 0;
        for (int i = start; i < table.Count; i++)
        {
            if (table[i] >= lastIndex + 2)
            {
                result += nums[table[i]];
                lastIndex = table[i];
            }
        }
        return result;
    }
}