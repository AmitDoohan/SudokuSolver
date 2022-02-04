using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public static class ConvertInput
    {
        /// <summary>
        /// This function gets string that represents a board and convert it to am matrix
        /// </summary>
        /// <param name="input">string-board</param>
        /// <returns>Returns 2d array-board</returns>
        public static int[,] ConvertStringToMatrix(string input)
        {
            int size = IsInputValid(input), counter = 0;
            char ch;
            input = input.Replace(" ", "");
            int[,] board = new int[size, size];

            for (int i = 0; i < input.Length; i++)
            {
                ch = input[i];
                if (!(ch >= '0' && (ch <= ('0' + size))))
                    return null; 
                board[i / size, i % size] = (ch - '0');
               // i++;
            }
            return board;
        }

        /// <summary>
        /// The function gets string that represents board and checks whether is valid.
        /// If it's valid- return the size of the board(meaning hight).
        /// Otherwise- throws InputInvalidException.
        /// </summary>
        /// <param name="input">string-board</param>
        /// <returns>size of the board</returns>
        public static int IsInputValid(string input)
        {
            input = input.Replace(" ", "");
            int size = input.Length;

            if (Math.Sqrt(size) % 1 != 0)
                return 0;
            int wholeSize = (int)Math.Sqrt(size);
            if (Math.Sqrt(wholeSize) % 1 != 0)
                return 0;
            return wholeSize;
        }
    }
}
