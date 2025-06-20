public class Solution {
    List<List<int>> result = new List<List<int>>();
    public List<List<int>> Permute(int[] nums) {
        List<int> numsList = new List<int>();
        foreach (var n in nums)
            numsList.Add(n);

        permute(numsList);
        return result;        
    }

    List<int> perm = new List<int>();
    void permute(List<int> nums)
    {
        int r = nums.Count;
        for (int i = 0; i < r; i++)
        {
            int num = nums[i];
            perm.Add(num);
            nums.RemoveAt(i);

            if (nums.Count == 0)
            {
                List<int> permCopy = new List<int>(perm);
                result.Add(permCopy);
            }
            permute(nums);
            perm.Remove(num);
            nums.Insert(i, num);
        }
    }
}