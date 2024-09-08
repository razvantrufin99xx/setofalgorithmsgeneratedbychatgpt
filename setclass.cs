using System;
using System.Collections.Generic;

public class MySet<T>
{
    // Using a Dictionary to simulate a set, where the keys represent the elements
    private Dictionary<T, bool> _set;

    public MySet()
    {
        _set = new Dictionary<T, bool>();
    }

    // Adds an element to the set
    public void Add(T item)
    {
        if (!_set.ContainsKey(item))
        {
            _set[item] = true;
        }
    }

    // Checks if the set contains the element
    public bool Contains(T item)
    {
        return _set.ContainsKey(item);
    }

    // Removes an element from the set
    public bool Remove(T item)
    {
        return _set.Remove(item);
    }

    // Returns the number of elements in the set
    public int Count()
    {
        return _set.Count;
    }

    // Displays all elements in the set
    public void Display()
    {
        foreach (var item in _set.Keys)
        {
            Console.WriteLine(item);
        }
    }
}

class Program
{
    static void Main()
    {
        // Example usage of the custom MySet class
        MySet<int> set = new MySet<int>();

        set.Add(1);
        set.Add(2);
        set.Add(3);

        Console.WriteLine("Set contains 2: " + set.Contains(2)); // True
        Console.WriteLine("Set contains 5: " + set.Contains(5)); // False

        set.Remove(2);

        Console.WriteLine("Set contains 2 after removal: " + set.Contains(2)); // False
        Console.WriteLine("Number of elements in the set: " + set.Count()); // 2

        Console.WriteLine("Elements in the set:");
        set.Display();
    }
}
