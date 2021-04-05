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

    public enum ShipStatus
    {
        Intact, Hit
    }

    public interface IShip
    {
        public Direction Direction { get; init; }

        public int Length { get; init; }

        public Dictionary<(int col, int row), ShipStatus> Position { get; init; }

        public bool IsSunk();
    }
}