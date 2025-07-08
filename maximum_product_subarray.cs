public class Solution {
    public int MaxProduct(int[] nums) {

        int max = -9999;
        for (int j = 0; j < nums.Length; j++)
        {
            List<int> subarray = new List<int>();                
            subarray.Add(nums[j]);
            if (nums[j] > max) max = nums[j];
            for (int k = j+1; k < nums.Length; k++)
            {
                subarray.Add(nums[k]);
                int product = getProduct(subarray);
                if (product > max) max = product;
            }
        }
        return max;        
    }

    int getProduct(List<int> series)
    {
        int total = 1;
        foreach (var num in series)
            total *= num;
        return total;
    }
}