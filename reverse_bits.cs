public class Solution {
    public uint ReverseBits(uint n) {
        uint one = 1;

        uint res = 0;
        int exp = 31;

        for (int i = 0; i < 32; i++)
        {
            uint high = (uint)Math.Pow(2, exp);
            uint and = n & one;
            n = n >> 1;
            if (and == 1)
                res += high;
            exp--;
        }
        return res;
    }
}