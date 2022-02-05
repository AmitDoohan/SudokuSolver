using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SudokuSolver.UnitTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Board_InvalidColumnInBoard_ThrowsInvalidInputException()
        {
            //Arrange:
            string board_string = "10 0000001000 00 00";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);

            //Act + Assert:
            Board board;
            Assert.ThrowsException<InputInvalidException>(() => board = new Board(board_matrix));
        }

        [TestMethod]
        public void Board_InvalidBoxInBoard_ThrowsInvalidInputException()
        {
            //Arrange:
            string board_string = "1200 0100  0000 4000";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);

            //Act + Assert:
            Board board;
            Assert.ThrowsException<InputInvalidException>(() => board = new Board(board_matrix));
        }

        [TestMethod]
        public void Board_ValidBoxInBoard_NotThrowingInvalidInputException()
        {
            //Arrange:
            string board_string = "1 200 00000000 4 000";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);

            //Act + Assert:
            Board board;
            try
            {
                board = new Board(board_matrix);
            }
            catch (InputInvalidException e)
            {
                Assert.Fail();
            }
        }
    }
}
