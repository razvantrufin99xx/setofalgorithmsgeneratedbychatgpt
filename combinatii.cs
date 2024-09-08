using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> elements = new List<int> { 1, 2, 3, 4, 5 };
        int r = 3;
        var combinations = GetCombinations(elements, r);

        foreach (var combination in combinations)
        {
            Console.WriteLine(string.Join(", ", combination));
        }
    }

    static List<List<T>> GetCombinations<T>(List<T> list, int length)
    {
        List<List<T>> result = new List<List<T>>();
        if (length == 0)
        {
            result.Add(new List<T>());
            return result;
        }

        for (int i = 0; i < list.Count; i++)
        {
            List<T> remaining = list.GetRange(i + 1, list.Count - (i + 1));
            foreach (var combination in GetCombinations(remaining, length - 1))
            {
                combination.Insert(0, list[i]);
                result.Add(combination);
            }
        }

        return result;
    }
}
