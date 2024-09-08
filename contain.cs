HashSet<int> set = new HashSet<int> { 1, 2, 3, 4 };

int element = 3;
bool isMember = set.Contains(element);

Console.WriteLine($"{element} is in the set: {isMember}");
