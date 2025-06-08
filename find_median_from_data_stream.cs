public class MedianFinder {

    List<int> numbers = new List<int>();

    public MedianFinder() {

    }
    
    public void AddNum(int num) {
        if (numbers.Count == 0)
            numbers.Add(num);
        else
        {
            int i = 0;
            while (i < numbers.Count && numbers[i] < num)
                i++;
            if (i == numbers.Count)
                numbers.Add(num);
            else
                numbers.Insert(i, num);
        }
    }
    
    public double FindMedian() {
        if (numbers.Count % 2 != 0)
        {
            int ind = (numbers.Count - 1)/2;
            return numbers[ind] / 1.0;
        }
        else
        {
            int ind = (numbers.Count - 2) / 2;
            return (numbers[ind] + numbers[ind+1]) / 2.0;
        }
    }
}