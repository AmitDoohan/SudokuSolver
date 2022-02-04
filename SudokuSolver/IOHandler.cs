using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class IOHandler
    {
        IReadable readFormat;
        IWritable writeFormat;

        public IOHandler(IReadable readFormat, IWritable writeFormat)
        {
            this.readFormat = readFormat;
            this.writeFormat = writeFormat;
        }

        public IOHandler() { }
        public IReadable ReadFormat
        {
            get
            {
                return readFormat;
            }
            set
            {
                readFormat = value;
            }
        }
        public IWritable WriteFormat
        {
            get
            {
                return writeFormat;
            }
            set
            {
                writeFormat = value;
            }
        }
       
        /// <summary>
        ///The function read input from read-format
        /// </summary>
        /// <returns>2d array-board</returns>
        public int[,] Read()
        {
            return readFormat.Read();
        }

        /// <summary>
        ///The function gets a 2d array board writes it to write-format 
        /// </summary>
        /// <param name="output">2d array-board</param>
        public void Write(int[,] output)
        {
            writeFormat.Write(output);
        }
    }
}
