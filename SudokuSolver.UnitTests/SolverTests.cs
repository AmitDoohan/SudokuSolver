using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SudokuSolver.UnitTests
{
    [TestClass]
    public class SolverTests
    {
        //-----------E m p t y  b o a r d s-----------

        [TestMethod]
        public void SolveBackTracking_Empty1X1Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "0";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        }

        [TestMethod]
        public void SolveBackTracking_Empty4X4Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "0000000000000000";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        } 
        
        [TestMethod]
        public void SolveBackTracking_Empty9X9Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        } 
        
        [TestMethod]
        public void SolveBackTracking_Empty16X16Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        }

        [TestMethod]
        public void SolveBackTracking_Empty25X25Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        }

        //-----------F u l l  b o a r d s-----------

        [TestMethod]
        public void SolveBackTracking_Full1X1Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "0";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        }

        [TestMethod]
        public void SolveBackTracking_Full4X4Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "1234432131422413";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        }  
        
        [TestMethod]
        public void SolveBackTracking_Full9X9Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "915876234364952871827134695732485916148693752596721348659217483273548169481369527";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        } 
        
        [TestMethod]
        public void SolveBackTracking_Full16X16Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "951=>3;:27<84@6?@?;:7=965431><822><68541@?:9=;377843?<2@6;>=1:59;19>56=<4@7:?328436@:>72?=8;<9155=:7@9?81<23;>468<?2143;965>7=@:36>42?<7=1;598:@:;7<6@13>89254?=?2=54;897:@631><1@89=:>5<3?4267;=931<2:48567@?;><:5;98@>324?67=167@8315?;>=<:294>42?;76=:91@85<3";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        }

        //-----------P a r t l y  F i l l e d  b o a r d s-----------

        [TestMethod]
        public void SolveBackTracking_PartlyFilled4X4Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "1200000000000013";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        } 
        
        [TestMethod]
        public void SolveBackTracking_PartlyFilled9X9Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "000000317500000000001900000012600074600000030000000005000006000024350760080010400";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        }

        [TestMethod]
        public void SolveBackTracking_PartlyFilled9X9BoardSecond_ReturnsTrue()
        {
            //Arrange:
            string board_string = "036009500204018300057300900005000000972000000000000070000050003500030000703000056";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        }

        [TestMethod]
        public void SolveBackTracking_PartlyFilled16X16Board_ReturnsTrue()
        {
            //Arrange:
            string board_string = "000=000000000000000000000000000220<00000000000007000?00060001000000>00000000030000000>000000<900000000000000000600000000000000@000>00000000000000000600000000000000000000006000000000000<3000600=0000000000000;0000000@0020000000000000?000000000000000000100000";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsTrue(result);
            //Check if board is correct by sending it to constructor
            Board resultBoard = new Board(board.SudokuBoard);
        }

        //-----------U n s o l v a b l e  b o a r d s-----------

        [TestMethod]
        public void SolveBackTracking_PartlyFilled4X4Board_ReturnsFalse()
        {
            //Arrange:
            string board_string = "0024000002030400";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsFalse(result);
        }  
        
        [TestMethod]
        public void SolveBackTracking_PartlyFilled9X9Board_ReturnsFalse()
        {
            //Arrange:
            string board_string = "100000000000100000000000005000000100000000000000000000000000000000000010000000000";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SolveBackTracking_PartlyFilled16X16Board_ReturnsFalse()
        {
            //Arrange:
            string board_string = "102300;680054<00>00;08:0<09007000<00000002700?090090070000:0>85;0:0@1002;40600080300000900000000;942050>00=030000000008@3920040000100:?39600000000060900@0<02;4>00000000200000102000@0>8100=<06054?10>0000600@0060@00250000000<000<00@0:0710=00400:>?00;43000501";
            int[,] board_matrix = ConvertInput.ConvertStringToMatrix(board_string);
            Board board = new Board(board_matrix);

            //Act:
            bool result = Solver.SolveBackTracking(board);

            //Assert:
            Assert.IsFalse(result);
        }

    }
}
