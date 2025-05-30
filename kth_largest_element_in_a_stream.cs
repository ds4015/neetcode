public class KthLargest {

    int k = 0;
    List<int> pQueue = new List<int>();

    public KthLargest(int k, int[] nums) {
        this.k = k;
        Array.Sort(nums);
        Array.Reverse(nums);
        for (int i = 0; i < k; i++)
            pQueue.Add(-9999);
        for (int i = 0; i < nums.Length; i++)
            if (i < k)
                pQueue[i] = nums[i];
            else
                break;
    }
    
    public int Add(int val) {
        for (int i = 0; i < k; i++)
        {
            if (val >= pQueue[i])
            {
                pQueue.Insert(i, val);
                break;
            }
        }
        return pQueue[k-1];
    }
}