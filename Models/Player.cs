using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public class Player
    {
        public Board Board { get; init; }

        public int PlayerId { get; set; }

        public Player(int rows, int columns, int playerId)
        {
            Board = new(rows, columns);
            Board.PositionShips();
        }
    }
}