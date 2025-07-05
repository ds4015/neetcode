public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        checkPath(nums, 0, 0, 0, target);
        checkPath(nums, 0, 1, 0, target);

        return theWays;
        
    }

    int theWays = 0;
    void checkPath(int[] nums, int ind, int op, int total, int target)
    {
        if (ind > nums.Length-1) 
        {
            if (total == target) 
                theWays++;
            return;
        }

        if (op == 0)
            total += nums[ind];
        else
            total -= nums[ind];

        checkPath(nums, ind+1, 0, total, target);
        if (ind+1 <= nums.Length-1)
            checkPath(nums, ind+1, 1, total, target);
    }
}