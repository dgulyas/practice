public class MyStack {

    private Queue<int> main;
    private Queue<int> backup;

    public MyStack() {
        main = new Queue<int>();
        backup = new Queue<int>();
    }
    
    public void Push(int x) {
        while(main.Count > 0){
            backup.Enqueue(main.Dequeue());
        }
        main.Enqueue(x);
        while(backup.Count > 0){
            main.Enqueue(backup.Dequeue());
        }
    }
    
    public int Pop() {
        return main.Dequeue();
    }
    
    public int Top() {
        return main.Peek();
    }
    
    public bool Empty() {
        return main.Count < 1;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */