public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {

        List<List<int>> result = new List<List<int>>();

        Array.Sort(nums);

        /* i - left marker, j - right marker, k - iterator */
        int i = 0;
        int j = nums.Length-1;
        int k = i + 1;

        /* proceed from left to right */
        while (i < nums.Length - 1)
        {
            /* for each i, check for triplet in remaining array */
            while (i < j)
            {   
                /* if sum of first two is neg, skip over remaining neg */
                if (nums[i] + nums[j] < 0)
                    while (nums[k] < 0)
                        k++;
                /* while iterator less than right marker, check for 3sum */
                while (k < j)
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        bool tripletAlreadyExists = false;
                        List<int> t = new List<int>();
                        t.Add(nums[i]);
                        t.Add(nums[j]);
                        t.Add(nums[k]);
                        t.Sort();

                        /* 3sum found, but check for dups */
                        foreach (var triplet in result)
                        {
                            triplet.Sort();
                            int count = 0;
                            for (int a = 0; a < 3; a++)
                            {
                                if (triplet[a] == t[a])
                                    count++;
                            }
                            if (count == 3)
                            {
                                tripletAlreadyExists = true;
                                break;
                            }
                        }

                        if (!tripletAlreadyExists)
                        {
                            result.Add(t);
                            break;
                        }
                    }
                    /* advance iterator */
                    k++;
                }
                /* done with pass, move right marker left one, start over */
                j--;
                k = i + 1;
            }
            /* checked all from last left marker, move left marker right one, start over */
            i++;
            j = nums.Length - 1;
            k = i + 1;
        }
        return result;        
    }
}