public class Solution {
    public int LastStoneWeight(int[] stones) {
        int marker = 0;
        Array.Sort(stones);
        Array.Reverse(stones);

        List<int> pQueue = new List<int>();

        for (int i = 0; i < stones.Length; i++)
            pQueue.Add(stones[i]);

        while (pQueue.Count - marker > 1)
        {
            int x = pQueue[marker++];
            int y = pQueue[marker++];
            if (y < x)
            {
                int newWeight = x - y;
                if (marker == pQueue.Count)
                    pQueue.Add(newWeight);
                else
                {
                    int range = pQueue.Count + 1;
                    for (int i = marker; i < range; i++)
                    {
                        if (i == pQueue.Count)
                            pQueue.Add(newWeight);
                        else
                        if (pQueue[i] <= newWeight)
                        {
                            pQueue.Insert(i, newWeight);
                            break;
                        }
                    }
                }
            }
        }
        if (marker >= pQueue.Count)
            return 0;
        return pQueue[marker];
    }
}