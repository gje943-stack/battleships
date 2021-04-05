using BattleshipEngine.Models;

namespace BattleshipEngine.Factories
{
    public interface IBoardFactory
    {
        IBoard CreateBoard(int cols, int rows);
    }
}