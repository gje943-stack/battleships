
using System.Linq;

namespace BattleshipEngine.Models
{
    public class Player : IPlayer
    {
        public IPlayerStats Stats { get; private set; }
        public Player(int playerId, IPlayerStats stats)
        {
            PlayerId = playerId;
            Stats = stats;
        }

        public IBoard Board { get; set; }

        public int PlayerId { get; init; }

        public void TakeShot((int col, int row) targetCoord)
        {
            var shipCoords = Board.Ships.SelectMany(s => s.Position.Keys);
            Stats.NumOfTurns += 1;
            if (shipCoords.Contains(targetCoord))
            {
                Board.Coords[targetCoord] = CoordStatus.Hit;
                Stats.ShotResults.Add(ShotResult.Hit);
                HitShip(targetCoord);
            }
            else
            {
                Board.Coords[targetCoord] = CoordStatus.Missed;
                Stats.ShotResults.Add(ShotResult.Miss);
            }
        }

        public void HitShip((int, int) targetCoord)
        {
            var shipToHit = Board.Ships.Find(s => s.Position.ContainsKey(targetCoord));
            shipToHit.Position[targetCoord] = ShipStatus.Hit;
            if (shipToHit.IsSunk())
            {
                Stats.ShipsDestroyed += 1;
            } 
        }
    }
}