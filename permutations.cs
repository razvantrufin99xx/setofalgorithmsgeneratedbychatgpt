using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> elements = new List<int> { 1, 2, 3 };
        var permutations = GetPermutations(elements, 0, elements.Count - 1);

        foreach (var permutation in permutations)
        {
            Console.WriteLine(string.Join(", ", permutation));
        }
    }

    static List<List<T>> GetPermutations<T>(List<T> list, int start, int end)
    {
        List<List<T>> result = new List<List<T>>();

        if (start == end)
        {
            result.Add(new List<T>(list));
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                Swap(list, start, i);
                result.AddRange(GetPermutations(list, start + 1, end));
                Swap(list, start, i); // backtrack
            }
        }

        return result;
    }

    static void Swap<T>(List<T> list, int index1, int index2)
    {
        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}
