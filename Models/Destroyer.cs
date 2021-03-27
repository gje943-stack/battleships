using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public class Destroyer : Ship
    {
        public override Direction Direction { get; init; }
        public override int Length { get; init; } = 2;
        public override (int col, int row)[] Coords { get; set; }
        public override bool IsDestroyed { get; set; }

        public Destroyer()
        {
            Coords = new (int col, int row)[Length];
        }
    }
}