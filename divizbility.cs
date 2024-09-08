using System;

class DivisibilityCheck
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine($"{number} is divisible by 2.");
        }
        else
        {
            Console.WriteLine($"{number} is not divisible by 2.");
        }

        if (number % 3 == 0)
        {
            Console.WriteLine($"{number} is divisible by 3.");
        }
        else
        {
            Console.WriteLine($"{number} is not divisible by 3.");
        }

        if (number % 5 == 0)
        {
            Console.WriteLine($"{number} is divisible by 5.");
        }
        else
        {
            Console.WriteLine($"{number} is not divisible by 5.");
        }
    }
}
