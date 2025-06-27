public class Solution {
    public bool CanJump(int[] nums) {
        jump(nums, 0);
        return canJump;
    }

    bool canJump = false;
    void jump(int[] nums, int index)
    {
        if (index + nums[index] >= nums.Length-1)
        {
            canJump = true;
            return;
        }
        if (nums[index] == 0)
            return;

        jump(nums, index + nums[index]);
        while (!canJump) 
        {
            nums[index]--;
            if (nums[index] == 0) break;
            jump(nums, index + nums[index]);
        }
    }
}