using BattleshipEngine.Models;
using System.Collections.Generic;

namespace BattleshipEngine.Services
{
    public interface IGameDisplay
    {
        public List<List<List<string>>> Boards { get; set; }

        public int ShipsLeft { get; set; }

        public ShotResult Result { get; set; }

    }
}