using System;

class Polynomial
{
    private double[] coefficients;

    public Polynomial(double[] coefficients)
    {
        this.coefficients = coefficients;
    }

    public double Evaluate(double x)
    {
        double result = 0;
        for (int i = 0; i < coefficients.Length; i++)
        {
            result += coefficients[i] * Math.Pow(x, i);
        }
        return result;
    }

    public static Polynomial Add(Polynomial p1, Polynomial p2)
    {
        int maxDegree = Math.Max(p1.coefficients.Length, p2.coefficients.Length);
        double[] resultCoefficients = new double[maxDegree];

        for (int i = 0; i < maxDegree; i++)
        {
            double c1 = i < p1.coefficients.Length ? p1.coefficients[i] : 0;
            double c2 = i < p2.coefficients.Length ? p2.coefficients[i] : 0;
            resultCoefficients[i] = c1 + c2;
        }

        return new Polynomial(resultCoefficients);
    }

    public override string ToString()
    {
        string polynomialString = "";
        for (int i = coefficients.Length - 1; i >= 0; i--)
        {
            if (coefficients[i] != 0)
            {
                if (polynomialString != "")
                {
                    polynomialString += " + ";
                }
                polynomialString += $"{coefficients[i]}x^{i}";
            }
        }
        return polynomialString;
    }
}

class Program
{
    static void Main()
    {
        double[] coefficients1 = { 1, 0, 3 }; // Represents 1 + 0x + 3x^2
        double[] coefficients2 = { 2, 1 };    // Represents 2 + 1x

        Polynomial p1 = new Polynomial(coefficients1);
        Polynomial p2 = new Polynomial(coefficients2);

        Polynomial sum = Polynomial.Add(p1, p2);

        Console.WriteLine($"P1: {p1}");
        Console.WriteLine($"P2: {p2}");
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"P1 evaluated at x=2: {p1.Evaluate(2)}");
    }
}
