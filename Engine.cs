using BattleshipEngine.Exceptions;
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
        public IGameDisplay test { get; set; }

        public List<IPlayer> Players { get; private set; }

        public Engine(IPlayerFactory playerFactory, IGameDisplayFactory gameDisplayFac)
        {
            _playerFactory = playerFactory;
            _gameDisplayFac = gameDisplayFac;
        }

        public IGameDisplay StartGame(int cols = 8, int rows = 8, int numOfPlayers = 2)
        {
            if(numOfPlayers < 0 || numOfPlayers > 2)
            {
                throw new InvalidNumberOfPlayersException(numOfPlayers);
            }
            Players = _playerFactory.CreatePlayers(numOfPlayers, cols, rows);
            return _gameDisplayFac.CreateDisplay(Players);
        }

        public IGameDisplay Shoot(int shotColumn, int shotRow, int playerId)
        {
            if(playerId > Players.Count || playerId < 0)
            {
                throw new InvalidPlayerIdException();
            }
            Players.Find(p => p.PlayerId == playerId)
                .TakeShot((shotColumn, shotRow));
            return _gameDisplayFac.CreateDisplay(Players, playerId);
        }

        public bool GameIsOver()
        {
            return Players.Any(p => p.Stats.ShipsDestroyed == p.Board.Ships.Count);
        }

        public int FindWinningPlayer()
        {
            return Players.Find(p => p.Stats.ShipsDestroyed == p.Board.Ships.Count).PlayerId;
        }
    }
}