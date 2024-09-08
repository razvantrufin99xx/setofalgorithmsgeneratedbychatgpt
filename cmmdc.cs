using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the first number:");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second number:");
        int b = int.Parse(Console.ReadLine());

        int gcd = FindGCD(a, b);
        Console.WriteLine($"The GCD of {a} and {b} is {gcd}");
    }

    static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }
}
