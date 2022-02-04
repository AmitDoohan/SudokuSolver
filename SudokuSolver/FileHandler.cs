using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace SudokuSolver
{
    public class FileHandler : IReadable, IWritable
    {
        private string fileName;

        public FileHandler(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// The function gets file name+path and return the name of a new file
        /// The structure is: path + filenape + "-Solved"
        /// </summary>
        /// <returns>returns the new name</returns>
        private string GetNewFileName()
        {
            int length = fileName.Length;
            string fileNameNoExtension = fileName.Substring(0, length - 4);
            fileNameNoExtension += "-Solved" + fileName.Substring(length - 4);
            return fileNameNoExtension;
        }

        /// <summary>
        /// This function reads input (string that represents a board) from a file.
        /// </summary>
        /// <returns>Returns matrix (2d array) of the board.</returns>
        public int[,] Read()
        {
            string input = ""; char ch;
            StreamReader reader;
            reader = new StreamReader(fileName);
            do
            {
                ch = (char)reader.Read();
                input += ch;
            } while (!reader.EndOfStream);
            reader.Close();
            reader.Dispose();
            int[,] board = ConvertInput.ConvertStringToMatrix(input);
            return board;
        }

        /// <summary>
        /// This function get matrix of board and write it to a new file.
        /// </summary>
        /// <param name="resultBoard">int[,] 2d array</param>
        /// <returns></returns>
        public void Write(int[,] board)
        {
            string newFileName = GetNewFileName();
            int size = board.GetLength(0);
            int numberOfCells = size * size;
            string result = "";
            for (int i = 0; i < numberOfCells; i++)
                result += (char)(board[i / size, i % size] + '0');
            File.WriteAllText(newFileName, result);
        }
    }
}
