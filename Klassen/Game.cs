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

        /// <summary>
        /// Zeichnet das Spielbrett immer neu, bis das Spiel vorbei ist gibt und verwendet Methoden, die in der Klasse Game definiert sind
        /// Wenn das Spiel vorbei ist, zeichnet es das Spielbrett erneut, um den Spielstand zu zeigen
        /// </summary>
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


        /// <summary>
        /// Verarbeitet die Eingabe des Spielers, wenn das Spiel vorbei ist
        /// Wenn "neu" eingegeben wird, wird ein neues Spiel gestartet
        /// Wenn "ende" eingegeben wird, wird das Spiel beendet
        /// </summary>
        public void HandleInput()
        {
            while (true)
            {
                Console.Write("Gebe eines dieser Befehle ein (neu oder ende): ");
                string input = Console.ReadLine().ToLower();

                if (input == "neu")
                {
                    board = new Board();
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                    Play();
                }
                else if (input == "ende")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Ungültiger Befehl. Versuche es erneut.");
                }
            }
        }


        /// <summary>
        /// Ermittelt den Gewinner und gibt ihn als Nachricht aus
        /// Falls es keine Gewinnner gibt, wird ausgegeben, dass es unentschieden ist.
        /// </summary>
        private void DrawWinner()
        {
            if (board.HasWinner())
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                Console.WriteLine($"Spieler {currentPlayer} hat gewonnen!");
            }
            else
            {
                Console.WriteLine("Es ist ein Unentschieden!");
            }
        }


        /// <summary>
        /// Verarbeitet den Zug eines Spielers
        /// Wenn der Zug gültig ist, wird er auf dem Spielfeld platziert
        /// Falls es keine gültige Eingabe ist, wird eine Fehlermeldung angezeigt
        /// </summary>
        private void MakeMove()
        {
            Console.WriteLine($"Spieler {currentPlayer}, du bist dran!");

            bool validMove = false;
            do
            {
                int row = GetMove("Zeile");
                int column = GetMove("Spalte");

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

 
        /// <summary>
        /// Schleife, um eine gültige Eingabe vom Spieler zu erhalten
        /// </summary>
        /// <param name="type">"row" oder "column" vom Spielfeld</param>
        /// <returns>Die eingegebene Zahl wird zurückgegeben</returns>
        public int GetMove(string type)
        {
            int number;
            do
            {
                Console.Write($"Gebe die {type} ein (1-3): ");
                string input = Console.ReadLine();
                int.TryParse(input, out number);
            } while (number < 1 || number > 3);
            return number;
        }
    }
}
