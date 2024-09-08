using System;

public class StrassenMatrixMultiplication
{
    public int[,] Multiply(int[,] A, int[,] B)
    {
        int n = A.GetLength(0);
        int[,] result = new int[n, n];

        if (n == 1)
        {
            result[0, 0] = A[0, 0] * B[0, 0];
        }
        else
        {
            int newSize = n / 2;
            int[,] A11 = new int[newSize, newSize];
            int[,] A12 = new int[newSize, newSize];
            int[,] A21 = new int[newSize, newSize];
            int[,] A22 = new int[newSize, newSize];

            int[,] B11 = new int[newSize, newSize];
            int[,] B12 = new int[newSize, newSize];
            int[,] B21 = new int[newSize, newSize];
            int[,] B22 = new int[newSize, newSize];

            // Divide matrices into quadrants
            DivideMatrix(A, A11, 0, 0);
            DivideMatrix(A, A12, 0, newSize);
            DivideMatrix(A, A21, newSize, 0);
            DivideMatrix(A, A22, newSize, newSize);

            DivideMatrix(B, B11, 0, 0);
            DivideMatrix(B, B12, 0, newSize);
            DivideMatrix(B, B21, newSize, 0);
            DivideMatrix(B, B22, newSize, newSize);

            // Strassen's formula
            int[,] M1 = Multiply(Add(A11, A22), Add(B11, B22));
            int[,] M2 = Multiply(Add(A21, A22), B11);
            int[,] M3 = Multiply(A11, Subtract(B12, B22));
            int[,] M4 = Multiply(A22, Subtract(B21, B11));
            int[,] M5 = Multiply(Add(A11, A12), B22);
            int[,] M6 = Multiply(Subtract(A21, A11), Add(B11, B12));
            int[,] M7 = Multiply(Subtract(A12, A22), Add(B21, B22));

            // C matrix
            int[,] C11 = Add(Subtract(Add(M1, M4), M5), M7);
            int[,] C12 = Add(M3, M5);
            int[,] C21 = Add(M2, M4);
            int[,] C22 = Add(Subtract(Add(M1, M3), M2), M6);

            // Combine quadrants into a full matrix
            CombineMatrix(result, C11, 0, 0);
            CombineMatrix(result, C12, 0, newSize);
            CombineMatrix(result, C21, newSize, 0);
            CombineMatrix(result, C22, newSize, newSize);
        }

        return result;
    }

    private void DivideMatrix(int[,] source, int[,] dest, int row, int col)
    {
        for (int i = 0; i < dest.GetLength(0); i++)
        {
            for (int j = 0; j < dest.GetLength(1); j++)
            {
                dest[i, j] = source[i + row, j + col];
            }
        }
    }

    private void CombineMatrix(int[,] result, int[,] source, int row, int col)
    {
        for (int i = 0; i < source.GetLength(0); i++)
        {
            for (int j = 0; j < source.GetLength(1); j++)
            {
                result[i + row, j + col] = source[i, j];
            }
        }
    }

    private int[,] Add(int[,] A, int[,] B)
    {
        int n = A.GetLength(0);
        int[,] result = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result[i, j] = A[i, j] + B[i, j];
            }
        }

        return result;
    }

    private int[,] Subtract(int[,] A, int[,] B)
    {
        int n = A.GetLength(0);
        int[,] result = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result[i, j] = A[i, j] - B[i, j];
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[,] A = { { 1, 2 }, { 3, 4 } };
        int[,] B = { { 5, 6 }, { 7, 8 } };

        StrassenMatrixMultiplication smm = new StrassenMatrixMultiplication();
        int[,] result = smm.Multiply(A, B);

        Console.WriteLine("Resultant Matrix:");
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
