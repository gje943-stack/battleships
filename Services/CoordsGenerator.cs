using BattleshipEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Services
{
    public class CoordsGenerator : ICoordsGenerator
    {
        public (int col, int row) SelectRandomCoord(int cols, int rows)
        {
            var rnd = new Random();
            int randomRow = rnd.Next(rows);
            int randomCol = rnd.Next(cols);
            return (randomCol, randomRow);
        }

        public Dictionary<(int col, int row), CoordStatus> GenerateCoords(int columns, int rows)
        {
            var res = new Dictionary<(int col, int row), CoordStatus>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    res.Add((col, row), CoordStatus.Untouched);
                }
            }
            return res;
        }
    }
}