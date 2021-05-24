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

            //bool changedVal = false;
            bool isSolved = false; 
            while (!isSolved)
            {
                //changedVal = false; 
                for (int row = 0;   row < 9; row++)
                {
                    for (int col = 0;  col < 9; col++)
                    {
                        if (board.AllowableVals[row, col] != null && board.AllowableVals[row, col].Count == 1)
                        {
                            int val = board.AllowableVals[row, col][0]; 
                           isSolved =  board.SetValue(row, col, board.AllowableVals[row, col][0]);
                            //changedVal = true;
                            //Console.WriteLine("row" + row +  " col" + col + " value" + val );

                        }
                        else if(board.AllowableVals[row, col] != null && board.AllowableVals[row, col].Count > 1 )
                        {
                            for(int i = 0; i < board.AllowableVals[row, col].Count; i++)
                            {
                                SudokuBoard copy = new SudokuBoard(board);

                                isSolved = copy.SetValue(row, col, copy.AllowableVals[row, col][i]); 

                            }
                        }

                        //check if the game is solvable
                        //if it is, break out of the loop, then change the main board

                       
                      
                    }
                }
                
            }

            Console.WriteLine(board); 
            Console.WriteLine("Hello World!");

            //I lied (mac version?)
            //Console.WriteLine("this shouldn't work except VS is great");
        }
    }
}
