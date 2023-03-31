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
            // Dieser Test schaut ob das Board richtig Initialisiert wurde
            var board = new Board();

            char[,] expectedBoard = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            CollectionAssert.AreEqual(expectedBoard, board.board);
        }

        [TestMethod]
        public void MakeMoveTest()
        {
            // Dieser Test Macht einen Spielzug und schaut stimmt dieser Spielzug überein
            var board = new Board();

            board.MakeMove('X', 1, 1);  // 'X' welcher Spieler und 1, 1 für Feldeingabe
            char[,] expectedBoard = { { 'X', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            CollectionAssert.AreEqual(expectedBoard, board.board);

            // Hier wird geschaut, ob ein Feld schon belegt ist.

            board.MakeMove('X', 1, 1);
            board.MakeMove('O', 1, 1);
            Console.WriteLine("Feld ist bereits besetzt.")
        }

        [TestMethod]
        public void HasWinnerTest()
        {
            // Bei diesem Test wird überprüft wann es einen Gewinner geben kann.

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
            // In diesem Test schauen wir, ob ein Spiel auch beendet ist
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
            // In diesem Test schauen wir, ob das Spiel unentschieden ausgegangen ist.

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

            bool isGameTie = board.DrawWinner();

            Assert.IsTrue(isGameTie);
        }
    }
}
