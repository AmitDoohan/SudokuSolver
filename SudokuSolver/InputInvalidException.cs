using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class InputInvalidException :Exception
    {
        public InputInvalidException() { }

        public InputInvalidException(string message)
            : base(message) { }
    }
}
