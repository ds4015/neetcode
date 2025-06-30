public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {

        int[] numsLarger;
        int[] numsSmaller;

        /* insert smaller array into larger */
        if (nums1.Length < nums2.Length)
        {
            numsLarger = nums2;
            numsSmaller = nums1;
        }
        else
        {
            numsLarger = nums1;
            numsSmaller = nums2;
        }

        List<int> combined = new List<int>(numsLarger);        

        for (int i = 0; i < numsSmaller.Length; i++)
        {
            insertAt(numsLarger, 0, numsLarger.Length-1, 
                     numsSmaller[i]);
            if (index >= combined.Count)
                combined.Add(numsSmaller[i]);
            else if (index < 0)
                combined.Insert(0, numsSmaller[i]);
            else
                combined.Insert(index, numsSmaller[i]);
            index = -2;
            numsLarger = combined.ToArray();
        }

        /* even combined array */
        if (combined.Count % 2 != 0)
            return combined[(combined.Count - 1) / 2];
        
        /* odd combined array */
        return (combined[combined.Count/2] + 
                combined[combined.Count/2 - 1]) / 2.0;
    }

    int index = -2; /* default 'not found' index */
    void insertAt(int[] nums, int start, int end, int target)
    {
        /* surpassed array - target must be larger than all */
        if (start > nums.Length-1)
            { index = nums.Length; return; }

        /* same start/end: place before or after */
        if (start == end && nums[start] < target)
            { index = start + 1; return; }
        if (start == end && nums[start] > target)
            { index = start - 1; return; }

        /* start/end adjacent */
        if (start == end - 1) 
        { 
            /* target bigger than both */
            if (nums[end] < target)
                index = end+1;
            /* target in between */
            else if (nums[start] < target)
                index = start + 1;
            /* target smaller than start */
            else
                index = start;
            return;
        }

        /* find midpoint */
        int mp = start + (end - start)/2;

        if (nums[mp] == target) 
            { index = mp; return; }

        /* recursive binary search */
        if (nums[mp] > target)
        {
            insertAt(nums, start, mp-1, target);
            if (index != -2) return;
        }
        else
        {
            insertAt(nums, mp+1, end, target);
            if (index != -2) return;
        }
    }
}