HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4 };
HashSet<int> set2 = new HashSet<int> { 3, 4, 5, 6 };

set1.ExceptWith(set2);

Console.WriteLine("Difference:");
foreach (int item in set1)
{
    Console.Write(item + " ");
}
