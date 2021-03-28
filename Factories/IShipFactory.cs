using BattleshipEngine.Models;
using BattleshipEngine.Services;
using System;
using System.Collections.Generic;

namespace BattleshipEngine.Factories
{
    public interface IShipFactory
    {
        Dictionary<Type, Func<IBoard, IShipPositioner, IShip>> shipCreator { get; init; }

        //public IShip CreateInstance(IShip ship, IBoard bd);

        public List<IShip> CreateAllShips(IBoard bd);
    }
}