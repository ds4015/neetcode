public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] output = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
            output[i] = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j)
                {
                    output[i] *= nums[j];
                }


            }
        }
        return output;
    }
}
