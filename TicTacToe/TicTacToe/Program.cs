namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];

        static void Main(string[] args)
        {
            DrawBoard();
        }
        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("   A    B    C   ");
            Console.WriteLine("1   {0}  |  {1}  |  {2} ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("  ----+----+----");
            Console.WriteLine("2   {0}  |  {1}  |  {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("  ----+----+----");
            Console.WriteLine("3   {0}  |  {1}  |  {2} ", board[2, 0], board[2, 1], board[2, 2]);
        }
    }
}