using System;

class Program
{
    static void Main()
    {
        int n = 10; // Number of terms to display
        int firstNumber = 0, secondNumber = 1, nextNumber;

        Console.WriteLine("Fibonacci Sequence:");
        Console.Write(firstNumber + " " + secondNumber + " ");

        for (int i = 2; i < n; i++)
        {
            nextNumber = firstNumber + secondNumber;
            Console.Write(nextNumber + " ");
            firstNumber = secondNumber;
            secondNumber = nextNumber;
        }
    }
}


//recursive 

using System;

class Program
{
    static void Main()
    {
        int n = 10; // Number of terms to display
        Console.WriteLine("Fibonacci Sequence:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }
    }

    static int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
