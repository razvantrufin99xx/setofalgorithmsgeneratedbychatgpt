Here is an example implementation of a stack class in C#:

```
public class Stack<T>
{
    private readonly List<T> _items;

    public Stack()
    {
        _items = new List<T>();
    }

    public void Push(T item)
    {
        _items.Add(item);
    }

    public T Pop()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        T item = _items[_items.Count - 1];
        _items.RemoveAt(_items.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _items[_items.Count - 1];
    }

    public bool IsEmpty()
    {
        return _items.Count == 0;
    }

    public int Count()
    {
        return _items.Count;
    }
}
```

This implementation uses a list `_items` to store the elements of the stack in a last-in, first-out (LIFO) order.

The `Push` method adds a new item to the top of the stack.

The `Pop` method removes and returns the top item from the stack. It throws an exception if the stack is empty.

The `Peek` method returns the top item from the stack without removing it. It also throws an exception if the stack is empty.

The `IsEmpty` method returns a boolean indicating if the stack is empty.

The `Count` method returns the number of items currently in the stack.