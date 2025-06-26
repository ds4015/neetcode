public class Solution {
    public int[] PlusOne(int[] digits) {
        List<int> plusOneList = new List<int>();

        int carry = 1;
        for (int i = digits.Length-1; i >= 0; i--)
        {
            int incr = digits[i] + carry;
            if (incr < 10) 
            {
                plusOneList.Insert(0, incr);
                carry = 0;
            }
            else 
            {
                plusOneList.Insert(0, 0);
                carry = 1;
            }
        }
        if (carry == 1) plusOneList.Insert(0, 1);
        int[] pol = plusOneList.ToArray();

        return pol;        
    }
}