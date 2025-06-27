public class Solution {
    public int MaxSubArray(int[] nums) {

        int max = nums[0];
        int run = nums[0];

        int i = 1;
        while (i < nums.Length)
        {
            /* if running total so far > next term, keep going */
            if (run + nums[i] > nums[i])
                run += nums[i];
            else /* otherwise reset */
                run = nums[i];
            if (run > max) max = run; /* keep track of max sum */
            i++;
        }
        return max;   
    }
}