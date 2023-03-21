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
        public char currentPlayer;

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
                if (board.HasWinner())
                {
                    Console.Clear();
                    Console.WriteLine($"Player {currentPlayer} wins!");
                        
                }
                else
                {
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X'; // switch player
                }
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
                //int row = int.Parse(Console.ReadLine()) - 1;
                //int row = Console.Read();
                int row = GetMove("row");
                int column = GetMove("column");

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

        public int GetMove(string type)
        {
            int number;
            do
            {
                Console.Write($"Enter the {type} (1-3): ");
                string input = Console.ReadLine();
                int.TryParse(input, out number);
            } while (number < 1 || number > 3);
            return number;
        }
    }
}
