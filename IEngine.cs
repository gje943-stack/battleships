using BattleshipEngine.Models;
using BattleshipEngine.Services;
using System.Collections.Generic;

namespace BattleshipEngine
{
    public interface IEngine
    {
        List<IPlayer> Players { get; }

        IGameDisplay Shoot(int shotColumn, int shotRow, int playerId);
        IGameDisplay StartGame(int cols = 8, int rows = 8, int numOfPlayers = 6);
    }
}