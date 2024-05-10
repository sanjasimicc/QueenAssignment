using System;

public class QueenChessAssignment {
    private static int BoardSize = 8;
    private static int SolutionCount = 0;

    public static void SolveQueensProblem(int[,] board, int col) {
        if(col == BoardSize) {
            Console.WriteLine("Solution:");
            PrintBoard(board);
            Console.WriteLine();
            SolutionCount++;
            return;
        }
    
        for(int row = 0; row < BoardSize; row++) {
            if (IsSafe(board, row, col)) {
                board[row, col] = 1; 
                SolveQueensProblem(board, col + 1);
                board[row, col] = 0;
            }
        }
    }

   public static bool IsSafe(int[,] board, int row, int col) {
    // Check left upper diagonal
    for (int x = row, y = col; x >= 0 && y >= 0; x--, y--) {
        if (board[x, y] == 1) {
            return false;
        }
    }

    // Check right upper diagonal
    for (int x = row, y = col; x >= 0 && y < BoardSize; x--, y++) {
        if (board[x, y] == 1) {
            return false;
        }
    }

    // Check left lower diagonal
    for (int x = row, y = col; x < BoardSize && y >= 0; x++, y--) {
        if (board[x, y] == 1) {
            return false;
        }
    }

    // Check right lower diagonal
    for (int x = row, y = col; x < BoardSize && y < BoardSize; x++, y++) {
        if (board[x, y] == 1) {
            return false;
        }
    }

    // Check column
    for (int x = 0; x < col; x++) {
        if (board[row, x] == 1) {
            return false;
        }
    }

    return true;
}


    public static void PrintBoard(int[,] board) {
        for(int i = 0; i < BoardSize; i++) {
            for(int j = 0; j < BoardSize; j++) {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void Main(string[] args) {
        int[,] board = new int[BoardSize, BoardSize];
        SolveQueensProblem(board, 0);
        Console.WriteLine("Number of solutions: " + SolutionCount);
    }
}
