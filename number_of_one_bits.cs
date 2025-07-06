public class Solution {
    public int HammingWeight(uint n) {
        uint one = 1;
        int howManyOnes = 0;
        int howManyShifts = 0;

        while (howManyShifts < 32)
        {
            uint and = n & one;
            if (and == 1)
                howManyOnes++;
            n = n >> 1;
            howManyShifts++;
        }
        return howManyOnes;        
    }
}