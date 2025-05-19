public class Solution {
    public int[] TwoSum(int[] numbers, int target) {

        int[] indices = new int[2];
        indices[0] = 0;
        indices[1] = 0;

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int sum = numbers[i] + numbers[j];
                if (sum == target)
                {
                    indices[0] = i+1;
                    indices[1] = j+1;
                    break;
                }
            }
        }
        return indices;
    }
}
