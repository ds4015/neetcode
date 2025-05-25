public class Solution {
    public int Search(int[] nums, int target) {

        int mp = nums.Length / 2;

        if (nums.Length == 1 && nums[0] != target)
            return -1;

        if (target == nums[mp])
            return mp;

        if (target > nums[mp])
        {
            int it = mp;
            int[] subArr = new int[nums.Length - mp];
            for (int i = 0; i < subArr.Length; i++)
                subArr[i] = nums[it++];
            int res = Search(subArr, target);
            if (res != -1)
                return res + mp; /* offset if found */
            return res;
        }

        if (target < nums[mp])
        {           
            int[] subArr = new int[mp];
            for (int i = 0; i < subArr.Length; i++)
                subArr[i] = nums[i];
            return Search(subArr, target);
        }

        return -1;
        
    }
}