public class Solution {
    List<List<int>> result = new List<List<int>>();
    public List<List<int>> CombinationSum(int[] nums, int target) {
        Array.Sort(nums);
        findTarget(nums, target, 0);
        return result;        
    }

    List<int> soln = new List<int>();
    int currentIndex = 0;
    bool end = false;
    void findTarget(int[] nums, int target, int index)
    {
        /* base cases */
        if (currentIndex > nums.Length - 1)
            return;
        if (index > nums.Length - 1 && soln.Count > 0 &&
            soln[0] == nums[index-1])
        {
            end = true;
            return;
        }

        /* reached the end, remove 1 and get appropriate index */
        if (index > nums.Length - 1)
        {
            if (soln.Count > 0)
            {
                for (int i = 0; i < nums.Length; i++)
                    if (nums[i] == soln[soln.Count-1])
                        index = i + 1;
                soln.RemoveAt(soln.Count-1);
            }
            else
                index = currentIndex++;
            findTarget(nums, target, index);
            if (end) return;
        }

        soln.Add(nums[index]);

        /* solution found */
        if (getSum(soln) == target)
        {
            List<int> solnCopy = new List<int>(soln);
            result.Add(solnCopy);
            
            /* if starts with last num in nums, we're done */
            if (soln[0] == nums[nums.Length-1])
                return;
            
            /* remove 2, get appropriate next index */
            for (int i = 0; i < 2; i++)
            {
                if (soln.Count > 0)
                {
                    if (i == 1)
                        for (int j = 0; j < nums.Length; j++)
                            if (nums[j] == soln[soln.Count-1])
                                index = j + 1;            
                    soln.RemoveAt(soln.Count-1);
                }
            }
            if (soln.Count == 0)
                index = ++currentIndex;    
            findTarget(nums, target, index);
            if (end) return;            
        }

        /* too big -> backtrack */
        else if (getSum(soln) > target)
        {
            for (int i = 0; i < 2; i++)
            {
                if (soln.Count > 0)
                {
                    if (i == 1)
                        for (int j = 0; j < nums.Length; j++)
                            if (nums[j] == soln[soln.Count-1])
                                index = j + 1;
                    soln.RemoveAt(soln.Count-1);
                }
            }
            if (soln.Count == 0)
                index = ++currentIndex;
            findTarget(nums, target, index);
            if (end) return;
        }
        /* not there yet - add next */
        else
            findTarget(nums, target, index);
    }

    int getSum(List<int> soln)
    {
        int sum = 0;
        foreach (var v in soln)
            sum += v;
        return sum;
    }
}