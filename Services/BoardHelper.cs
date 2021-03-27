using BattleshipEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Services
{
    public static class BoardHelper
    {
        public static (int col, int row) SelectRandomSquare(Board board)
        {
            var rnd = new Random();
            int randomRow = rnd.Next(board.Rows);
            int randomCol = rnd.Next(board.Columns);
            return (randomCol, randomRow);
        }

        public static Dictionary<(int col, int row), SquareStatus> GenerateBoard(int rows, int columns)
        {
            var res = new Dictionary<(int col, int row), SquareStatus>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    res.Add((col, row), SquareStatus.Untouched);
                }
            }
            return res;
        }
    }
}