using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SudokuSolver.UnitTests
{
    [TestClass]
    public class ConvertInputTests
    {
        //-----------i n v a l i d  s t r i n g s-----------

        [TestMethod]
        public void ConvertStringToMatrix_InvalidCharacterInString1x1_ThrowsInputInvalidException()
        {
            //Arrange:
            string board_string = "3";

            //Act + Assert:
            Assert.ThrowsException<InputInvalidException>(() => ConvertInput.ConvertStringToMatrix(board_string));
        }

        [TestMethod]
        public void ConvertStringToMatrix_InvalidCharacterInString4x4_ThrowsInputInvalidException()
        {
            //Arrange:
            string board_string = "123451234123412";

            //Act + Assert:
            Assert.ThrowsException<InputInvalidException>(() => ConvertInput.ConvertStringToMatrix(board_string));
        }

        [TestMethod]
        public void ConvertStringToMatrix_InvalidCharacterInString9x9_ThrowsInputInvalidException()
        {
            //Arrange:
            string board_string = "91587623436495287;827134695732=85916148693752596721348659217483273548169481369527";

            //Act + Assert:
            Assert.ThrowsException<InputInvalidException>(() => ConvertInput.ConvertStringToMatrix(board_string));
        }

        [TestMethod]
        public void ConvertStringToMatrix_EmptyString_ThrowsInputInvalidException()
        {
            //Arrange:
            string board_string = "";

            //Act + Assert:
            Assert.ThrowsException<InputInvalidException>(() => ConvertInput.ConvertStringToMatrix(board_string));
        }

        //-----------i n v a l i d  s i z e-----------

        [TestMethod]
        public void IsInputValid_InvalidSizeOfString_ThrowsInputInvalidException()
        {
            //Arrange:
            string board_string = "123";

            //Act + Assert:
            Assert.ThrowsException<InputInvalidException>(() => ConvertInput.IsInputValid(board_string));
        }        

        //-----------v a l i d  s i z e-----------

        [TestMethod]
        public void IsInputValid_1x1ValidSizeBoardString_ReturnsSize()
        {
            //Arrange:
            string board_string = "                8                ";

            //Act:
            int size = ConvertInput.IsInputValid(board_string);

            //Assert:
            Assert.AreEqual(size, 1);
        }

        [TestMethod]
        public void IsInputValid_4x4ValidSizeBoardString_ReturnsSize()
        {
            //Arrange:
            string board_string = "1234 0000 4000 0000 ";

            //Act:
            int size = ConvertInput.IsInputValid(board_string);

            //Assert:
            Assert.AreEqual(size, 4);
        }

        [TestMethod]
        public void IsInputValid_9x9ValidSizeBoardString_ReturnsSize()
        {
            //Arrange: 
            string board_string = "     000000000000 00000000000000000000 00000000000000000    000000 00000000000 000000000000000";

            //Act:
            int size = ConvertInput.IsInputValid(board_string);

            //Assert:
            Assert.AreEqual(size, 9);
        }

        [TestMethod]
        public void IsInputValid_16x16ValidSizeBoardString_ReturnsSize()
        {
            //Arrange:
            string board_string = " 000000000  00 00000 0000 0000 000000000000 000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 00 0000 00000000000 0000000 0000000000000000000000000000000000000000000000000000000000000000";

            //Act:
            int size = ConvertInput.IsInputValid(board_string);

            //Assert:
            Assert.AreEqual(size, 16);
        }
    }
}
