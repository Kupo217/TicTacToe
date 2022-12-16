using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    internal class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) 
        {
            
        }
    }
}
