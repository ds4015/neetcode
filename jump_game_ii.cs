public class Solution {
    public int Jump(int[] nums) {
        mightAsWell(nums, 0);
        return min;
    }

    int steps = -1;
    int min = 9999;
    void mightAsWell(int[] nums, int index)
    {
        steps++;
        if (index >= nums.Length - 1)
        {
            if (steps < min) min = steps;
            return;
        }

        int decr = 0;
        /* if max doesn't work, try next down */
        while (nums[index] + decr >= 1)
        {
            mightAsWell(nums, index + nums[index] + decr);
            steps--;
            decr--;
        }
    }
}