using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public static class HumanTactics
    {

        /// <summary>
        /// The function get board, row and column of an empty cell and seek for its only value as hidden single.
        /// return its value if found, if it has no possible values return -1 as error, and otherwise 0.
        /// </summary>
        /// <param name="b">Board</param>
        /// <param name="row">Row of cell</param>
        /// <param name="col">Column of cell</param>
        /// <returns>value of cell</returns>
        public static int FindHidden(Board b,int row, int col)
        {
            int possible = GetPossible(b,row, col);
            if (possible == 0)
                return -1;
            double powerOF2 = Math.Log(possible, 2);
            if (powerOF2 % 1 == 0)
                return (int)powerOF2 + 1;
            return 0;
        }

        /// <summary>
        /// The function get board, row and column of an empty cell and seek for its only value as naked single.
        /// return its value if found, if it has several values it has to have return -1 as error, and otherwise 0.
        /// </summary>
        /// <param name="b">Board</param>
        /// <param name="row">Row of cell</param>
        /// <param name="col">Column of cell</param>
        /// <returns>value of cell</returns>
        public static int FindNaked(Board b,int row, int col)
        {
            int cellNumInBox = ((row % b.SubSize) * b.SubSize) + (col % b.SubSize),
                possible = GetPossible(b,row, col),
                otherCellsPossabilities = 0,
                boxNum = b.GetBoxNum(row, col);

            for (int i = 0; i < b.Size; i++)
                if (i != cellNumInBox)
                {
                    int iRow = b.GetRowBySubIndecies(boxNum, i),
                        iCol = b.GetColBySubIndecies(boxNum, i);
                    int cellValue = (b.SudokuBoard)[iRow, iCol];
                    if (cellValue == 0)
                        otherCellsPossabilities |= GetPossible(b,iRow, iCol);
                }
            int negP = ~possible;
            int possabilityInCell = ~(otherCellsPossabilities | (negP));
            if (possabilityInCell == 1)
                return 1; 
            if (possabilityInCell == 0)
                return 0;
            double powerOF2 = Math.Log(possabilityInCell, 2);
            if (powerOF2 % 1 == 0)
                return (int)powerOF2 + 1;
            return -1;
        }

        /// <summary>
        /// The function get board, row and column of an empty cell and return number that its bits in possibe values are set.
        /// </summary>
        /// <param name="b">Board</param>
        /// <param name="row">Row of cell</param>
        /// <param name="col">Column of cell</param>
        /// <returns>number that represents possible values</returns>
        private static int GetPossible(Board b,int row, int col)
        {
            int rowData = b.Rows[row];
            int colData = b.Cols[col];
            int boxData = b.Boxes[b.GetBoxNum(row, col)];
            int mask = (int)Math.Pow(2, b.Size) - 1;//mask is number that its size-first-bits are set
                                                  //for eaxmple: size=5 -> masx=00011111
            int possibleValues = (rowData ^ mask) & (colData ^ mask) & (boxData ^ mask);//indices of '1' bits(+1) are values that are possible in that cell
                                                                                        //for example: possubleValues=010010  -> 2,5 are possible values
                                                                                        //int count = 0;
                                                                                        //while (possibleValues!=0)
                                                                                        //{
                                                                                        //    count++;
                                                                                        //    possibleValues &= possibleValues - 1;    // clear most right ON bit
                                                                                        //}
                                                                                        //return count;                                                                    
            return possibleValues;
        }

       /// <summary>
       /// This function gets a number and returns how many bits are set in it.
       /// </summary>
       /// <param name="n">number</param>
       /// <returns>number of set bits</returns>
        private static int CountSetBits(int n)
        {
            int[] table = Board.bitsSetTable256;
            return (table[n & 0xff] +
                    table[(n >> 8) & 0xff] +
                    table[(n >> 16) & 0xff] +
                    table[n >> 24]);
        }

        /// <summary>
        /// The function get board, row and column of an empty cell and return number of possible values there.
        /// </summary>
        /// <param name="b">Board</param>
        /// <param name="row">Row of cell</param>
        /// <param name="col">Column of cell</param>
        /// <returns>number of possible values</returns>
        public static int CountPossible(Board b,int row, int col)
        {
            return CountSetBits(GetPossible(b, row, col));
        }

    }
}
