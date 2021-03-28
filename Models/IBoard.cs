using System.Collections.Generic;

namespace BattleshipEngine.Models
{
    public interface IBoard
    {
        int Columns { get; init; }
        Dictionary<(int row, int col), CoordStatus> Coords { get; set; }
        int Rows { get; init; }
        List<IShip> Ships { get; set; }
    }
}