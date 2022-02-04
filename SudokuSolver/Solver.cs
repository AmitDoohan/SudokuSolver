using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SudokuSolver
{
    public static class Solver
    {
        public static bool PrintBoard(int[,] resultBoard)
        {
            int size = resultBoard.GetLength(0);
            int numberofcells = size * size;
            int square;
            Console.Write(" ");
            for (int i = 1; i <= size; i++)
            {
                Console.Write($"   {i}");
            }
            Console.Write("\n");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i + 1}");
                for (int j = 0; j < size; j++)
                //Console.Write($"   {resultBoard[i, j]}");
                {

                    int x = resultBoard[i, j];
                    char val = (char)(x + '0');
                    Console.Write($"   {val}");
                }
                Console.WriteLine("\n");
            }
            return true;
        }
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
                            return -1;
                        }
                    }
                }
            }
            return cellsChanged;
        }//o(n^2)
        
    }
}
