using System;

public class NQueens
{
    public bool IsSafe(int[,] board, int row, int col, int N)
    {
        // Check this row on left side
        for (int i = 0; i < col; i++)
            if (board[row, i] == 1)
                return false;

        // Check upper diagonal on left side
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;

        // Check lower diagonal on left side
        for (int i = row, j = col; i < N && j >= 0; i++, j--)
            if (board[i, j] == 1)
                return false;

        return true;
    }

    public bool SolveNQueensUtil(int[,] board, int col, int N)
    {
        if (col >= N)
            return true;

        for (int i = 0; i < N; i++)
        {
            if (IsSafe(board, i, col, N))
            {
                // Place the queen
                board[i, col] = 1;

                // Recur to place the rest of the queens
                if (SolveNQueensUtil(board, col + 1, N))
                    return true;

                // If placing queen in board[i, col] leads to a solution, remove queen
                board[i, col] = 0; // BACKTRACK
            }
        }

        return false;
    }

    public void SolveNQueens(int N)
    {
        int[,] board = new int[N, N];

        if (SolveNQueensUtil(board, 0, N) == false)
        {
            Console.WriteLine("Solution does not exist");
            return;
        }

        PrintBoard(board, N);
    }

    private void PrintBoard(int[,] board, int N)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(board[i, j] + " ");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int N = 4; // You can change N for different board sizes
        NQueens queens = new NQueens();
        queens.SolveNQueens(N);
    }
}
