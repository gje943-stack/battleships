using BattleshipEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Services
{
    public static class ShipPositioner
    {
        public static Direction DetermineShipDirection()
        {
            var rnd = new Random();
            var vals = Enum.GetValues(typeof(Direction));
            return (Direction)vals.GetValue(rnd.Next(vals.Length));
        }

        public static (int, int)[] GenerateRandomValidShipCoords(Board board, Ship ship)
        {
            while (true)
            {
                var (col, row) = BoardHelper.SelectRandomSquare(board);
                var coords = GenerateCoords(col, row, ship.Direction, ship.Length);
                if (CoordsAreValid(coords, board))
                {
                    return coords;
                }
            }
        }

        private static bool CoordsAreValid((int col, int row)[] coords, Board board)
        {
            foreach (var coord in coords)
            {
                if (CoordAlreadyOccupied(board.Ships, coord) ||
                    CoordOutsideBoard(coord, board.Columns, board.Rows))
                {
                    return false;
                }
            }
            return true;
        }

        private static (int, int)[] GenerateCoords(int col, int row, Direction dir, int shipLength)
        {
            if (dir == Direction.Horizontal)
            {
                return CreateHorizontalCoords(col, row, shipLength);
            }
            return CreateVerticalCoords(col, row, shipLength);
        }

        private static (int, int)[] CreateHorizontalCoords(int col, int row, int shipLength)
        {
            var coords = new (int, int)[shipLength + 1];
            for (int i = 0; i <= shipLength; i++)
            {
                coords[i] = (col + i, row);
            }

            return coords;
        }

        private static (int, int)[] CreateVerticalCoords(int col, int row, int shipLength)
        {
            var coords = new (int, int)[shipLength + 1];
            for (int i = 0; i <= shipLength; i++)
            {
                coords[i] = (col, row + i);
            }
            return coords;
        }

        private static bool CoordAlreadyOccupied(List<Ship> unavailableCoords, (int, int) proposedCoords)
        {
            if (unavailableCoords.SelectMany(s => s.Coords).Any(c => c == proposedCoords))
            {
                return true;
            }
            return false;
        }

        private static bool CoordOutsideBoard((int col, int row) proposedCoord, int cols, int rows)
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