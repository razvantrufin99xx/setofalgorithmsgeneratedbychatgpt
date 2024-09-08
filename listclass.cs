In C#, a list is implemented using the `List<T>` class in the `System.Collections.Generic` namespace. Here is an example usage of the `List<T>` class:

```
using System.Collections.Generic;

List<int> numbers = new List<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Remove(2);

foreach (int number in numbers)
{
    Console.WriteLine(number);
}
```

This code creates a list of integers, adds three numbers to it, and then removes the number 2. Finally, it prints out the remaining numbers using a `foreach` loop.

The `List<T>` class has many other methods for manipulating and accessing the list, such as `Insert`, `Contains`, `IndexOf`, `Clear`, and `Count`. For example:

```
using System.Collections.Generic;

List<string> words = new List<string>();
words.Add("cat");
words.Add("dog");
words.Add("fish");
words.Insert(1, "bird");

if (words.Contains("dog"))
{
    int index = words.IndexOf("dog");
    words[index] = "puppy";
}

words.Clear();

Console.WriteLine(words.Count);  // prints 0
``` 

This code creates a list of strings, adds three words to it, inserts another word at the second position, checks if it contains the word "dog", replaces "dog" with "puppy" if it does, clears the list, and finally prints its count (which should be 0).