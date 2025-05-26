public class Solution {
    public int FindMin(int[] nums) {
        if (nums.Length == 1)
            return nums[0];
        if (nums.Length == 2 && nums[0] < nums[1])
            return nums[0];
        else if (nums.Length == 2 && nums[1] < nums[0]) return nums[1];
        return binarySearch(nums, 0, nums.Length-1);
    }

    int binarySearch(int[] nums, int s, int e)
    {
        int mp = s + (e - s)/2;
        if (nums[0] < nums[mp] && nums[mp] < nums[e])
            return nums[0];
        if (nums[0] > nums[mp] && nums[mp] < nums[e] && nums[mp-1] > nums[mp])
            return nums[mp];
        if (nums[0] < nums[mp] && nums[mp] > nums[e] && nums[mp+1] < nums[mp] )
            return nums[mp+1];
        if (nums[0] > nums[mp] && nums[mp] < nums[e])
            return binarySearch(nums, 0, mp);
        if (nums[0] < nums[mp] && nums[mp] > nums[e])
            return binarySearch(nums, mp, nums.Length-1);
        return -1;
    }
}