using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        long factorial = Factorial(number);
        Console.WriteLine($"Factorial of {number} is {factorial}");
    }

    static long Factorial(int n)
    {
        if (n <= 1)
            return 1;
        else
            return n * Factorial(n - 1);
    }
}
