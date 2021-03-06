using BattleshipEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Dictionary<(int, int), ShipStatus> GenerateShipPosition(Board board, IShip ship)
        {
            while (true)
            {
                var (col, row) = _generator.SelectRandomCoord(board.Columns, board.Rows);
                var randomPosition = GenerateCoords(col, row, ship.Direction, ship.Length);
                if (PositionIsValid(randomPosition, board))
                {
                    return randomPosition.ToDictionary(p => p, s => ShipStatus.Intact);
                }
            }
        }

        private bool PositionIsValid(List<(int, int)> position, Board board)
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

        private List<(int, int)> GenerateCoords(int col, int row, Direction dir, int shipLength)
        {
            if (dir == Direction.Horizontal)
            {
                return CreateHorizontalCoords(col, row, shipLength);
            }
            return CreateVerticalCoords(col, row, shipLength);
        }

        private List<(int, int)> CreateHorizontalCoords(int col, int row, int shipLength)
        {
            var coords = new List<(int, int)>();
            for (int i = 0; i <= shipLength; i++)
            {
                coords.Add((col, row + i));
            }

            return coords;
        }

        private List<(int, int)> CreateVerticalCoords(int col, int row, int shipLength)
        {
            var coords = new List<(int, int)>();
            for (int i = 0; i <= shipLength; i++)
            {
                coords.Add((col, row + i));
            }
            return coords;
        }

        private bool CoordAlreadyOccupied(List<IShip> unavailableCoords, (int, int) proposedCoords)
        {
            return unavailableCoords.SelectMany(s => s.Position.Keys).Any(c => c == proposedCoords);
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