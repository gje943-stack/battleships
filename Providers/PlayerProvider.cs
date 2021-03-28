using BattleshipEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Providers
{
    public class PlayerProvider : IPlayerProvider
    {
        public List<IPlayer> CreatePlayers(int numOfPlayers)
        {
            var players = new List<IPlayer>();
            for (int i = 0; i < numOfPlayers; i++)
            {
                players.Add(new Player(i));
            }
            return players;
        }
    }
}