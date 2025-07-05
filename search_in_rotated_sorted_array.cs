public class Solution {
    public int Search(int[] nums, int target) {
        int origStart = 0;

        /* find transition point for original array start index */
        for (int i = 0; i < nums.Length - 1; i++)
            if (nums[i] > nums[i+1])
                origStart = i+1;
        
        int midpoint = nums.Length / 2;

        /* if midpoint comes before transition pt in rotated array,
            use reverse direction mode for binary search */
        if (midpoint <= origStart)
            binarySearch(nums, 0, nums.Length, target, 1);
        else
            binarySearch(nums, 0, nums.Length, target, 0);
        return atIndex;        
    }

    bool found = false;
    int atIndex = -1;
    void binarySearch(int[] nums, int s, int e, int t, int m)
    {
        int mp = s + ((e - s) / 2);

        /* base cases */
        if (s > nums.Length-1 || (e <= s && nums[s] != t)) 
            return;

        if (nums[mp] == t)
        {
            found = true;
            atIndex = mp;
            return;
        }

        /* reverse direction if mp comes before transition pt
           (first pass only) */
        if (m == 1)
        {
            if (t < nums[0])
                binarySearch(nums, mp + 1, nums.Length, t, 0);
            else
                binarySearch(nums, 0, mp-1, t, 0);
        }
        /* otherwise, it's a normal recursive binary search */
        else
        {
            if (nums[mp] > t)
                binarySearch(nums, s, mp, t, 0);
            else
                binarySearch(nums, s + 1, nums.Length, t, 0);
        }
    }
}