using BattleshipEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Services
{
    public class ShipPositioner : IShipPositioner
    {
        private readonly ICoordsGenerator _generator;

        public ShipPositioner(ICoordsGenerator generator)
        {
            _generator = generator;
        }

        public Direction DetermineShipDirection()
        {
            var rnd = new Random();
            var vals = Enum.GetValues(typeof(Direction));
            return (Direction)vals.GetValue(rnd.Next(vals.Length));
        }

        public (int, int)[] GenerateShipPosition(Board board, IShip ship)
        {
            while (true)
            {
                var (col, row) = _generator.SelectRandomCoord(board.Columns, board.Rows);
                var randomPosition = GenerateCoords(col, row, ship.Direction, ship.Length);
                if (PositionIsValid(randomPosition, board))
                {
                    return randomPosition;
                }
            }
        }

        private bool PositionIsValid((int col, int row)[] position, Board board)
        {
            foreach (var coord in position)
            {
                if (CoordAlreadyOccupied(board.Ships, coord) ||
                    CoordOutsideBoard(coord, board.Columns, board.Rows))
                {
                    return false;
                }
            }
            return true;
        }

        private (int, int)[] GenerateCoords(int col, int row, Direction dir, int shipLength)
        {
            if (dir == Direction.Horizontal)
            {
                return CreateHorizontalCoords(col, row, shipLength);
            }
            return CreateVerticalCoords(col, row, shipLength);
        }

        private (int, int)[] CreateHorizontalCoords(int col, int row, int shipLength)
        {
            var coords = new (int, int)[shipLength + 1];
            for (int i = 0; i <= shipLength; i++)
            {
                coords[i] = (col + i, row);
            }

            return coords;
        }

        private (int, int)[] CreateVerticalCoords(int col, int row, int shipLength)
        {
            var coords = new (int, int)[shipLength + 1];
            for (int i = 0; i <= shipLength; i++)
            {
                coords[i] = (col, row + i);
            }
            return coords;
        }

        private bool CoordAlreadyOccupied(List<IShip> unavailableCoords, (int, int) proposedCoords)
        {
            if (unavailableCoords.SelectMany(s => s.Position).Any(c => c == proposedCoords))
            {
                return true;
            }
            return false;
        }

        private bool CoordOutsideBoard((int col, int row) proposedCoord, int cols, int rows)
        {
            if (proposedCoord.col > cols - 1 || proposedCoord.col < 0
                || proposedCoord.row > rows - 1 || proposedCoord.row < 0)
            {
                return true;
            }
            return false;
        }
    }
}