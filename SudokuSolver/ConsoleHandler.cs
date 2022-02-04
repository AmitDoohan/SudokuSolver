using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    public class ConsoleHandler : IReadable, IWritable
    {
        public ConsoleHandler() { }

        /// <summary>
        /// This function reads input (string that represents a board) from console.
        /// </summary>
        /// <returns>Returns matrix (2d array) of the board.</returns>
        public int[,] Read()
        {
            //Get string input from console
            Console.SetIn(new System.IO.StreamReader(Console.OpenStandardInput(8192)));
            string input = Console.ReadLine();
            int[,] board = ConvertInput.ConvertStringToMatrix(input);
            return board;
        }
        
        /// <summary>
        /// This function get matrix of board and print it to console.
        /// </summary>
        /// <param name="resultBoard">int[,] 2d array</param>
        /// <returns></returns>
        public void Write(int[,] board)
        {
            int size = board.GetLength(0);
            int subSize = (int)Math.Sqrt(size);
            int numberofcells = size * size;
            int square;
            Console.Write(" ");

            //creating +---+---+---+
            string lineSeperator = "";
            for (int i = 0; i < size; i++)
                lineSeperator += "+-----";
            lineSeperator += "+";

            Console.Write("\n");
            for (int i = 0; i < size; i++)
            {
                if (i % subSize == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(lineSeperator);
                Console.ResetColor();
                for (int j = 0; j < size; j++)
                {
                    int x = board[i, j];
                    char val = (char)(x + '0');
                    if (j % subSize == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|");
                        Console.ResetColor();
                        Console.Write($"  {val}  ");
                    }
                    else
                        Console.Write($"|  {val}  ");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|\n");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(lineSeperator);
            Console.ResetColor();
        }
    }
}
