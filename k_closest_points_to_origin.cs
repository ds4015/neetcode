public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        List<List<int>> queue = new List<List<int>>();
        List<double> distances = new List<double>();

        for (int i = 0; i < points.Length; i++)
        {
            List<int> point = new List<int>();
            point.Add(points[i][0]); point.Add(points[i][1]);
            double distToOrigin = Math.Sqrt(points[i][0]*points[i][0] + 
                                            points[i][1]*points[i][1]);
            if (i == 0 || distToOrigin < distances[0])
            {
                queue.Insert(0,point);
                distances.Insert(0,distToOrigin);
            }
            else
            {
                int j = 0;
                while (j < distances.Count)
                {
                    if (distances[j] <= distToOrigin) {j++; continue;}
                    else break;
                }
                if (j > distances.Count-1) 
                {
                    queue.Add(point); 
                    distances.Add(distToOrigin);
                }
                else
                {
                    queue.Insert(j,point);
                    distances.Insert(j,distToOrigin);
                }
            }
        }
        List<List<int>> res = new List<List<int>>();
        for (int i = 0; i < k; i++)
            res.Add(queue[i]);
        int[][] result = new int[res.Count][];
        for (int i = 0; i < res.Count; i++)
            result[i] = res[i].ToArray();
        return result;        
    }

}