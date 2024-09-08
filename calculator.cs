using System;

class Calculator
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter an operator (+, -, *, /):");
            char op = Console.ReadLine()[0];

            Console.WriteLine("Enter second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = 0;

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        continue;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    continue;
            }

            Console.WriteLine($"Result: {result}");

            Console.WriteLine("Do you want to perform another calculation? (y/n):");
            string continueCalc = Console.ReadLine();
            if (continueCalc.ToLower() != "y")
            {
                break;
            }
        }
    }
}
