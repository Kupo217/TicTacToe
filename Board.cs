using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        private char[,] _elements = new char[3, 3];
        private int _turns = 1;
        private List<Player> _players = new List<Player>();
        private bool GameOver = false;

        public Board(Player player1, Player player2)
        {
            for (int i = 0; i < _elements.GetLength(0); i++) 
            {
                for (int j = 0; j < _elements.GetLength(1); j++)
                {
                    _elements[i, j] = ' ';
                }
            }

            _players.Add(player1);
            _players.Add(player2);
        }


        public void StartGame()
        {
            Console.WriteLine($"For `X` will be playing {_players.First().Name} and for `O` will be playing {_players.Last().Name}");
            Console.WriteLine();
            DrawBoard();
            while (GameOver == false)
            {
                MakeDecision();
                CheckGameStatus();
            }
            Console.WriteLine();
            Console.WriteLine($"{_players.First().Name}:{_players.First().Score}");
            Console.WriteLine($"{_players.Last().Name}:{_players.Last().Score}");
            Console.WriteLine();

            Rematch();
        }

        private void Rematch()
        {

            Console.Write("Want a Rematch? (y, n): ");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                GameOver = false;
                _turns = 1;
                for (int i = 0; i < _elements.GetLength(0); i++)
                {
                    for (int j = 0; j < _elements.GetLength(1); j++)
                    {
                        _elements[i, j] = ' ';
                    }
                }
                Console.Clear();
                StartGame();
            }
            else
            {
                string finalScore = $"{_players.First().Name}:{_players.First().Score}\n{_players.Last().Name}:{_players.Last().Score}\n";
                finalScore += "-----------------\n";
                File.AppendAllText(@"C:\Users\Nika\source\repos\TicTacToe\Score.txt", finalScore);
            }
        }

        private void DrawBoard()
        {

            if (_turns % 2 == 0 && GameOver == false)
                Console.WriteLine("Now is `O`'s turn!");
            else if (_turns % 2 == 1 && GameOver == false)
                Console.WriteLine("Now is `X`'s turn!");

            for (int i = 0; i < _elements.GetLength(0); i++)
            {
                for (int j = 0; j < _elements.GetLength(1); j++)
                {
                    if (j != 2)
                        Console.Write($"{_elements[i, j]} |");
                    else
                        Console.WriteLine(_elements[i, j]);
                }
                if (i != 2)
                    Console.WriteLine("--+--+--");
            }

        }

        private void MakeDecision()
        {
            Console.Write("Enter row (0, 1, 2): ");
            string playerRow = Console.ReadLine();

            Console.Write("Enter column (0, 1, 2): ");
            string playerCol = Console.ReadLine();

            try
            {
                int row = int.Parse(playerRow);
                if (row > 2 || row < 0)
                    throw new InvalidInputException("Enter valid value for row!");

                int col = int.Parse(playerCol);
                if (col > 2 || col < 0)
                    throw new InvalidInputException("Enter valid value for column!");
                
                if (_elements[row, col] != ' ')
                    throw new InvalidInputException("This spot is already taken!");

                if (_turns % 2 == 0)
                {
                    _elements[row, col] = 'O';
                    _turns++;
                }
                else
                {
                    _elements[row, col] = 'X';
                    _turns++;
                }

                Console.Clear();
                DrawBoard();
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void CheckGameStatus()
        {

            if (_turns > 9)
            {
                Console.WriteLine("It is a Draw!");
                GameOver = true;
            }

            // Rows
            for (int i = 0; i < 3; i++)
            {
                if (_elements[0, i] == _elements[1, i] && _elements[1, i] == _elements[2, i] && _elements[0, i] != ' ')
                {
                    if (_turns % 2 == 0)
                    {
                        Console.WriteLine($"Player {_players.First().Name} wins!");
                        _players.First().Score++;
                    }
                    else
                    {
                        Console.WriteLine($"Player {_players.Last().Name} wins!");
                        _players.Last().Score++;
                    }
                    GameOver = true;
                }   
            }

            // Cols
            for (int i = 0; i < 3; i++)
            {
                if (_elements[i, 0] == _elements[i, 1] && _elements[i, 1] == _elements[i, 2] && _elements[i, 0] != ' ')
                {
                    if (_turns % 2 == 0)
                    {
                        Console.WriteLine($"Player {_players.First().Name} wins!");
                        _players.First().Score++;
                    }
                    else
                    {
                        Console.WriteLine($"Player {_players.Last().Name} wins!");
                        _players.Last().Score++;
                    }
                    GameOver = true;
                }
            }

            // Diagonals
            if (_elements[0, 0] == _elements[1, 1] && _elements[1, 1] == _elements[2, 2] && _elements[0, 0] != ' ')
            {
                if (_turns % 2 == 0)
                {
                    Console.WriteLine($"Player {_players.First().Name} wins!");
                    _players.First().Score++;
                }
                else
                {
                    Console.WriteLine($"Player {_players.Last().Name} wins!");
                    _players.Last().Score++;
                }
                GameOver = true;
            }

            if (_elements[0, 2] == _elements[1, 1] && _elements[1, 1] == _elements[2, 0] && _elements[0, 2] != ' ')
            {
                if (_turns % 2 == 0)
                {
                    Console.WriteLine($"Player {_players.First().Name} wins!");
                    _players.First().Score++;
                }
                else
                {
                    Console.WriteLine($"Player {_players.Last().Name} wins!");
                    _players.Last().Score++;
                }
                GameOver = true;
            }
        }

    }
}
