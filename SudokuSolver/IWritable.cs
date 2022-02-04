using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    public interface IWritable
    {
        void Write(int[,] board);
    }
}
