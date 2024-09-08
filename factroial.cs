using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        long factorial = 1;

        while (number > 1)
        {
            factorial *= number;
            number--;
        }

        Console.WriteLine($"Factorial is {factorial}");
    }
}
