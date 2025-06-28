public class Solution {
    public int FindDuplicate(int[] nums) {

        int i = 0;

        while (i < nums.Length)
        {
            if (i == nums[i] - 1) { i++; continue; }
            if (nums[nums[i] - 1] == nums[i])
                return nums[i];
            int temp = nums[nums[i] - 1];
            nums[nums[i] - 1] = nums[i];
            nums[i] = temp;
        }
        return 0;   
    }
}