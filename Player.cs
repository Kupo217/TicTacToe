using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public string Name { get; private set; }
        public int Score { get; set; } = 0;
     
        public Player(string name)
        {
            Name = name;
        }

    }
}
