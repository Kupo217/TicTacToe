using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Nika");
            Player player2 = new Player("Tatiana");
            Board board = new Board(player1, player2);

            Console.WriteLine("Welcome to Tic Tac Toe\n");

            board.StartGame();
            
            Console.ReadKey();
        }
    }
}
