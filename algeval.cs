using System;
using System.Data;

class AlgebraicEvaluation
{
    static void Main()
    {
        Console.Write("Enter an algebraic expression: ");
        string expression = Console.ReadLine();

        try
        {
            var result = EvaluateExpression(expression);
            Console.WriteLine($"The result of the expression '{expression}' is: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error evaluating expression: {ex.Message}");
        }
    }

    static double EvaluateExpression(string expression)
    {
        DataTable table = new DataTable();
        return Convert.ToDouble(table.Compute(expression, string.Empty));
    }
}
