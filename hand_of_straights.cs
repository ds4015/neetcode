public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand.Length % groupSize != 0) return false;

        Array.Sort(hand);
        List<int> used = new List<int>();

        int lastNum = 0;
        int count = 0;
        int i = 0;
        while (i < hand.Length && used.Count < hand.Length)
        {
            if (used.Contains(i)) { i++; continue; }
            if (count == 0) { used.Add(i); count++; 
                lastNum = hand[i]; continue; }
            if (hand[i] == lastNum) { i++; continue; }
            if (hand[i] == lastNum + 1) { count++; used.Add(i); }
            if (count == groupSize) { count = 0; i = 0; continue; }
            if (hand[i] != lastNum + 1 && i != hand.Length - 1)
                return false;
            lastNum = hand[i];
        }

        if (used.Count != hand.Length) return false;
        return true;
    }
}