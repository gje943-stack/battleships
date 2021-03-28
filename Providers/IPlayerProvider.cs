using BattleshipEngine.Models;
using System.Collections.Generic;

namespace BattleshipEngine.Providers
{
    public interface IPlayerProvider
    {
        List<IPlayer> CreatePlayers(int numOfPlayers);
    }
}