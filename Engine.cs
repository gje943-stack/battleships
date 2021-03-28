using BattleshipEngine.Factories;
using BattleshipEngine.Models;
using BattleshipEngine.Providers;
using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine
{
    public class Engine : IEngine
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IBoardProvider _boardProvider;
        private List<IPlayer> Players;

        public Engine(IPlayerProvider playerProvider, IBoardProvider boardProvider)
        {
            _playerProvider = playerProvider;
            _boardProvider = boardProvider;
            startGame();
        }

        public void startGame(int cols = 8, int rows = 8, int numOfPlayers = 6)
        {
            Players = _playerProvider.CreatePlayers(numOfPlayers);
            foreach (var player in Players)
            {
                player.Board = _boardProvider.CreateBoard(cols, rows);
            }
            Console.ReadLine();
        }
    }
}