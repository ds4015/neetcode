public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        int max = -1000;
        int min = 1000;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= max)
                max = nums[i];
            if (nums[i] < min)
                min = nums[i];
        }

        if (max == min)
        {
            int[] ans = new int[1];
            ans[0] = min;
            return ans;
        }

        Console.WriteLine("min: " + min + ", max: " + max);

        int range = min;


        int[] freq = new int[max - range + 1];
        int[] keys = new int[max - range + 1];

        for (int i = 0; i < keys.Length; i++)
        {
            keys[i] = min++;
            Console.WriteLine(keys[i]);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            freq[nums[i] - range]++;
        }

        Array.Sort(freq, keys);
        Array.Reverse(freq);
        Array.Reverse(keys);
        int[] kmost = new int[k];
        for (int i = 0; i < k; i++)
            kmost[i] = keys[i];
        
        return kmost;
    }
}