using System;

class MultipleCheck
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int number1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int number2 = int.Parse(Console.ReadLine());

        if (IsMultipleOf(number1, number2))
        {
            Console.WriteLine($"{number1} is a multiple of {number2}.");
        }
        else
        {
            Console.WriteLine($"{number1} is not a multiple of {number2}.");
        }
    }

    static bool IsMultipleOf(int num1, int num2)
    {
        return num1 % num2 == 0;
    }
}
