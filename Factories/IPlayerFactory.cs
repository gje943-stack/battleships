using BattleshipEngine.Models;
using System.Collections.Generic;

namespace BattleshipEngine.Factories
{
    public interface IPlayerFactory
    {
        List<IPlayer> CreatePlayers(int numOfPlayers, int cols, int rows);
    }
}