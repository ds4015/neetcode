public class Solution {
    public int SingleNumber(int[] nums) {
        HashSet<int> numbers = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!numbers.Contains(nums[i]))
                numbers.Add(nums[i]);
            else
                numbers.Remove(nums[i]);
        }
        foreach (var h in numbers)
            return h;        
        return -1;
    }
}