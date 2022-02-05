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
            char ch;
            input = input.Replace(" ", "");
            int size = IsInputValid(input);
            if(size<1)
                throw new InputInvalidException($"Invalid input. Input is empty.");

            int[,] board = new int[size, size];

            for (int i = 0; i < input.Length; i++)
            {
                ch = input[i];
                if (!(ch >= '0' && (ch <= ('0' + size))))
                    throw new InputInvalidException($"Invalid input. Input contains invalid character: {ch}.");
                board[i / size, i % size] = (ch - '0');
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
                throw new InputInvalidException($"Invalid input. Input size is invalid.");
            int wholeSize = (int)Math.Sqrt(size);
            if (Math.Sqrt(wholeSize) % 1 != 0)
                throw new InputInvalidException($"Invalid input. Input size is invalid.");
            return wholeSize;
        }
    }
}
