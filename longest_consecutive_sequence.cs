public class Solution {
    public int LongestConsecutive(int[] nums) {

        Array.Sort(nums);
        int longestSequence = 1;
        int lastNumber = 0;
        int lS = 1;

        if (nums.Length < 1)
            return 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                lastNumber = nums[0];
                Console.WriteLine("Initial val, lastNumber = " + lastNumber);                
                continue;
            }
            else if (nums[i] == lastNumber)
            {
                Console.WriteLine("Repeated val = " + nums[i]);                
                continue;
            }
            else if (nums[i] == lastNumber + 1)
            {                
                longestSequence++;
                lastNumber = nums[i];
                Console.WriteLine("Longest sequence = " + longestSequence);                
            }
            else
            {
                if (lS < longestSequence)
                    lS = longestSequence;
                longestSequence = 1;
                lastNumber = nums[i];
                Console.WriteLine("Pattern broke");                
            }
        }
        if (lS < longestSequence)
            lS = longestSequence;
        return lS;        
    }
}
