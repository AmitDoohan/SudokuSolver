using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SudokuSolver
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
          
            Console.WriteLine("\n\n---------------Welcome to sudoku solver---------------\n");

            while (true)
            {
                Console.WriteLine("\nYou may choose your input:\n" +
                      "\t- for console type c\n" +
                      "\t- for file type f\n" +
                      "\t- for exit type e");
                string choice, filePath = "";
                bool chosen = false;
                IOHandler handler = new IOHandler();
                do
                {
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "c":
                            Console.WriteLine("Enter board:");
                            ConsoleHandler console = new ConsoleHandler();
                            handler.ReadFormat = console;
                            handler.WriteFormat = console;
                            chosen = true;
                            break;

                        case "f":
                            //Open window for choosing file and get file path:
                            OpenFileDialog ofd = new OpenFileDialog();
                            ofd.Filter = "txt files (*.txt)|*.txt";
                            DialogResult result = ofd.ShowDialog();
                            if (result == DialogResult.OK)
                                filePath = ofd.FileName;
                            else
                            {
                                Console.WriteLine("You may choose your input:\n");
                                continue;
                            }
                            FileHandler file = new FileHandler(filePath);
                            handler.ReadFormat = file;
                            handler.WriteFormat = new ConsoleHandler();
                            handler.WriteFormat = file;
                            chosen = true;
                            break;

                        case "e":
                            //exit
                            Environment.Exit(0);
                            break;
                    }
                }
                while (!chosen);
               
                try
                {
                    int[,] board = handler.Read();
                    Board b = new Board(board, board.GetLength(0));
                    DateTime start = DateTime.Now;
                    bool success = Solver.SolveBackTracking(b);
                    DateTime end = DateTime.Now;
                    Console.WriteLine("Time: " + end.Subtract(start));
                    if (success)
                        handler.Write(b.SudokuBoard);
                    else
                    {
                        Console.WriteLine("Board ubsolveable");
                    }
                }
                catch (InputInvalidException e)
                {
                    Console.WriteLine(e.Message);

                }
            }
        }
    }
}
