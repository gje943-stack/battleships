using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public class Battleship : IShip
    {
        private readonly IShipPositioner _positioner;

        public Battleship(IShipPositioner positioner, Board board)
        {
            _positioner = positioner;
            Direction = _positioner.DetermineShipDirection();
            Position = _positioner.GenerateShipPosition(board, this);
        }

        public Direction Direction { get; init; }
        public int Length { get; init; } = 4;
        public (int col, int row)[] Position { get; init; }
        public bool IsDestroyed { get; set; }
    }
}