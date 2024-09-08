using System;

class PrimeNumbers
{
    static void Main()
    {
        Console.Write("Enter the start number: ");
        int startNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the end number: ");
        int endNumber = int.Parse(Console.ReadLine());

        Console.WriteLine($"Prime numbers between {startNumber} and {endNumber} are:");

        for (int i = startNumber; i <= endNumber; i++)
        {
            if (IsPrime(i))
            {
                Console.Write(i + " ");
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}
