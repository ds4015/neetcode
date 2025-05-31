public class Solution {
    public int FindKthLargest(int[] nums, int k) {
       Array.Sort(nums);
       Array.Reverse(nums);

       List<int> numbers = new List<int>();

        for (int i = 0; i < nums.Length; i++)
            numbers.Add(nums[i]);
        return numbers[k-1];

    }
}