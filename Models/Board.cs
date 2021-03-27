using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public enum SquareStatus
    {
        Untouched,
        Missed,
        Hit
    }

    public class Board
    {
        public int Rows { get; set; }

        public int Columns { get; set; }

        public Dictionary<(int row, int col), SquareStatus> Coords { get; set; }

        public List<Ship> Ships { get; init; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Coords = BoardHelper.GenerateBoard(Rows, Columns);
            Ships = new List<Ship>
            {
                new Cruiser(),
                new Battleship(),
                new Destroyer()
            };
        }

        public void PositionShips()
        {
            foreach (var ship in Ships)
            {
                ship.Coords = ShipPositioner.GenerateRandomValidShipCoords(this, ship);
            }
        }
    }
}