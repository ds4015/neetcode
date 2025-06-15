public class Solution {
    List<int> queue = new List<int>();
    List<int> discovered = new List<int>();
    int taken = 0;
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        if (prerequisites.Length == 0) return true;
        for (int i = 0; i < prerequisites.Length; i++)
            if (prerequisites[i][0] == prerequisites[i][1])
                return false;

        queue.Add(prerequisites[0][1]);

        while (queue.Count > 0)
        {
            int item = queue[0];
            queue.RemoveAt(0);
            if (!discovered.Contains(item))
            {
                taken++;
                discovered.Add(item);
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                if (prerequisites[i][1] == item)
                {
                    if (discovered.Contains(prerequisites[i][0]))
                        return false;
                    queue.Add(prerequisites[i][0]);
                }
            }
        }
        for (int i = 0; i < numCourses; i++)
            if (!discovered.Contains(i))
                taken++;
        if (taken >= numCourses)
            return true;
        return false;
    }
}