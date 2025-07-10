public class LRUCache {

    Dictionary<int,int> cache;
    LinkedList<int> timestamps = new LinkedList<int>();
    int cap = 0;

    public LRUCache(int capacity) {
        cache = new Dictionary<int,int>(capacity);
        cap = capacity;
    }
    
    public int Get(int key) {
        int value = 0;
        bool exists = cache.TryGetValue(key, out value);
        if (exists)
        {
            timestamps.Remove(key);
            timestamps.AddLast(key);
            return value;
        }
        return -1;
    }
    
    public void Put(int key, int value) {
        if (cache.ContainsKey(key))
        {
            cache[key] = value;
            timestamps.Remove(key);
            timestamps.AddLast(key);
        }
        else if (cache.Count < cap)
        {
            cache.Add(key,value);
            timestamps.AddLast(key);
        }
        else
        {
            cache.Remove(timestamps.First.Value);
            cache.Add(key,value);
            timestamps.RemoveFirst();
            timestamps.AddLast(key);
        }
    }
}