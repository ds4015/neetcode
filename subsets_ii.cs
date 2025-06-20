public class Solution {
    List<List<int>> result = new List<List<int>>();
    public List<List<int>> SubsetsWithDup(int[] nums) {
        List<int> subset = new List<int>();
        List<int> empty = new List<int>();
        result.Add(empty);
        List<int> numsList = new List<int>();
        foreach (var n in nums)
            numsList.Add(n);

        findSubset(numsList, 0, subset);
        return result;   
    }

    int currentIndex = 0;
    int lastInd = -1;
    void findSubset(List<int> nums, int index, List<int> subset)
    {
        /* base case */
        if (index > nums.Count - 1)
            return;

        /* add next and check for duplicates */
        subset.Add(nums[index]);
        if (!alreadyFound(subset))
        {
            List<int> sCopy = new List<int>(subset);
            result.Add(sCopy);
        }

        /* recurse */
        findSubset(nums, index+1, subset);

        /* backtrack - delete last added and recurse again */    
        subset.RemoveAt(subset.Count-1);        
        while (index + 1 < nums.Count)
        {
            findSubset(nums, index+1, subset);
            /* skip over last deleted when re-recursing */
            index++;
        }
    }

    /* check for dupes */
    bool alreadyFound(List<int> s)
    {
        bool found = false;
        List<int> subsetCopy = new List<int>(s);
        subsetCopy.Sort();
        foreach (var r in result)
        {
            if (r.Count != s.Count) continue;
            List<int> rCopy = new List<int>(r);
            rCopy.Sort();
            found = true;
            for (int i = 0; i < r.Count; i++)
                if (rCopy[i] != subsetCopy[i])
                    found = false;
            if (found) return true;
        }
        return false;
    }
}