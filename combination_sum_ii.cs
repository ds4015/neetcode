public class Solution {
    List<List<int>> result = new List<List<int>>();
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        findTarget(candidates, target, 0);
        return result;
    }

    List<int> soln = new List<int>();
    int currentIndex = 0;
    bool end = false;
    void findTarget(int[] nums, int target, int index)
    {
        /* base case */
        if (index > nums.Length - 1)
        {
            removeTwo();
            index = ++currentIndex;
            if (currentIndex > nums.Length - 1)
            {
                end = true;
                return;
            }
        }

        soln.Add(nums[index]);

        /* target found */
        if (getSum(soln) == target)
        {
            List<int> solnCopy = new List<int>(soln);

            /* check for duplicates before adding */
            bool dup = false;
            foreach (var sol in result)
            {
                dup = true;                
                int max = 0;
                if (sol.Count > soln.Count) max = soln.Count;
                else max = sol.Count;

                for (int i = 0; i < max; i++)
                    if (solnCopy[i] != sol[i])
                        dup = false;
                if (dup) break;
            }

            if (!dup) result.Add(solnCopy);
            removeTwo();
            if (soln.Count == 0)
                index = ++currentIndex;
            else
                index = index + 1;
            findTarget(nums, target, index);
            if (end) return;
        }

        /* too big -> backtrack */
        else if (getSum(soln) > target)
        {
            removeTwo();
            if (soln.Count == 0)
                index = ++currentIndex;
            findTarget(nums, target, index);
            if (end) return;
        }
        else
            findTarget(nums, target, index+1);
    }

    int getSum(List<int> s)
    {
        int sum = 0;
        foreach (var n in s)
            sum += n;
        return sum;
    }

    void removeTwo()
    {
        for (int i = 0; i < 2; i++)
            if (soln.Count > 0)                
                soln.RemoveAt(soln.Count-1);
    }
}