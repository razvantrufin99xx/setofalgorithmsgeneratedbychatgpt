HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4 };
HashSet<int> set2 = new HashSet<int> { 3, 4, 5, 6 };

set1.IntersectWith(set2);

Console.WriteLine("Intersection:");
foreach (int item in set1)
{
    Console.Write(item + " ");
}
