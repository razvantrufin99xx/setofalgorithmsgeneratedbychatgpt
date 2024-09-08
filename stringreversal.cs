using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        string reversed = ReverseString(input);
        Console.WriteLine($"Reversed string: {reversed}");
    }

    static string ReverseString(string str)
    {
        if (str.Length <= 1)
            return str;
        else
            return str[str.Length - 1] + ReverseString(str.Substring(0, str.Length - 1));
    }
}
