using System.Collections.Generic;

namespace BattleshipEngine.Models
{
    public interface IPlayerStats
    {
        int NumOfTurns { get; set; }
        List<ShotResult> ShotResults { get; set; }
        int ShipsDestroyed { get; set; }
    }
}