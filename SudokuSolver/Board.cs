using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Board
    {
        private int[,] sudokuBoard;//the board
        private int size;//sqrt of cells number =no. of rows for example
        private int subSize;//sqrt of size

        //arrays of rows/cols/boxes(for convenience i call all these 'groups')
        //each number in cell represents group(row/col/..)
        //indices of the bits that are set are the numbers in that group
        private int[] rows;
        private int[] cols;
        private int[] boxes;
        //lookup table of all set bits in a byte
        public static int[] bitsSetTable256 = new int[256];

        public int[,] SudokuBoard
        {
            get
            {
                return sudokuBoard;
            }
            set
            {
                sudokuBoard = value;
            }
        }
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        public int SubSize
        {
            get
            {
                return subSize;
            }
            set
            {
                subSize = value;
            }
        }
        public int[] Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
            }
        }
        public int[] Cols
        {
            get
            {
                return cols;
            }
            set
            {
                cols = value;
            }
        }
        public int[] Boxes
        {
            get
            {
                return boxes;
            }
            set
            {
                boxes = value;
            }
        }
        public int[] BitsSetTable256
        {
            get
            {
                return bitsSetTable256;
            }
        }

        //CONSTRUCTOR: get a matrix that represents s board  and its size. If its valid, builds new board. Otherwise, throws InputInvalidException.
        public Board(int[,] board, int size)
        {
            this.size = size;
            subSize = (int)Math.Sqrt(size);
            rows = new int[size];
            cols = new int[size];
            boxes = new int[size];
            bool isValid = true;
            for (int i = 0; i < size && isValid; i++)
            {
                for (int j = 0; j < size && isValid; j++)
                {
                    if (board[i, j] != 0)
                    {
                        if (!IsValueValid(i, j, board[i, j]))
                        {
                            sudokuBoard = null;
                            isValid = false;
                        }
                        else
                            InserValue(i, j, board[i, j]);
                    }
                }
            }
            if (isValid)
                sudokuBoard = board;
        }

        //static constructor for bitsSetTable256
        static Board()
        {
            // To initially generate the
            // table algorithmically
            bitsSetTable256[0] = 0;
            for (int i = 0; i < 256; i++)
            {
                bitsSetTable256[i] = (i & 1) +
                bitsSetTable256[i / 2];
            }
        }

        /// <summary>
        /// The function that gets row and column of a cell and calculates the bunber of the box the cell is in
        /// </summary>
        /// <param name="row">Row of cell</param>
        /// <param name="col">Col of cell</param>
        /// <returns>number of box of the cell</returns>
        public int GetBoxNum(int row, int col)
        {
            int startRow = row - (row % subSize);//start row for sub board(box)
            int startCol = col - (col % subSize);//start col for sub board(box)
            return startRow + startCol / subSize;
        }

        /// <summary>
        /// THe function gets index of row and returns its number from rows array (the number represents the possible values in that row)
        /// </summary>
        /// <param name="row">Index of row</param>
        /// <returns>number that represents the row </returns>
        public int GetRow(int row)
        {
            return rows[row];
        }

        /// <summary>
        /// The function gets a number that represents(bitwise) a group(box/col/row) and a value and returns if its already exists
        /// </summary>
        /// <param name="group">number that represents a group</param>
        /// <param name="value">value to check</param>
        /// <returns>bool-is the value exisist</returns>
        private bool DoesExistInGroup(int group, int value)
        {
            int mask = 1 << (value - 1);
            return (group & mask) != 0;
        }

        /// <summary>
        /// The function gets row and column of cell and a value and checks whether the vale is valid in the cell
        /// </summary>
        /// <param name="row">Row of cell</param>
        /// <param name="col">Column of cell</param>
        /// <param name="value">Value to check</param>
        /// <returns>bool-is value valid</returns>
        public bool IsValueValid(int row, int col, int value)
        {
            int numOfBox = GetBoxNum(row, col);
            return !(DoesExistInGroup(rows[row], value) || DoesExistInGroup(boxes[numOfBox], value) || DoesExistInGroup(cols[col], value));
        }

        /// <summary>
        /// The function gets row and column of cell and a value and insertrs the value to array of rows,cols,boxes
        /// </summary>
        /// <param name="row">Row of cell</param>
        /// <param name="col">Column of cell</param>
        /// <param name="value">Value to insert</param>
        public void InserValue(int row, int col, int value)
        {
            int numOfBox = GetBoxNum(row, col);
            int mask = 1 << (value - 1);
            rows[row] |= mask;//set bit of current number in the current row in rows array
            cols[col] |= mask;//set bit of current number in the current column in cols array
            boxes[numOfBox] |= mask;//set bit of current number in the current box in boxes array
        }

        /// <summary>
        /// The function gets row and column of cell and delete its value from array of rows,cols,boxes
        /// </summary>
        /// <param name="row">row of cell</param>
        /// <param name="col">column of cell</param>
        public void DeleteValue(int row, int col)
        {
            int value = sudokuBoard[row, col];
            int numOfBox = GetBoxNum(row, col);
            int mask = ~(1 << (value - 1));
            rows[row] &= mask;//turn off bit of current number in the current row in rows array to 
            cols[col] &= mask;//turn off bit of current number in the current column in cols array to 
            boxes[numOfBox] &= mask;//turn off bit of current number in the current box in boxes array to 
        }

        /// <summary>
        /// The function get group and return its status: 0: full | 0>: missing 1 cell and returns its value | <0: missing more than 1 cell
        /// </summary>
        /// <param name="group">number that represents possability in a group</param>
        /// <returns>status of the group</returns>
        public int GetGroupStatus(int group)
        {
            int full = (int)Math.Pow(2, size) - 1;
            if (group == full)
                return 0;
            int diff = full - group;
            double powerOF2 = Math.Log(2, diff);
            if (powerOF2 % 1 == 0)
                return (int)powerOF2 + 1;
            return -1;
        }

        /// <summary>
        /// The function get bumber of box and number of cell in the box and returns its row
        /// </summary>
        /// <param name="boxNum">number of the box</param>
        /// <param name="cellNumInBox">number of cell in the box</param>
        /// <returns>row of cell</returns>
        public int GetRowBySubIndecies(int boxNum, int cellNumInBox)
        {
            int boxStartRow = subSize * (boxNum / subSize);
            int rowInBox = cellNumInBox / subSize;
            return boxStartRow + rowInBox;
        }

        /// <summary>
        /// The function get bumber of box and number of cell in the box and returns its col
        /// </summary>
        /// <param name="boxNum">number of the box</param>
        /// <param name="cellNumInBox">number of cell in the box</param>
        /// <returns>column of cell</returns>
        public int GetColBySubIndecies(int boxNum, int cellNumInBox)
        {
            int boxStartCol = subSize * (boxNum % subSize);
            int colInBox = cellNumInBox % subSize;
            return boxStartCol + colInBox;
        }


    }
}
