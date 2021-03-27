using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public enum Direction
    {
        Vertical, Horizontal
    }

    public abstract class Ship
    {
        public virtual Direction Direction { get; init; } = ShipPositioner.DetermineShipDirection();

        public abstract int Length { get; init; }

        public abstract (int col, int row)[] Coords { get; set; }

        public abstract bool IsDestroyed { get; set; }
    }
}