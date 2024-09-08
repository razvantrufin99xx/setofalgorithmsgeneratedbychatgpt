using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> elements = new List<int> { 1, 2, 3, 4 };
        int r = 3;
        var arrangements = GetArrangements(elements, r);

        foreach (var arrangement in arrangements)
        {
            Console.WriteLine(string.Join(", ", arrangement));
        }
    }

    static List<List<T>> GetArrangements<T>(List<T> list, int length)
    {
        List<List<T>> result = new List<List<T>>();
        if (length == 1)
        {
            foreach (var item in list)
            {
                result.Add(new List<T> { item });
            }
            return result;
        }

        foreach (var item in list)
        {
            List<T> remaining = new List<T>(list);
            remaining.Remove(item);
            foreach (var arrangement in GetArrangements(remaining, length - 1))
            {
                arrangement.Insert(0, item);
                result.Add(arrangement);
            }
        }

        return result;
    }
}
