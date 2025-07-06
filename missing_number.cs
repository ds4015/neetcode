public class Solution {
    public int MissingNumber(int[] nums) {

        HashSet<int> numbers = new HashSet<int>(nums);

        for (int i = 0; i <= nums.Length; i++)
            if (!numbers.Contains(i))
                return i;
        return -1;        
    }
}