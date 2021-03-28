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

    public interface IShip
    {
        public Direction Direction { get; init; }

        public int Length { get; init; }

        public (int col, int row)[] Position { get; init; }

        public bool IsDestroyed { get; set; }
    }
}