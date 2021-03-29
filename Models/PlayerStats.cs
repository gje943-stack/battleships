using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public enum ShotResult
    {
        Hit, Miss
    }
    public class PlayerStats : IPlayerStats
    {
        public List<ShotResult> ShotResults { get; set; } = new();

        public int NumOfTurns { get; set; } = 0;

        public int ShipsDestroyed { get; set; } = 0;
    }
}
