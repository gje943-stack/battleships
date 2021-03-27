using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public class Battleship : Ship
    {
        public override Direction Direction { get; init; }
        public override int Length { get; init; } = 4;
        public override (int col, int row)[] Coords { get; set; }
        public override bool IsDestroyed { get; set; }

        public Battleship()
        {
            Coords = new (int col, int row)[Length];
        }
    }
}