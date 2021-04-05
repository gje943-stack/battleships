using BattleshipEngine.Models;
using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IBoardFactory _boardFactory;
        private readonly IPlayerStats _stats;

        public PlayerFactory(IBoardFactory boardFactory, IPlayerStats stats)
        {
            _boardFactory = boardFactory;
            _stats = stats;
        }

        public List<IPlayer> CreatePlayers(int numOfPlayers, int cols, int rows)
        {
            var players = new List<IPlayer>();
            for (int i = 0; i < numOfPlayers; i++)
            {
                var newPlayer = new Player(i, _stats);
                newPlayer.Board = _boardFactory.CreateBoard(cols, rows);
                players.Add(newPlayer);
            }
            return players;
        }
    }
}