public class TimeMap {

    List<string> keys = new List<string>();
    List<List<(int, string)>> vals = new List<List<(int, string)>>();

    public TimeMap() {
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!keys.Contains(key))
        {
            keys.Add(key);
            List<(int, string)> val = new List<(int, string)>();
            val.Add((timestamp, value));
            vals.Add(val);
        }
        else
        {
            int ind = keys.IndexOf(key);
            vals[ind].Add((timestamp, value));
        }
    }
    
    public string Get(string key, int timestamp) {
        int ind = keys.IndexOf(key);
        if (ind == -1) return ""; /* key doesn't exist */

        if (vals[ind][vals[ind].Count-1].Item1 <= timestamp)
            return vals[ind][vals[ind].Count-1].Item2;

        return binarySearch(vals[ind], 0, vals[ind].Count, timestamp);
    }

    string binarySearch(List<(int, string)> vals, int start, int end, int target)
    {
        int mp = start + (end - start)/2;
        if (vals[mp].Item1 == target) return vals[mp].Item2;

        if (mp == 0 && vals[mp].Item1 > target) return "";
        
        if (vals[mp].Item1 > target && vals[mp-1].Item1 < target)
            return vals[mp-1].Item2;

        if (vals[mp].Item1 > target)
            return binarySearch(vals, start, mp-1, target);
        else
            return binarySearch(vals, mp+1, end, target);

        return "";
    }
}