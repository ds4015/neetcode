public class Solution {
    public bool IsHappy(int n) {

        List<int> seen = new List<int>();

        int sum = 0;
        while (sum != 1)
        {
            sum = 0;
            sum = getSum(n, sum);
            if (seen.Contains(sum))
                return false;
            seen.Add(sum);
            n = sum;
        }
        if (sum == 1) return true;
        return false;
    }

    int getSum(int n, int sum)
    {
        if (n >= 1000)
        {
            sum += (n / 1000) * (n / 1000);
            int newSum = getSum(n % 1000, sum);
            sum = newSum;
        }
        else if (n < 1000 && n >= 100)
        {
            sum += (n / 100) * (n / 100);
            int newSum = getSum(n % 100, sum);            
            sum = newSum;
        }            
        else if (n < 100 && n >= 10)
        {
            sum += (n / 10) * (n / 10);
            int newSum = getSum(n % 10, sum);
            sum = newSum;
        }
        else sum += (n * n);
        return sum;
    }
}