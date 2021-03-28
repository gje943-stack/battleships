using BattleshipEngine.Models;
using BattleshipEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipEngine.Factories
{
    public class ShipFactory : IShipFactory
    {
        private readonly IShipPositioner _positioner;

        public Dictionary<Type, Func<IBoard, IShipPositioner, IShip>> shipCreator { get; init; }

        public List<IShip> test { get; set; }

        public ShipFactory(IShipPositioner positioner)
        {
            _positioner = positioner;
            shipCreator = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IShip).IsAssignableFrom(t) && t.IsInterface == false)
                .ToDictionary(t => t, t => new Func<IBoard, IShipPositioner, IShip>((b, p) => (IShip)Activator.CreateInstance(t, new object[] { p, b })));
        }

        public List<IShip> CreateAllShips(IBoard bd)
        {
            return shipCreator.Values
                .Select(f => f(bd, _positioner))
                .ToList();
        }
    }
}