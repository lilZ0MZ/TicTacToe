namespace TicTacToe
{

    public class Board
    {
        private char[,] board = new char[3, 3];

        public Board()
        {
            Initialize();
        }

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



        public void MakeMove(char player, int row, int column)
        {
            row -= 1;
            column -= 1;
            int colIndex = column;
            if (board[row, column] != ' ')
            {
                throw new InvalidOperationException("That space is already occupied.");
            }

            board[row, column] = player;
        }

        public char GetSymbol(int row, int column)
        {
            return board[row, column];
        }

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