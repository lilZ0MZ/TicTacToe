namespace TicTacToe
{
        
    public class Board
    {
        private char[,] board = new char[3, 3];

        public Board()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize Methode initialisierst einen 2D-Array mit Leerzeichen
        /// </summary>
        private void Initialize()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }


        /// <summary>
        /// Überprüft, ob das feld besetzt ist und macht einen Spielzug
        /// </summary>
        /// <param name="player">Spieler</param>
        /// <param name="row">Reihe beim Board, um zu spielen</param>
        /// <param name="column">Spalte beim Board</param>
        /// <exception cref="InvalidOperationException">Fehlermeldung, falls Feld besetzt ist</exception>
        public void MakeMove(char player, int row, int column)
        {
            row -= 1;
            column -= 1;
            int colIndex = column;
            if (board[row, column] != ' ')
            {
                throw new InvalidOperationException("Dieses Feld ist schon besetzt!");
            }

            board[row, column] = player;
        }


        /// <summary>
        /// Zeichnet das Zeichen vom Spieler ins Spielfeld
        /// </summary>
        /// <param name="row">Reihe</param>
        /// <param name="column">Spalte</param>
        /// <returns>gibt das Zeichen vom Spieler zurück</returns>
        public char GetSymbol(int row, int column)
        {
            return board[row, column];
        }

        /// <summary>
        /// Zeichnet das Spielfeld auf der Konsole
        /// </summary>
        public void Draw()
        {
            Console.Clear();
            Console.WriteLine("    1     2     3   ");
            Console.WriteLine("1   {0}  |  {1}  |  {2} ", GetSymbol(0, 0), GetSymbol(0, 1), GetSymbol(0, 2));
            Console.WriteLine("   ----+-----+----");
            Console.WriteLine("2   {0}  |  {1}  |  {2} ", GetSymbol(1, 0), GetSymbol(1, 1), GetSymbol(1, 2));
            Console.WriteLine("   ----+-----+----");
            Console.WriteLine("3   {0}  |  {1}  |  {2} ", GetSymbol(2, 0), GetSymbol(2, 1), GetSymbol(2, 2));
        }

        /// <summary>
        /// Überprüft, ob es einen Gewinner gibt mit Gewinnkombinationen
        /// </summary>
        /// <returns>Falls es einen Gewinner gibt ist es "true" zurück, falls nicht dann "false"</returns>
        public bool HasWinner()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }

            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// Überprüft, ob es einen Gewinner gibt oder, ob alle Felder besetzt sind
        /// </summary>
        /// <returns>Wenn das Spiel vorbei ist, gibt die Methode "true" zurück, andernfalls "false"</returns>
        public bool IsGameOver()
        {
            if (HasWinner())
            {
                return true;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}