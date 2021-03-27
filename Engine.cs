using BattleshipEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine
{
    public class Engine
    {
        private List<Player> Players;

        public Engine()
        {
            TestDisplay();
        }

        public List<Board> StartGame(int rows = 8, int columns = 8, int numOfPlayers = 1)
        {
            Players = GeneratePlayers(numOfPlayers, rows, columns);
            return Players.Select(p => p.Board).ToList();
        }

        private static List<Player> GeneratePlayers(int numOfPlayers, int rows, int columns)
        {
            var players = new List<Player>();
            for (int i = 0; i < numOfPlayers; i++)
            {
                players.Add(new Player(rows, columns, i + 1));
            }
            return players;
        }

        private void TestDisplay()
        {
            var b = StartGame();
            foreach (var board in b)
            {
                var shipCoords = board.Ships.SelectMany(s => s.Coords);
                for (int row = 0; row < board.Rows; row++)
                {
                    for (int col = 0; col < board.Columns; col++)
                    {
                        if (shipCoords.Contains((col, row)))
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write("0");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}