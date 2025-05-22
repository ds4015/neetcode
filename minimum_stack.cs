public class MinStack {

    List<int> stack;

    public MinStack() {
        stack = new List<int>();
    }
    
    public void Push(int val) {
        stack.Insert(0, val);        
    }
    
    public void Pop() {
        if (stack.Count > 0)
            stack.RemoveAt(0);        
    }
    
    public int Top() {
        if (stack.Count > 0)
            return stack[0];
        return -1;    
    }
    
    public int GetMin() {
        int[] stackArr = new int[stack.Count];
        stack.CopyTo(stackArr);
        Array.Sort(stackArr);
        return stackArr[0];        
    }
}