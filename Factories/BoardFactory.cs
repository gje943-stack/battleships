using BattleshipEngine.Models;
using BattleshipEngine.Services;

namespace BattleshipEngine.Factories
{
    public class BoardFactory : IBoardFactory
    {
        private readonly IShipFactory _shipFac;
        private readonly ICoordsGenerator _generator;

        public BoardFactory(IShipFactory shipFac, ICoordsGenerator generator)
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