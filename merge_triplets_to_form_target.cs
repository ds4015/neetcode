public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        bool t1 = false, t2 = false, t3 = false;
        for (int i = 0; i < triplets.Length; i++)
        {
            if (triplets[i][0] > target[0] || triplets[i][1] > target[1] ||
                triplets[i][2] > target[2])
                continue;

            if (triplets[i][0] == target[0]) t1 = true;
            if (triplets[i][1] == target[1]) t2 = true;
            if (triplets[i][2] == target[2]) t3 = true;
        }
        if (t1 && t2 && t3) return true;
        return false;
    }
}