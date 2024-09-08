using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var list = new List<int> { 1, 2, 3 };
        var permutations = GetPermutations(list, list.Count);
        
        foreach (var perm in permutations)
        {
            Console.WriteLine(string.Join(", ", perm));
        }
    }

    static List<List<T>> GetPermutations<T>(List<T> list, int length)
    {
        if (length == 1)
            return list.Select(t => new List<T> { t }).ToList();

        var perms = GetPermutations(list, length - 1);

        return list.SelectMany(t => perms, (t, perm) => new List<T> { t }.Concat(perm).ToList()).ToList();
    }
}
