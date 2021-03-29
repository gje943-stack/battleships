using BattleshipEngine.Models;
using System.Collections.Generic;

namespace BattleshipEngine.Services
{
    public interface IShipPositioner
    {
        Direction DetermineShipDirection();
        Dictionary<(int, int), ShipStatus> GenerateShipPosition(Board board, IShip ship);
    }
}