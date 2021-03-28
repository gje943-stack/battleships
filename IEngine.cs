using BattleshipEngine.Models;
using System.Collections.Generic;

namespace BattleshipEngine
{
    public interface IEngine
    {
        void startGame(int cols = 8, int rows = 8, int numOfPlayers = 1);
    }
}