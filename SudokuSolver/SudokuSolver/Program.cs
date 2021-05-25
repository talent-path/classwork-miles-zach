using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] vals = {
                { 0, 5, 0, 3, 4, 7, 1, 9, 0 },
                { 0, 0, 7, 0, 0, 0, 0, 6, 0 },
                { 2, 9, 0, 8, 6, 0, 7, 5, 0 },
                { 4, 0 ,0, 0, 0, 6, 0, 3, 0 },
                { 0, 0, 0, 1, 9, 4, 0, 0, 0 },
                { 0, 6, 0, 2, 0, 0, 0, 0, 5 },
                { 0, 2, 5, 0, 1, 0, 0, 4, 9 },
                { 0, 1, 0, 0, 0, 0, 2, 0, 0 },
                { 0, 4, 9, 6, 3, 2, 0, 1, 0 }
            };

            SudokuBoard board = new SudokuBoard(vals);

            Solve(board);


        }

        static bool Solve(SudokuBoard board)
        {
            int minCol = -1;
            int minRow = -1;
            int minPossibilities = 9;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board.AllowableVals[row, col] != null && board.AllowableVals[row, col].Count < minPossibilities)
                    {
                        minCol = col;
                        minRow = row;
                        minPossibilities = board.AllowableVals[row, col].Count;
                    }

                }

            }

            bool success = false;
            if (minPossibilities > 0)
            {
                foreach (var allowableVal in board.AllowableVals[minRow, minCol])
                {
                    
                    board.SetValue(minRow, minCol, allowableVal);

                    success = board.IsComplete;

                    if(success)
                    {
                        PrintBoard(board);
                    }
                    else
                    {
                        success = Solve(board);
                    }

                    if (!success)
                    {
                        board.SetValue(minRow, minCol, 0);
                    }
                    else break;
                }
            }
            return success;
        }

        static void PrintBoard(SudokuBoard board)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Console.Write(board.Vals[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
