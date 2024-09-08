using System;

public class SudokuSolver
{
    public bool IsSafe(int[,] board, int row, int col, int num)
    {
        // Check the row and column
        for (int x = 0; x < 9; x++)
            if (board[row, x] == num || board[x, col] == num)
                return false;

        // Check the 3x3 sub-grid
        int startRow = row - row % 3;
        int startCol = col - col % 3;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (board[i + startRow, j + startCol] == num)
                    return false;

        return true;
    }

    public bool SolveSudoku(int[,] board, int row, int col)
    {
        if (row == 9 - 1 && col == 9)
            return true;

        if (col == 9)
        {
            row++;
            col = 0;
        }

        if (board[row, col] != 0)
            return SolveSudoku(board, row, col + 1);

        for (int num = 1; num <= 9; num++)
        {
            if (IsSafe(board, row, col, num))
            {
                board[row, col] = num;

                if (SolveSudoku(board, row, col + 1))
                    return true;

                board[row, col] = 0; // BACKTRACK
            }
        }

        return false;
    }

    public void PrintBoard(int[,] board)
    {
        for (int r = 0; r < 9; r++)
        {
            for (int d = 0; d < 9; d++)
            {
                Console.Write(board[r, d]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[,] board = new int[,]
        {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };

        SudokuSolver solver = new SudokuSolver();
        if (solver.SolveSudoku(board, 0, 0))
            solver.PrintBoard(board);
        else
            Console.WriteLine("No solution exists");
    }
}
