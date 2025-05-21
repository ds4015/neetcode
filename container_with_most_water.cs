public class Solution {
    public int MaxArea(int[] heights) {

        int i = 0;
        int j = heights.Length - 1;

        int max = 0;

        /* start at both ends */
        while (i < j)
        {
            /* start fixed, end shifts left, check for new max */
            while (j != i)
            {
                int min = 1000;
                if (heights[i] < heights[j])
                    min = heights[i];
                else
                    min = heights[j];

                if (min * (j-i) > max) {
                    max = min * (j-i);
                }
                j--;
            }
            /* move start right one and restart */
            i++;
            j = heights.Length - 1;
        }
        return max;
    }
}