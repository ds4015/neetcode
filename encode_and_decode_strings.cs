public class Solution {

    private List<string> orig = new List<string>();

    public string Encode(IList<string> strs) {
        string encoded = "";
        foreach (var s in strs)
        {
            encoded += s;
            orig.Add(s);
        }
        return encoded;
    }

    public List<string> Decode(string s) {
        return orig;
   }
}