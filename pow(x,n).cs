public class Solution {
    public double MyPow(double x, int n) {

        double soln = 1.0;
        bool neg = false;

        if (n < 0) { n *= -1; neg = true; }

        for (int i = 0; i < n; i++)
            soln *= x;

        if (neg) return (1 / soln);
        return soln;
    }

}