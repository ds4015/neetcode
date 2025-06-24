public class Solution {
    public int LengthOfLIS(int[] nums) {

        int maxSeq = -1;

        List<int> pr = new List<int>();

        for (int j = 0; j < nums.Length; j++)
        {
            for (int i = j; i < nums.Length; i++)
            {
                if (pr.Count == 0)
                    pr.Add(nums[i]);
                else if (pr.Count == 1)
                {
                    if (nums[i] < pr[0])
                    {
                        pr.RemoveAt(0);
                        pr.Add(nums[i]);
                    }
                    else if (nums[i] > pr[0]) pr.Add(nums[i]);
                }
                else if (nums[i] > pr[pr.Count-1])
                    pr.Add(nums[i]);
                else if (nums[i] < pr[pr.Count-1] && nums[i] > pr[pr.Count-2])
                {
                    pr.RemoveAt(pr.Count-1);
                    pr.Add(nums[i]);
                }
            }
            if (pr.Count > maxSeq) maxSeq = pr.Count;
            pr.Clear();
            if (nums.Length - (j + 1) < maxSeq) break;
        }
        return maxSeq;
    }
}