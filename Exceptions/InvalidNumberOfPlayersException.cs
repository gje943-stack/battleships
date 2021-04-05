using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Exceptions
{
    public class InvalidNumberOfPlayersException : Exception
    {

        public string message { get; init; }

        public InvalidNumberOfPlayersException(int numOfPlayers)
        {
            message = numOfPlayers < 1 ? "Not enough players. Must be at least 1 player" :
                "Too many players. Can't have more than 2 players";
        }
    }
}
