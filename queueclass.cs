Here is an example implementation of a queue class in C#:

```
public class Queue<T>
{
    private readonly List<T> _items;

    public Queue()
    {
        _items = new List<T>();
    }

    public void Enqueue(T item)
    {
        _items.Add(item);
    }

    public T Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = _items[0];
        _items.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _items[0];
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

This implementation uses a list `_items` to store the elements of the queue in a first-in, first-out (FIFO) order.

The `Enqueue` method adds a new item to the back of the queue.

The `Dequeue` method removes and returns the front item from the queue. It throws an exception if the queue is empty.

The `Peek` method returns the front item from the queue without removing it. It also throws an exception if the queue is empty.

The `IsEmpty` method returns a boolean indicating if the queue is empty.

The `Count` method returns the number of items currently in the queue.