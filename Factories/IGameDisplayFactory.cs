using BattleshipEngine.Models;
using BattleshipEngine.Services;
using System.Collections.Generic;

namespace BattleshipEngine.Factories
{
    public interface IGameDisplayFactory
    {
        IGameDisplay CreateDisplay(List<IPlayer> players, int idOfPlayerWhoMadeShot = 0);
    }
}