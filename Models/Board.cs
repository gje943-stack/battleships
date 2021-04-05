using BattleshipEngine.Factories;
using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public enum CoordStatus
    {
        Untouched,
        Missed,
        Hit
    }

    public class Board : IBoard
    {
        public int Rows { get; init; }

        public int Columns { get; init; }

        public Dictionary<(int row, int col), CoordStatus> Coords { get; set; }

        public List<IShip> Ships { get; set; } = new();

        public Board(int columns, int rows, Dictionary<(int row, int col), CoordStatus> coords)
        {
            Columns = columns;
            Rows = rows;
            Coords = coords;
        }
    }
}