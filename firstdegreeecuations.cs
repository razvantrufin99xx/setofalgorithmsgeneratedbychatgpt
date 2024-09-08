using System;

class FirstDegreeEquation
{
    static void Main()
    {
        Console.Write("Enter the coefficient a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter the constant b: ");
        double b = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            if (b == 0)
            {
                Console.WriteLine("The equation has infinitely many solutions.");
            }
            else
            {
                Console.WriteLine("The equation has no solution.");
            }
        }
        else
        {
            double x = -b / a;
            Console.WriteLine($"The solution to the equation {a}x + {b} = 0 is x = {x}");
        }
    }
}
