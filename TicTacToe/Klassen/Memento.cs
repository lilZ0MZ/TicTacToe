using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    public class Memento
    {
        public char[,] BoardState { get; }

        public Memento(char[,] boardState)
        {
            BoardState = (char[,])boardState.Clone();
        }
    }
}

