using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
  
        public class Game
        {
            private Board board;
            private char currentPlayer;

            public Game()
            {
                board = new Board();
                currentPlayer = 'X';
            }

            public void Play()
            {
                board.Draw();

                while (!board.IsGameOver())
                {
                    try
                    {
                        MakeMove();
                        currentPlayer = currentPlayer == 'X' ? 'O' : 'X'; // switch player
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            private void MakeMove()
            {
                Console.WriteLine($"Player {currentPlayer}, it's your turn.");

                bool validMove = false;
                do
                {
                    Console.Write("Enter the row (1-3): ");
                    int row = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Enter the column (A-C): ");
                    char column = char.Parse(Console.ReadLine().ToUpper());

                    try
                    {
                        board.MakeMove(currentPlayer, row, column);
                        validMove = true;
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                } while (!validMove);

                board.Draw();
            }
        }
}
