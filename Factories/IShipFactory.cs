using BattleshipEngine.Models;
using BattleshipEngine.Services;
using System;
using System.Collections.Generic;

namespace BattleshipEngine.Factories
{
    public interface IShipFactory
    {
        Dictionary<Type, Func<IBoard, IShipPositioner, IShip>> ShipCreator { get; init; }

        public List<IShip> CreateAllShips(IBoard bd);
    }
}