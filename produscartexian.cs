HashSet<int> set1 = new HashSet<int> { 1, 2 };
HashSet<int> set2 = new HashSet<int> { 3, 4 };

Console.WriteLine("Cartesian Product:");
foreach (int item1 in set1)
{
    foreach (int item2 in set2)
    {
        Console.WriteLine($"({item1}, {item2})");
    }
}
