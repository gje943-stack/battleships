using BattleshipEngine.Factories;
using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Models
{
    public class Player : IPlayer
    {
        public Player(int playerId)
        {
            PlayerId = playerId;
        }

        public IBoard Board { get; set; }

        public int PlayerId { get; init; }
    }
}