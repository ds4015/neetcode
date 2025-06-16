public class Solution {
    List<int> order = new List<int>();
    int pass = 0;
    bool imp = false;
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        int[] empty = new int[0];
        int[] result = new int[numCourses];

        if (prerequisites.Length == 0)
        {
            int[] any = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
                any[i] = i;
            return any;
        }
        int impCount = 0;
        for (int i = 0; i < prerequisites.Length; i++)
        {
            for (int j = 0; j < prerequisites.Length; j++)
            {
                if (prerequisites[i][0] == prerequisites[j][1])
                    impCount++;
            }
        }
        if (impCount == prerequisites.Length)
            return empty;

        for (int i = 0; i < prerequisites.Length; i++)
        {
            int right = prerequisites[i][1];
            check(prerequisites, right);
        }
        int num = 0;
        while (order.Count < numCourses)
        {
            if (!order.Contains(num))
                order.Add(num);
            num++;
        }
        num = 0;
        foreach (var v in order)
            result[num++] = v;
        return result;        
    }

    List<int> checkedVals = new List<int>();
    void check (int[][] prereqs, int val)
    {
        if (!checkedVals.Contains(val))
            checkedVals.Add(val);
        else
            return;
        for (int i = 0; i < prereqs.Length; i++)
        {
            if (prereqs[i][0] == val)
                check(prereqs, prereqs[i][1]);
        }
        if (!order.Contains(val))
            order.Add(val);
    }
}