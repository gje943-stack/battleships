using BattleshipEngine.Factories;
using BattleshipEngine.Models;
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
        private readonly IPlayerFactory _playerFactory;
        private readonly IGameDisplayFactory _gameDisplayFac;

        public List<IPlayer> Players { get; private set; }

        public Engine(IPlayerFactory playerFactory, IGameDisplayFactory gameDisplayFac)
        {
            _playerFactory = playerFactory;
            _gameDisplayFac = gameDisplayFac;
        }

        public IGameDisplay StartGame(int cols = 8, int rows = 8, int numOfPlayers = 6)
        {
            Players = _playerFactory.CreatePlayers(numOfPlayers, cols, rows);
            return _gameDisplayFac.CreateDisplay(Players);
        }

        public IGameDisplay Shoot(int shotColumn, int shotRow, int playerId)
        {
            Players.Find(p => p.PlayerId == playerId)
                .TakeShot((shotColumn, shotRow));
            return _gameDisplayFac.CreateDisplay(Players, playerId);
        }
    }
}