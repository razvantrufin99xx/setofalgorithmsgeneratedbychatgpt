using System;
using System.Collections.Generic;

public class SubsetSum
{
    public bool IsSubsetSum(List<int> set, int n, int sum)
    {
        if (sum == 0)
            return true;

        if (n == 0 && sum != 0)
            return false;

        if (set[n - 1] > sum)
            return IsSubsetSum(set, n - 1, sum);

        return IsSubsetSum(set, n - 1, sum) ||
               IsSubsetSum(set, n - 1, sum - set[n - 1]);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<int> set = new List<int> { 3, 34, 4, 12, 5, 2 };
        int sum = 9;
        int n = set.Count;

        SubsetSum subsetSum = new SubsetSum();
        if (subsetSum.IsSubsetSum(set, n, sum))
            Console.WriteLine("Found a subset with given sum");
        else
            Console.WriteLine("No subset with given sum");
    }
}
