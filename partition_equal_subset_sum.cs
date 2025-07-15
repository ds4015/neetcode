public class Solution {
    public bool CanPartition(int[] nums) {
        List<int> e = new List<int>();
        addToSubset(nums, e, 0);
        return canPartition;
    }

    bool canPartition = false;
    void addToSubset(int[] nums, List<int> subset, int index)
    {
        if (getSum(subset) == getSumR(nums))
        {
            canPartition = true;
            return;
        }
        
        for (int i = index; i < nums.Length; i++)
        {
            int number = nums[i];
            subset.Add(nums[i]);
            nums[i] = 0;
            addToSubset(nums, subset, index+1);
            if (canPartition) return;
            subset.RemoveAt(subset.Count-1);
            nums[i] = number;
        }
    }

    int getSum(List<int> subset)
    {
        int total = 0;
        foreach (var v in subset)
            total += v;
        return total;
    }

    int getSumR(int[] nums)
    {
        int total = 0;
        foreach (var v in nums)
            total += v;
        return total;
    }
}