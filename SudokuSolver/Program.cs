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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n");
            Console.WriteLine("   .oooooo..o  ooooo     ooo  oooooooooo.      .oooooo    .oooo    oooo  ooooo     ooo" + "\n" +
                              "  d8P'    `Y8  `888'     `8'  `888'   `Y8b    d8P'  `Y8b   `888   .8P'   `888'     `8'" + "\n" +
                              "  Y88bo.        888       8    888      888  888      888   888  d8'      888       8 " + "\n" +
                              "   `\"Y8888o.    888       8    888      888  888      888   88888[        888       8 " + "\n" +
                              "       `\"Y88b   888       8    888      888  888      888   888`88b.      888       8 " + "\n" +
                              "       oo.d8P   `88.    .8'    888     d88'  `88b    d88'   888  `88b.    `88.    .8'" + "\n" +
                              "  8\"\"88888P'      `YbodP'     o888bood8P'     `Y8bood8P'   o888o  o888o     `YbodP'");

            Console.WriteLine("\n\n---------------Welcome to sudoku solver---------------\n");
            Console.ResetColor();
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
                    Board b = new Board(board);
                    DateTime start = DateTime.Now;
                    bool success = Solver.SolveBackTracking(b);
                    DateTime end = DateTime.Now;
                    Console.WriteLine("Time: " + end.Subtract(start));
                    if (success)
                        handler.Write(b.SudokuBoard);
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Board is ubsolvable");
                        Console.ResetColor();
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
