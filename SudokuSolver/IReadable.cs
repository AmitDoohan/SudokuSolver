using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    public interface IReadable
    {
        int[,] Read();
    }
}
