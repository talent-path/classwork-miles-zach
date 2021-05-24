using System;
using System.Collections.Generic;

namespace SudokuSolver
{

    public class SudokuBoard
    {
        //int[][] _vals = new int[9][];

        private int[,] _vals = new int[9, 9];
        public List<int>[,] AllowableVals { get; } = new List<int>[9, 9];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vals">The initial values of the board (0 for blanks)</param>
        public SudokuBoard( int[,] vals )
        {
            //"classic" 2d array (array of arrays)
            //C# can do better
            //for( int i = 0; i < 9; i++)
            //{
            //    _vals[i] = new int[9];
            //}

            //this is bad because it allows someone else to alter the incoming array
            //which will affect us internally
            //_vals = vals;

            //one option is to just loop and copy each value individually
            //for (int i = 0; i < 9; i++)
            //{
            //    for (int j = 0; j < 9; j++)
            //    {
            //        _vals[i, j] = vals[i, j];
            //    }
            //}

            //faster
            Array.Copy(vals, _vals, 81);

            PopulateAllowableVals();
        }

        public SudokuBoard(SudokuBoard board)
        {
            Array.Copy(board._vals, _vals, 81 );
            PopulateAllowableVals();

        }

        private void PopulateAllowableVals()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_vals[i, j] == 0)
                    {
                        AllowableVals[i, j] = ComputeAllowedVals(i, j);
                    }
                    else
                    {
                        AllowableVals[i, j] = null;
                    }
                }
            }
        }

        internal bool SetValue(int row, int col, int v)
        {
            //update _vals
            _vals[row, col] = v;

            //call PopulateAllowableVals()
            PopulateAllowableVals();
            return IsBoardSolved(); 
        }

        /// <summary>
        /// Compute the allowed values at a given position.
        /// </summary>
        /// <returns>A list of numbers that could go at the current location.</returns>
        private List<int> ComputeAllowedVals(int row, int col)
        {

            List<int> allAllowed = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //check the row
            for( int x = 0; x < 9; x++)
            {
                if( _vals[row, x] != 0)
                {
                    //we found a value in the current row
                    //that means we can't use it again
                    //so now we need to make sure it isn't in the list
                    //of candidates

                    int allowedIndex = allAllowed.FindIndex(v => v == _vals[row, x]);

                    if( allowedIndex != -1)
                    {
                        //we found that the number is still available despite being in the row
                        //that means we need to remove it
                        allAllowed.RemoveAt(allowedIndex);
                    }

                }
            }

            //check the column
            for( int y = 0; y < 9; y++)
            {
                if( _vals[y, col] != 0)
                {
                    int allowedIndex = allAllowed.FindIndex(v => v == _vals[y, col]);
                    if( allowedIndex != -1)
                    {
                        allAllowed.RemoveAt(allowedIndex);
                    }
                }
            }

            //  [0,0]  [0,1] [0,2] | [0,3] [0,4]  [0,5] | [0,6]  [0,7] [0,8] 
            //  [1,0]  [1,1] [1,2] | [1,3] [1,4]  [1,5] | [1,6]  [1,7] [1,8] 
            //  [2,0]  [2,1] [2,2] | [2,3] [2,4]  [2,5] | [2,6]  [2,7] [2,8]
            //---------------------------------------------------------------
            //  [3,0]  [3,1] [3,2] | [3,3] [3,4]  [3,5] | [3,6]  [3,7] [3,8] 
            //  [4,0]  [4,1] [4,2] | [4,3] [4,4]  [4,5] | [4,6]  [4,7] [4,8] 
            //  [5,0]  [5,1] [5,2] | [5,3] [5,4]  [5,5] | [5,6]  [5,7] [5,8] 
            //---------------------------------------------------------------
            //  [6,0]  [6,1] [6,2] | [6,3] [6,4]  [6,5] | [6,6]  [6,7] [6,8] 
            //  [7,0]  [7,1] [7,2] | [7,3] [7,4]  [7,5] | [7,6]  [7,7] [7,8] 
            //  [8,0]  [8,1] [8,2] | [8,3] [8,4]  [8,5] | [8,6]  [8,7] [8,8]

            //say we're at 4,7
            //we want to get to 3,6
            //row = 4
            //col = 7

            //row - row % 3 = 3
            //col - col % 3 = 6


            //compute box upper left
            int upperLeftRow = row - row % 3;
            int upperLeftCol = col - col % 3;

            for( int y = upperLeftRow; y < upperLeftRow + 3; y++)
            {
                for (int x = upperLeftCol; x < upperLeftCol + 3; x++)
                {
                    if( _vals[y,x] != 0)
                    {
                        int allowedIndex = allAllowed.FindIndex(v => v == _vals[y, x]);
                        if( allowedIndex != -1)
                        {
                            allAllowed.RemoveAt(allowedIndex);
                        }
                    }
                }
            }

            return allAllowed;
        }

        private bool IsBoardSolved()
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(_vals[i,j] != 0)
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }
    }

}
