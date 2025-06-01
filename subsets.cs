public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> subsets = new List<List<int>>();

        List<int> subset = new List<int>();
        subsets.Add(subset);

        for (int i = 0; i < nums.Length; i++)
        {
            List<int> singular = new List<int>();
            singular.Add(nums[i]);
            subsets.Add(singular);
        }

        int s_size = 1;

        while (s_size < nums.Length)
        {
            int ssCount = subsets.Count;
            int ss_start = 0;
            while (subsets[ss_start].Count < s_size)
            {
                ss_start++;
                continue;
            }

            for (int i = ss_start; i < ssCount; i++)
            {
                for (int j = 1; j < nums.Length; j++)
                {
                    if (!subsets[i].Contains(nums[j]))
                    {
                        List<int> new_subset = new List<int>(subsets[i]);
                        new_subset.Add(nums[j]);
                        new_subset.Sort();
                        if (!checkIfExists(subsets, new_subset))
                            subsets.Add(new_subset);
                    }
                }
            }
            s_size++;
        }
        return subsets;
    }

    bool checkIfExists(List<List<int>> subsets, List<int> subset)
    {
        for (int i = 0; i < subsets.Count; i++)
        {
            bool found = true;
            if (subsets[i].Count != subset.Count)
                continue;
            for (int j = 0; j < subsets[i].Count; j++)
            {
                if (subset[j] != subsets[i][j])
                    found = false;
            }
            if (found)
                return true;
        }
        return false;
    }
}