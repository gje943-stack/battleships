using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public class Destroyer : IShip
    {
        private readonly IShipPositioner _positioner;

        public Destroyer(IShipPositioner positioner, Board board)
        {
            _positioner = positioner;
            Direction = _positioner.DetermineShipDirection();
            Position = _positioner.GenerateShipPosition(board, this);
        }

        public Direction Direction { get; init; }
        public int Length { get; init; } = 2;
        public Dictionary<(int col, int row), ShipStatus> Position { get; init; }

        public bool IsSunk()
        {
            return Position.Values.All(status => status == ShipStatus.Hit);
        }
    }
}