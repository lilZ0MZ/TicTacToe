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
            while (!board.IsGameOver())
            {
                board.Draw();
                try
                {
                    MakeMove();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            board.Draw();
            DrawWinner();
            HandleInput();
        }
        
        public void UndoMove()
        {
            if (mementoStack.Count > 0)
            {
                Memento memento = mementoStack.Pop();
                board.BoardState = memento.BoardState;
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }

        public void HandleInput()
        {
            while (true)
            {
                Console.Write("Enter a command (new or end): ");
                string input = Console.ReadLine().ToLower();

                if (input == "new")
                {
                    board = new Board();
                    currentPlayer = 'X';
                    Play();
                }
                else if (input == "end")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid command. Please try again.");
                }
            }
        }

        private void DrawWinner()
        {
            if (board.HasWinner())
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                Console.WriteLine($"Player {currentPlayer} wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }

        private void MakeMove()
        {
            Console.WriteLine($"Player {currentPlayer}, it's your turn.");

            bool validMove = false;
            do
            {
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

            currentPlayer = currentPlayer == 'X' ? 'O' : 'X'; 
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
