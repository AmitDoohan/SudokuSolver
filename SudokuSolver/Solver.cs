using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SudokuSolver
{
    public static class Solver
    {
        /// <summary>
        /// Stack that contains all indicies of cells that has been changed (guesess)
        /// </summary>
        private static Stack<int> indeciesStack = new Stack<int>();
      
        /// <summary>
        /// The function gets a board and tries to solve it with human tactics.
        /// </summary>
        /// <param name="board">board</param>
        /// <returns>return number of cells changed</returns>
        public static int SolveWithHumanTactics(Board board)
        {
            int cellsChanged = 0;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.SudokuBoard[i, j] == 0)
                    {
                        int hidden = HumanTactics.FindHidden(board, i, j);
                        if (hidden != -1 && hidden != 0)
                        {
                            board.SudokuBoard[i, j] = hidden;
                            board.InserValue(i, j, hidden);
                            cellsChanged++;
                            indeciesStack.Push((i * 100) + j);
                            continue;
                        }
                        if (hidden == -1)
                        {
                            CleanStack(board, cellsChanged);
                            return -1;
                        }
                        int naked = HumanTactics.FindNaked(board, i, j);
                        if (naked != -1 && naked != 0)
                        {
                            board.SudokuBoard[i, j] = naked;
                            board.InserValue(i, j, naked);
                            indeciesStack.Push((i * 100) + j);
                            cellsChanged++;
                        }
                        if (naked == -1)
                        {
                            CleanStack(board, cellsChanged);
                            return -1;
                        }
                    }
                }
            }
            return cellsChanged;
        }//o(n^2)

        /// <summary>
        /// The function gets a board and finds the cell with minial number of possible values
        /// </summary>
        /// <param name="board"></param>
        /// <returns>array that contains indices of cell</returns>
        public static int[] FindMin(Board board)
        {
            int[] minSquare = { -1, -1 };
            int minCount = board.Size + 1;
            for (int i = 0; i < board.Size; i++)//total: o(n^2)
            {
                int rowStatus = board.GetGroupStatus(board.GetRow(i));//o(1)
                if (rowStatus != 0)
                    for (int j = 0; j < board.Size; j++)
                    {
                        if (board.SudokuBoard[i, j] == 0)//total: o(n)
                        {
                            int currentSquareCount = HumanTactics.CountPossible(board, i, j);//o(1)
                            if (currentSquareCount == 0)
                            {
                                minCount = currentSquareCount;
                                minSquare[0] = i;
                                minSquare[1] = j;
                                return minSquare;
                            }
                            if (currentSquareCount <= minCount)
                            {
                                minCount = currentSquareCount;
                                minSquare[0] = i;
                                minSquare[1] = j;
                            }
                        }
                    }
            }
            return minSquare;
        }//o(n^2)
     
        /// <summary>
        /// The function gets a sudoku board and tries to solve it.
        /// if succeeded- return true
        /// otherwise, board is unsolveable and return false
        /// </summary>
        /// <param name="board">board</param>
        /// <returns>bool-is solved</returns>
        public static bool SolveBackTracking(Board board)
        {
            int cellsChanged; int total = 0;
            //solving with human tactics untill there are no changes
            do
            {
                //solve naked & hidden singles, pushes to stack the indices of the cells
                cellsChanged = SolveWithHumanTactics(board);
                //if found a mistske-> this guess does not solve the board-> return false
                if (cellsChanged == -1)
                {
                    CleanStack(board, total);
                    return false;
                }
                total += cellsChanged;
            } while (cellsChanged != 0);

            //find indices of the cell with minimal options
            int[] minSquare = FindMin(board);//o(n^2)
            int r = minSquare[0], c = minSquare[1];
            //if board is full-> return true 
            if (r == -1)
                return true;

            //go over all options (1->size)
            for (int i = 1; i <= board.Size; i++)//o(n)
            {
                //if value is valid in cell
                if (board.IsValueValid(r, c, i))//o(1)
                {
                    //insert value to board and updating the arrays
                    board.SudokuBoard[r, c] = i;//o(1)
                    board.InserValue(r, c, i);//o(1)
                    //trying to solve the board in its current state
                    if (SolveBackTracking(board))
                        return true;
                    //initialize (delete) current guess
                    board.DeleteValue(r, c);//o(1)
                    board.SudokuBoard[r, c] = 0;//o(1)
                }
            }
            CleanStack(board, cellsChanged);
            //no option fits-> this guess does not solve the board-> return false 
            return false;
        }

        /// <summary>
        /// This function gets a board and number of cells to delete. 
        /// It delete all last 'cellsNum' cells in the board 
        /// (including deleting from rows,cols and boxes arrays)
        /// </summary>
        /// <param name="board">board</param>
        /// <param name="cellsNum">number of cells to delete</param>
        public static void CleanStack(Board board, int cellsNum)
        {
            for (int j = 0; j < cellsNum; j++)
            {
                int index = indeciesStack.Pop();
                int row = index / 100;
                int col = index % 100;

                //initialize (delete) the cells that has been solved with human tactics in this guess
                board.DeleteValue(row, col);//o(1)
                board.SudokuBoard[row, col] = 0;//o(1)
            }
        }

    }
}
