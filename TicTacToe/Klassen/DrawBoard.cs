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

    public bool IsGameOver()
    {
        return false;
    }

    public void MakeMove(char player, int row, char column)
    {
        int colIndex = column - 'A';
        if (board[row, colIndex] != ' ')
        {
            throw new InvalidOperationException("That space is already occupied.");
        }

        board[row, colIndex] = player;
    }

    public char GetSymbol(int row, int column)
    {
        return board[row, column];
    }

    public void Draw()
    {
        Console.Clear();
        Console.WriteLine("    A     B     C   ");
        Console.WriteLine("1   {0}  |  {1}  |  {2} ", GetSymbol(0, 0), GetSymbol(0, 1), GetSymbol(0, 2));
        Console.WriteLine("  ----+----+----");
        Console.WriteLine("2   {0}  |  {1}  |  {2} ", GetSymbol(1, 0), GetSymbol(1, 1), GetSymbol(1, 2));
        Console.WriteLine("  ----+----+----");
        Console.WriteLine("3   {0}  |  {1}  |  {2} ", GetSymbol(2, 0), GetSymbol(2, 1), GetSymbol(2, 2));
    }
}