using BattleshipEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Services
{
    public class GameDisplay : IGameDisplay
    {
        public List<List<List<string>>> Boards { get; set; } = new();
        public int ShipsLeft { get; set; }
        public ShotResult? Result { get; set; }
    }
}
