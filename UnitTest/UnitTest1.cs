using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToe.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitializeBoardTest()
        {
            var board = new Board();


            char[,] expectedBoard = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            CollectionAssert.AreEqual(expectedBoard, board.board);
        }

        [TestMethod]
        public void MakeMoveTest()
        {
            var board = new Board();

            board.MakeMove('X', 1, 1);  // 'X' welcher Spieler und 1, 1 für Feldeingabe
            char[,] expectedBoard = { { 'X', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            CollectionAssert.AreEqual(expectedBoard, board.board);

            board.MakeMove('X', 1, 1);
            board.MakeMove('O', 1, 1);
            Console.WriteLine("Field is already possesed by the other player. Please choose an other field.")
        }

        [TestMethod]
        public void HasWinnerTest()
        {
            // Vertikaler Check

            var board = new Board();
            
            board.MakeMove('X', 1, 1);
            board.MakeMove('X', 2, 1);
            board.MakeMove('X', 3, 1);

            bool hasWinner = board.HasWinner();

            Assert.IsTrue(hasWinner);

            // Diagonaler Check

            var board = new Board();

            board.MakeMove('X', 1, 1);
            board.MakeMove('X', 2, 2);
            board.MakeMove('X', 3, 3);

            bool hasWinner = board.HasWinner();

            Assert.IsTrue(hasWinner);


            // Horizontaler Check

            var board = new Board();

            board.MakeMove('X', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('X', 1, 3);

            bool hasWinner = board.HasWinner();

            Assert.IsTrue(hasWinner);
        }

        [TestMethod]
        public void IsGameOverTest()
        {
            var board = new Board();

            board.MakeMove('X', 1, 1);
            board.MakeMove('X', 2, 1);
            board.MakeMove('X', 3, 1);

            bool isGameOver = board.IsGameOver();

            Assert.IsTrue(isGameOver);
        }

        [TestMethod]
        public void IsGameTieTest()
        {
            var board = new Board();

            board.MakeMove('X', 1, 1);
            board.MakeMove('O', 1, 2);
            board.MakeMove('X', 1, 3);
            board.MakeMove('O', 2, 1);
            board.MakeMove('X', 2, 2);
            board.MakeMove('O', 2, 3);
            board.MakeMove('O', 3, 1);
            board.MakeMove('X', 3, 2);
            board.MakeMove('O', 3, 3);

            bool isGameTie = board.IsGameOver();

            Assert.IsTrue(isGameTie);
        }


    }
}
