using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Exceptions
{
    public class InvalidPlayerIdException : Exception
    {
        public override string Message { get; } = "Invalid player ID";
    }
}
