using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the position: ");
        int position = Convert.ToInt32(Console.ReadLine());
        int result = Fibonacci(position);
        Console.WriteLine($"Fibonacci number at position {position} is {result}");
    }

    static int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        else
            return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
