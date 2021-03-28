using BattleshipEngine.Models;

namespace BattleshipEngine.Providers
{
    public interface IBoardProvider
    {
        IBoard CreateBoard(int cols, int rows);
    }
}