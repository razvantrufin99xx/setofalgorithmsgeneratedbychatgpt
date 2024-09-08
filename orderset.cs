using System;
using System.Collections.Generic;
using System.Linq;

public class OrderedSet<T> where T : IComparable<T>
{
    private HashSet<T> _set;

    public OrderedSet()
    {
        _set = new HashSet<T>();
    }

    // Add an element to the set
    public bool Add(T item)
    {
        return _set.Add(item); // Returns false if item already exists
    }

    // Remove an element from the set
    public bool Remove(T item)
    {
        return _set.Remove(item); // Returns false if item doesn't exist
    }

    // Get the count of elements in the set
    public int Count()
    {
        return _set.Count;
    }

    // Display elements in the set
    public void Display()
    {
        foreach (var item in _set)
        {
            Console.WriteLine(item);
        }
    }

    // Return elements sorted in ascending order
    public List<T> GetSortedSet(bool ascending = true)
    {
        if (ascending)
        {
            return _set.OrderBy(x => x).ToList(); // Sort in ascending order
        }
        else
        {
            return _set.OrderByDescending(x => x).ToList(); // Sort in descending order
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        OrderedSet<int> orderedSet = new OrderedSet<int>();

        orderedSet.Add(15);
        orderedSet.Add(3);
        orderedSet.Add(8);
        orderedSet.Add(5);
        orderedSet.Add(10);

        Console.WriteLine("Original Set:");
        orderedSet.Display();

        Console.WriteLine("\nSet in Ascending Order:");
        var ascendingSet = orderedSet.GetSortedSet(ascending: true);
        foreach (var item in ascendingSet)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nSet in Descending Order:");
        var descendingSet = orderedSet.GetSortedSet(ascending: false);
        foreach (var item in descendingSet)
        {
            Console.WriteLine(item);
        }
    }
}
