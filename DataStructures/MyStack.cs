// MyStack: last in, first out.
//
// Part C. Build this class along with the Class 2 demo.
// A stack HAS A MyList. It does not inherit from one.
public class MyStack<T>
{
    // TODO: Part C. Declare one private field: a MyList<T> that holds
    // the items. The top of the stack is the END of the list.
    private MyList<T> items = new MyList<T>();
    // TODO: Part C. How many items are on the stack.
    public int Count => items.Count;

    // TODO: Part C. True when the stack holds nothing.
    public bool IsEmpty => items.Count == 0;

    // Put an item on top.
    public void Push(T item)
    {
        // TODO: Part C, demo
        items.Add(item);
    }

    // Take the top item off and hand it back.
    public T Pop()
    {
        // TODO: Part C, demo
        T top = Peek();
        items.RemoveAt(items.Count - 1);
        return top;
    }

    // Look at the top item without removing it. On an empty stack, throw
    // InvalidOperationException("Stack is empty.").
    public T Peek()
    {
        // TODO: Part C, demo
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return items[items.Count - 1];
    }
}