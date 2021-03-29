using BattleshipEngine.Models;
using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Factories
{
    public class GameDisplayFactory : IGameDisplayFactory
    {
        private readonly Dictionary<CoordStatus, string> DisplayMapping = new()
        {
            { CoordStatus.Untouched, "0" },
            { CoordStatus.Missed, "." },
            { CoordStatus.Hit, "X" }
        };

        public IGameDisplay CreateDisplay(List<IPlayer> players, int idOfPlayerWhoMadeShot = -1)
        {
            return new GameDisplay
            {
                ShipsLeft = GetShipsLeftToDestroy(players.Find(p => p.PlayerId != idOfPlayerWhoMadeShot)),
                Result = GetRecentShotResult(players.Find(p => p.PlayerId == idOfPlayerWhoMadeShot)),
                Boards = GetBoardsInDisplayFormat(players.Select(p => p.Board))
            };
        }

        private int GetShipsLeftToDestroy(IPlayer oppositePlayer)
        {
            var totalShips = oppositePlayer.Board.Ships.Count;
            var shipsDestroyed = oppositePlayer.Stats.ShipsDestroyed;
            return totalShips - shipsDestroyed;
        }

        private ShotResult GetRecentShotResult(IPlayer playerWhoMadeShot)
        {
            return playerWhoMadeShot.Stats.ShotResults.Last();
        }

        // REFACTOR THIS METHOD
        private List<List<List<string>>> GetBoardsInDisplayFormat(IEnumerable<IBoard> boards)
        {
            var display = new List<List<List<string>>>();
            foreach (var board in boards)
            {
                var boardInDIsplayFormat = new List<List<string>>();
                for (int rowNum = 0; rowNum < board.Rows; rowNum++)
                {
                    var row = new List<string>();
                    for (int colNum = 0; colNum < board.Columns; colNum++)
                    {
                        var coordStatus = board.Coords[(rowNum, colNum)];
                        row.Add(DisplayMapping[coordStatus]);
                    }
                    boardInDIsplayFormat.Add(row);
                }
                display.Add(boardInDIsplayFormat);
            }
            return display;
        }
    }
}
