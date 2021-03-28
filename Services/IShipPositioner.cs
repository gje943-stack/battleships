using BattleshipEngine.Models;

namespace BattleshipEngine.Services
{
    public interface IShipPositioner
    {
        Direction DetermineShipDirection();

        (int, int)[] GenerateShipPosition(Board board, IShip ship);
    }
}