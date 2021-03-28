using BattleshipEngine.Factories;
using BattleshipEngine.Models;
using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Providers
{
    public class BoardProvider : IBoardProvider
    {
        private readonly IShipFactory _shipFac;
        private readonly ICoordsGenerator _generator;

        public BoardProvider(IShipFactory shipFac, ICoordsGenerator generator)
        {
            _shipFac = shipFac;
            _generator = generator;
        }

        public IBoard CreateBoard(int cols, int rows)
        {
            var coords = _generator.GenerateCoords(rows, cols);
            var board = new Board(cols, rows, coords);
            board.Ships = _shipFac.CreateAllShips(board);
            return board;
        }
    }
}