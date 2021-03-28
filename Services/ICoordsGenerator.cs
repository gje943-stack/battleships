using BattleshipEngine.Models;
using System.Collections.Generic;

namespace BattleshipEngine.Services
{
    public interface ICoordsGenerator
    {
        Dictionary<(int col, int row), CoordStatus> GenerateCoords(int rows, int columns);

        (int col, int row) SelectRandomCoord(int cols, int rows);
    }
}