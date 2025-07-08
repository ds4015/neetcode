public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        List<int> maxPerWindow = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int max = -9999;
            if ((i + k) > nums.Length) break;
            for (int j = i; j < i+k; j++)
                if (nums[j] > max) max = nums[j];
            maxPerWindow.Add(max);            
        }
        return maxPerWindow.ToArray();           
    }
}